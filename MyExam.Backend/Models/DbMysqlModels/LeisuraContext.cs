using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MyExam.Backend.Models.DbMysqlModels;

public partial class LeisuraContext : DbContext
{
    public LeisuraContext()
    {
    }

    public LeisuraContext(DbContextOptions<LeisuraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LeisuraCard> LeisuraCards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=leisura;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_hungarian_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<LeisuraCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("leisura_card")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(2)")
                .HasColumnName("id");
            entity.Property(e => e.AmountHuf)
                .HasColumnType("int(6)")
                .HasColumnName("amount_huf");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(12)
                .HasColumnName("employee_name");
            entity.Property(e => e.IsMale)
                .HasMaxLength(5)
                .HasColumnName("is_male");
            entity.Property(e => e.TransactionDate)
                .HasMaxLength(10)
                .HasColumnName("transaction_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
