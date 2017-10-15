using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AgeRangerAPI.Models
{
    [Table("AgeGroup")]
    public class AgeGroup
    {
        public int Id { get; set; }
        
        public int? MinAge { get; set; }

        public int? MaxAge { get; set; }

        public string Description { get; set; }
    }
}