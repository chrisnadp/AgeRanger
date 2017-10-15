using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace AgeRangerAPI.Models
{
    public class AgeRangerAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AgeRangerAPIContext() : base("name=AgeRangerAPIContext")
        {
        }

        public System.Data.Entity.DbSet<AgeRangerAPI.Models.AgeGroup> AgeGroups { get; set; }

        public System.Data.Entity.DbSet<AgeRangerAPI.Models.Person> People { get; set; }
    }
}
