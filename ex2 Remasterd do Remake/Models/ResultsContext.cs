using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ex2_Remasterd_do_Remake.Models;

public partial class ResultsContext : DbContext
{
    public ResultsContext()
    {
    }

    public ResultsContext(DbContextOptions<ResultsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Results> Results { get; set; }

    public virtual DbSet<Number> Numbers { get; set; }

    public virtual DbSet<Star> Stars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC-INTERN002\\SQLEXPRESS;Database=Results;Integrated Security=True;TrustServerCertificate=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Results>(entity =>
        {
            entity.HasKey(e => e.NumberKey).HasName("PK__Key__FAD50291DCE87FE8");

            entity.ToTable("Key");

            entity.Property(e => e.NumberKey)
                .ValueGeneratedNever()
                .HasColumnName("Number_Key");
            entity.Property(e => e.Date).HasColumnType("datetime");
        });

        modelBuilder.Entity<Number>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Numbers__3214EC27163A9FBC");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NumberKey).HasColumnName("Number_Key");

            entity.HasOne(d => d.NumberKeyNavigation).WithMany(p => p.Numbers)
                .HasForeignKey(d => d.NumberKey)
                .HasConstraintName("FK__Numbers__Number___619B8048");
        });

        modelBuilder.Entity<Star>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stars__3214EC27150EFF09");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NumberKey).HasColumnName("Number_Key");

            entity.HasOne(d => d.NumberKeyNavigation).WithMany(p => p.Stars)
                .HasForeignKey(d => d.NumberKey)
                .HasConstraintName("FK__Stars__Number_Ke__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
