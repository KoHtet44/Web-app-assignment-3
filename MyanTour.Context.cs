﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyanTour
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyanTourEntities : DbContext
    {
        public MyanTourEntities()
            : base("name=MyanTourEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Car_Booking> Car_Booking { get; set; }
        public virtual DbSet<Cruies> Cruies { get; set; }
        public virtual DbSet<Cruies_Booking> Cruies_Booking { get; set; }
        public virtual DbSet<Express> Express { get; set; }
        public virtual DbSet<Express_Booking> Express_Booking { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Flight_Booking> Flight_Booking { get; set; }
    }
}
