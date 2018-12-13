using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TechnologyCharacterGenerator.Models;
using TechnologyCharacterGenerator.Child.Common.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic
{
    public class TechnologyCharacterCreator : ITechnologyCharacterCreator
    {
        private readonly IEnumerable<ITechnologyCharacterPropertyGenerator> _TechnologyCharacterPropertyGenerator;
        private readonly ILogger<TechnologyCharacterCreator> _logger;

        public TechnologyCharacterCreator(IEnumerable<ITechnologyCharacterPropertyGenerator> TechnologyCharacterPropertyGenerator, ILogger<TechnologyCharacterCreator> logger)
        {
            _TechnologyCharacterPropertyGenerator = TechnologyCharacterPropertyGenerator;
            _logger = logger;
        }

        public TechnologyCharacterViewModel GenerateTechnologyCharacter(UserViewModel userViewModel)
        {
            var user = JsonConvert.SerializeObject(userViewModel);

            _logger.LogInformation($"Generating Hash of {user}");
            var userHashArray = CreateUserHashArray(user);

            var TechnologyCharacter = new TechnologyCharacterViewModel
            {
                UserHash = string.Join(string.Empty, userHashArray)
            };

            _logger.LogInformation($"Hash = \"{TechnologyCharacter.UserHash}\" ({string.Join(", ", userHashArray)})");

            foreach (var TechnologyCharacterPropertyGenerator in _TechnologyCharacterPropertyGenerator.OrderBy(r => r.Order))
            {
                if (userHashArray.Length <= TechnologyCharacterPropertyGenerator.UserHashIndex)
                {
                    _logger.LogError(
                        $"Index ({TechnologyCharacterPropertyGenerator.UserHashIndex}) for {TechnologyCharacterPropertyGenerator.GetType().Name} " +
                        $"is outside of the length of the hash ({userHashArray.Length})");
                    continue;
                };

                var hashValue = ushort.Parse(userHashArray[TechnologyCharacterPropertyGenerator.UserHashIndex], NumberStyles.HexNumber);

                _logger.LogInformation($"Value for the HashArray at ({TechnologyCharacterPropertyGenerator.UserHashIndex}) " +
                                       $"is ({userHashArray[TechnologyCharacterPropertyGenerator.UserHashIndex]}) or ({hashValue})");

                TechnologyCharacterPropertyGenerator.GenerateTechnologyCharacterProperty(ref TechnologyCharacter,
                    hashValue, userViewModel);
            }

            return TechnologyCharacter;
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