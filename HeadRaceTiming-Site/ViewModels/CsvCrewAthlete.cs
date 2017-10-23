using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.ViewModels
{
    public class CsvCrewAthlete
    {
        public int CrewID { get; set; }
        public int Position { get; set; }
        public string MembershipNumber { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public DateTime DofB { get; set; }
        public char Gender { get; set; }
        public bool Cox { get; set; }
        public string MembersClubName { get; set; }
        public string MembersClubIndexCode { get; set; }
        public int RowingPRI { get; set; }
        public int ScullingPRI { get; set; }
        public int RowingPRIMax { get; set; }
        public int ScullingPRIMax { get; set; }
        public int RowingPoints { get; set; }
        public int ScullingPoints { get; set; }
        public bool Substitute { get; set; }
    }
}
