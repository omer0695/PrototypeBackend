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
    
    public partial class vehicle
    {
        public vehicle()
        {
            this.films = new HashSet<film>();
            this.people = new HashSet<person>();
        }
    
        public int id { get; set; }
        public string vehicle_class { get; set; }
    
        public virtual ICollection<film> films { get; set; }
        public virtual ICollection<person> people { get; set; }
    }
}
