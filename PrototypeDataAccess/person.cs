//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrototypeDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class person
    {
        public person()
        {
            this.films = new HashSet<film>();
            this.species = new HashSet<species>();
            this.starships = new HashSet<starship>();
            this.vehicles = new HashSet<vehicle>();
        }
    
        public int id { get; set; }
        public string birth_year { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public Nullable<System.DateTime> edited { get; set; }
        public string eye_color { get; set; }
        public string gender { get; set; }
        public string hair_color { get; set; }
        public string height { get; set; }
        public Nullable<int> homeworld { get; set; }
        public string mass { get; set; }
        public string name { get; set; }
        public string skin_color { get; set; }
    
        public virtual ICollection<film> films { get; set; }
        public virtual ICollection<species> species { get; set; }
        public virtual ICollection<starship> starships { get; set; }
        public virtual ICollection<vehicle> vehicles { get; set; }
    }
}
