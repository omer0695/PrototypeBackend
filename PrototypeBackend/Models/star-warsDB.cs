using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrototypeBackend.Models
{
    public class star_warsDB: DbContext 
    {
        public star_warsDB() : base("name=DefaultConnection")
        {
        }
        public DbSet<film> film { get; set; }
    }
}