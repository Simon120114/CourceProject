﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sima_Web.Models
{
    public partial class SimaContext : DbContext
    {
        public SimaContext()
        {
        }

        public SimaContext(DbContextOptions<SimaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Quarter> Quarters { get; set; }
        public virtual DbSet<Swap> Swaps { get; set; }
        public virtual DbSet<TypeHouse> TypeHouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=banking-sqlserver.database.windows.net;Initial Catalog=Sima;Persist Security Info=True;User ID=sqlserver;Password=BankingSystem08");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AreaConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new QuarterConfiguration());
            modelBuilder.ApplyConfiguration(new SwapConfiguration());
            modelBuilder.ApplyConfiguration(new TypeHouseConfiguration());


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
