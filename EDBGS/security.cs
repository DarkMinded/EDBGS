//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDBGS
{
    using System;
    using System.Collections.Generic;
    
    public partial class security
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public security()
        {
            this.edsystemhists = new HashSet<edsystemhist>();
        }
    
        public int securityid { get; set; }
        public string name { get; set; }
        public string game_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<edsystemhist> edsystemhists { get; set; }
    }
}