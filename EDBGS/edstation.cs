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
    
    public partial class edstation
    {
        public long edstationId { get; set; }
        public string Name { get; set; }
        public long ControlingFaction { get; set; }
        public long SystemId { get; set; }
        public int EconomyId { get; set; }
        public int StationTypeId { get; set; }
        public bool Planetary { get; set; }
        public long EDDNId { get; set; }
    
        public virtual edfaction edfaction { get; set; }
        public virtual edsystem edsystem { get; set; }
    }
}
