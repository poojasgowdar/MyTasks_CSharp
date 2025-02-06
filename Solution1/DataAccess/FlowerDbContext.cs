using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public partial class FlowerDbContext : DbContext
{
    public FlowerDbContext()
    {
    }

    public FlowerDbContext(DbContextOptions<FlowerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Flower> Flowers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=FlowerDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flower>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Flowers__3213E83F936C81CE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Flower>().HasData(
            new Flower { Id = 1, Name = "Rose" },
            new Flower { Id = 2, Name = "Sunflower" }
            );
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
