﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Workforce.Data.Associates2.Domain
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjectFeliceDB_TestEntities : DbContext
    {
        public ProjectFeliceDB_TestEntities()
            : base("name=ProjectFeliceDB_TestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Associate> Associate { get; set; }
        public virtual DbSet<AssociateAddress> AssociateAddress { get; set; }
        public virtual DbSet<Batch> Batch { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
    }
}
