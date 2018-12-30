using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TechnologyCharacterGenerator.Foundation.Models;
using __Blazor.TechnologyCharacterGenerator.Child.Common.Models;

namespace TechnologyCharacterGenerator.Child.Common.BusinessLogic.TechnologyCharacter
{
    public class TechnologyCharacterCreator : ITechnologyCharacterCreator
    {
        private readonly IEnumerable<ITechnologyCharacterPropertyGenerator> _technologyCharacterPropertyGenerator;
        private readonly ILogger<TechnologyCharacterCreator> _logger;

        public TechnologyCharacterCreator(IEnumerable<ITechnologyCharacterPropertyGenerator> technologyCharacterPropertyGenerator, ILogger<TechnologyCharacterCreator> logger)
        {
            _technologyCharacterPropertyGenerator = technologyCharacterPropertyGenerator;
            _logger = logger;
        }

        public TechnologyCharacterViewModel GenerateTechnologyCharacter(UserViewModel userViewModel)
        {
            var user = JsonConvert.SerializeObject(userViewModel);

            _logger.LogInformation($"Generating Hash of {user}");

            var userHashArray = CreateUserHashArray(user);

            var technologyCharacter = new TechnologyCharacterViewModel
            {
                UserHash = string.Join(string.Empty, userHashArray)
            };

            _logger.LogInformation($"Hash = \"{technologyCharacter.UserHash}\" ({string.Join(", ", userHashArray)})");

            foreach (var technologyCharacterPropertyGenerator in _technologyCharacterPropertyGenerator)
            {
                if (userHashArray.Length <= technologyCharacterPropertyGenerator.UserHashIndex)
                {
                    _logger.LogError(
                        $"Index ({technologyCharacterPropertyGenerator.UserHashIndex}) for {technologyCharacterPropertyGenerator.GetType().Name} " +
                        $"is outside of the length of the hash ({userHashArray.Length})");
                    continue;
                };

                var hashValue = ushort.Parse(userHashArray[technologyCharacterPropertyGenerator.UserHashIndex], NumberStyles.HexNumber);

                _logger.LogInformation($"Value for the HashArray at ({technologyCharacterPropertyGenerator.UserHashIndex}) " +
                                       $"is ({userHashArray[technologyCharacterPropertyGenerator.UserHashIndex]}) or ({hashValue})");

                technologyCharacterPropertyGenerator.GenerateTechnologyCharacterProperty(ref technologyCharacter,
                    hashValue, userViewModel);
            }

            return technologyCharacter;
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