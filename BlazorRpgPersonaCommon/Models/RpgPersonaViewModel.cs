using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRpgPersonaCommon.Models
{
    public class RpgPersonaViewModel
    {
        public string CharacterName { get; set; }

        public string Class { get; set; }

        public ClassTypes ClassType { get; set; }

        public ushort HitPoints { get; set; }

        public ushort Strength { get; set; }

        public ushort Agility { get; set; }

        public ushort Intelligence { get; set; }

        public ushort Charisma { get; set; }

        public ushort Wisdom { get; set; }

        public ushort Luck { get; set; }

        public ushort Constitution { get; set; }

        public ushort Perception { get; set; }

        public string UserHash { get; set; }
    }
}
