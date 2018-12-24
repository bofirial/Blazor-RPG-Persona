using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TechnologyCharacterGenerator.Foundation.Models
{
    public class MonthDescription
    {
        public string Month { get; set; }

        public int MonthNumber { get; set; }

        public int DaysInMonth { get; set; }
        
        public static List<MonthDescription> AllMonths { get; set; } = new List<MonthDescription>()
        {
            new MonthDescription() {MonthNumber = 1,  Month = "January",   DaysInMonth = 31},
            new MonthDescription() {MonthNumber = 2,  Month = "February",  DaysInMonth = 29},
            new MonthDescription() {MonthNumber = 3,  Month = "March",     DaysInMonth = 31},
            new MonthDescription() {MonthNumber = 4,  Month = "April",     DaysInMonth = 30},
            new MonthDescription() {MonthNumber = 5,  Month = "May",       DaysInMonth = 31},
            new MonthDescription() {MonthNumber = 6,  Month = "June",      DaysInMonth = 30},
            new MonthDescription() {MonthNumber = 7,  Month = "July",      DaysInMonth = 31},
            new MonthDescription() {MonthNumber = 8,  Month = "August",    DaysInMonth = 31},
            new MonthDescription() {MonthNumber = 9,  Month = "September", DaysInMonth = 30},
            new MonthDescription() {MonthNumber = 10, Month = "October",   DaysInMonth = 31},
            new MonthDescription() {MonthNumber = 11, Month = "November",  DaysInMonth = 30},
            new MonthDescription() {MonthNumber = 12, Month = "December",  DaysInMonth = 31 }
        };
    }
}
