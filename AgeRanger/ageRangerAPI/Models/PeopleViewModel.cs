using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeRangerAPI.Models
{
    public class PeopleViewModel
    {
        public List<PersonAgeGroup> PeopleAgeGroup { get; set; }
        public Person SelectedPerson { get; set; }
        public string DisplayMode { get; set; }
    }
}