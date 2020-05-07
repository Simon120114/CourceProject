﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sima_Web.Models
{
    public class SwapConfiguration : IEntityTypeConfiguration<Swap>
    {
        public void Configure(EntityTypeBuilder<Swap> entity)
        {
            entity.HasKey(e => e.Id)
                .HasName("Swap_pk")
                .IsClustered(false);

            entity.ToTable("Swap");

            entity.HasIndex(e => e.Id)
                .HasName("Swap_Id_uindex")
                .IsUnique();

            entity.Property(e => e.CurrentQuartersId).HasComment(@"Код жилья которое он меняет
");

            entity.Property(e => e.CustomerId).HasComment("Код пользователя что производит обмен");

            entity.Property(e => e.SwapDate)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())")
                .HasComment(@"Дата обмена
");

            entity.Property(e => e.SwapQuartersId).HasComment("Код жилья на которое меняет");

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.Swaps)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Swap_Customer_Id_fk");

            entity.HasOne(d => d.SwapQuarters)
                .WithMany(p => p.Swaps)
                .HasForeignKey(d => d.SwapQuartersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Swap_Quarters_Id_fk");
        }
    }
}
