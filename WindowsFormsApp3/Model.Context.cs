﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp3
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLBHEntities1 : DbContext
    {
        public QLBHEntities1()
            : base("name=QLBHEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<temp> temps { get; set; }
        public virtual DbSet<CT_PhieuBanHang> CT_PhieuBanHang { get; set; }
        public virtual DbSet<PhieuBanHang> PhieuBanHangs { get; set; }
        public virtual DbSet<PhieuMuaHang> PhieuMuaHangs { get; set; }
        public virtual DbSet<CT_PhieuNhapHang> CT_PhieuNhapHang { get; set; }
    }
}
