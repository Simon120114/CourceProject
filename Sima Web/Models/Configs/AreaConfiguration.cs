﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sima_Web.Models
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> entity)
        {
            entity.HasKey(e => e.Id)
                .HasName("Area_pk")
                .IsClustered(false);

            entity.ToTable("Area");

            entity.HasIndex(e => e.Id)
                .HasName("Area_Id_uindex")
                .IsUnique();

            entity.Property(e => e.Name).IsRequired();
        }
    }
}
