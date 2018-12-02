using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BlazorRpgPersonaCommon.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BlazorRpgPersonaCommon.BusinessLogic
{
    public class RpgPersonaGenerator : IRpgPersonaGenerator
    {
        private readonly IEnumerable<IRpgPersonaPropertyGenerator> _rpgPersonaPropertyGenerator;
        private readonly ILogger<RpgPersonaGenerator> _logger;

        public RpgPersonaGenerator(IEnumerable<IRpgPersonaPropertyGenerator> rpgPersonaPropertyGenerator, ILogger<RpgPersonaGenerator> logger)
        {
            _rpgPersonaPropertyGenerator = rpgPersonaPropertyGenerator;
            _logger = logger;
        }

        public RpgPersonaViewModel GenerateRpgPersona(UserViewModel userViewModel)
        {
            var user = JsonConvert.SerializeObject(userViewModel);

            _logger.LogInformation($"Generating Hash of {user}");
            var userHashArray = CreateUserHashArray(user);

            var rpgPersona = new RpgPersonaViewModel
            {
                UserHash = string.Join(string.Empty, userHashArray)
            };

            _logger.LogInformation($"Hash = \"{rpgPersona.UserHash}\" ({string.Join(", ", userHashArray)})");

            foreach (var rpgPersonaPropertyGenerator in _rpgPersonaPropertyGenerator.OrderBy(r => r.Order))
            {
                if (userHashArray.Length <= rpgPersonaPropertyGenerator.UserHashIndex)
                {
                    _logger.LogError(
                        $"Index ({rpgPersonaPropertyGenerator.UserHashIndex}) for {rpgPersonaPropertyGenerator.GetType().Name} " +
                        $"is outside of the length of the hash ({userHashArray.Length})");
                    continue;
                };

                var hashValue = ushort.Parse(userHashArray[rpgPersonaPropertyGenerator.UserHashIndex], NumberStyles.HexNumber);

                _logger.LogInformation($"Value for the HashArray at ({rpgPersonaPropertyGenerator.UserHashIndex}) " +
                                       $"is ({userHashArray[rpgPersonaPropertyGenerator.UserHashIndex]}) or ({hashValue})");

                rpgPersonaPropertyGenerator.GenerateRpgPersonaProperty(ref rpgPersona,
                    hashValue, userViewModel);
            }

            return rpgPersona;
        }

        private static string[] CreateUserHashArray(string user)
        {
            var bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(user));

            var hashString = string.Join(string.Empty,
                    bytes.Select(b => b.ToString("X2")));

            return hashString.Select(s => s.ToString()).ToArray();
        }
    }
}