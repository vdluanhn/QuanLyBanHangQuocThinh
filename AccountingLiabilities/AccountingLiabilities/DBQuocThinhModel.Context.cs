﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccountingLiabilities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBQuocThinhEntities : DbContext
    {
        public DBQuocThinhEntities()
            : base("name=DBQuocThinhEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DonDaHoanTraThucTe> DonDaHoanTraThucTes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<DoiSoatVanChuyen> DoiSoatVanChuyens { get; set; }
        public virtual DbSet<DonDi> DonDis { get; set; }
    
        public virtual ObjectResult<PROC_SEARCH_DOISOAT_BY_PARAM_Result> PROC_SEARCH_DOISOAT_BY_PARAM(string v_partner, string v_status, string v_code, Nullable<System.DateTime> v_fromDateDS, Nullable<System.DateTime> v_toDateDS)
        {
            var v_partnerParameter = v_partner != null ?
                new ObjectParameter("v_partner", v_partner) :
                new ObjectParameter("v_partner", typeof(string));
    
            var v_statusParameter = v_status != null ?
                new ObjectParameter("v_status", v_status) :
                new ObjectParameter("v_status", typeof(string));
    
            var v_codeParameter = v_code != null ?
                new ObjectParameter("v_code", v_code) :
                new ObjectParameter("v_code", typeof(string));
    
            var v_fromDateDSParameter = v_fromDateDS.HasValue ?
                new ObjectParameter("v_fromDateDS", v_fromDateDS) :
                new ObjectParameter("v_fromDateDS", typeof(System.DateTime));
    
            var v_toDateDSParameter = v_toDateDS.HasValue ?
                new ObjectParameter("v_toDateDS", v_toDateDS) :
                new ObjectParameter("v_toDateDS", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PROC_SEARCH_DOISOAT_BY_PARAM_Result>("PROC_SEARCH_DOISOAT_BY_PARAM", v_partnerParameter, v_statusParameter, v_codeParameter, v_fromDateDSParameter, v_toDateDSParameter);
        }
    }
}
