using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Reservations.Backend.DataEntity.EFModels;

namespace Reservations.Backend.DataEntity.EFModels.Context;

public partial class DbDataContext : DbContext
{
    public DbDataContext(DbContextOptions<DbDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<rest_reservation> rest_reservation { get; set; }

    public virtual DbSet<rest_shift> rest_shift { get; set; }

    public virtual DbSet<rest_table> rest_table { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<rest_reservation>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.HasOne(d => d.Shift).WithMany(p => p.rest_reservation)
                .HasForeignKey(d => d.ShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_rest_reservation_rest_shift");

            entity.HasOne(d => d.Table).WithMany(p => p.rest_reservation)
                .HasForeignKey(d => d.TableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_rest_reservation_rest_table");
        });

        modelBuilder.Entity<rest_shift>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_shift");
        });

        modelBuilder.Entity<rest_table>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RestaurantTable");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
