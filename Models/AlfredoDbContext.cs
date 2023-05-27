using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ERPSchool.Models;

public partial class AlfredoDbContext : DbContext
{
    public AlfredoDbContext()
    {
    }

    public AlfredoDbContext(DbContextOptions<AlfredoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Neighbourhood> Neighbourhoods { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Sex> Sexes { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Town> Towns { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Groups__3214EC07A8DD8395");

            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SchoolFk).HasColumnName("SchoolFK");

            entity.HasOne(d => d.SchoolFkNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.SchoolFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Groups__SchoolFK__21B6055D");
        });

        modelBuilder.Entity<Neighbourhood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Neighbou__3214EC07CC08240C");

            entity.ToTable("Neighbourhood");

            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.TownFk).HasColumnName("TownFK");

            entity.HasOne(d => d.TownFkNavigation).WithMany(p => p.Neighbourhoods)
                .HasForeignKey(d => d.TownFk)
                .HasConstraintName("FK__Neighbour__TownF__1920BF5C");
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Schools__3214EC07889BC8B7");

            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Number)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StreetName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.NeighborhoodFkNavigation).WithMany(p => p.Schools)
                .HasForeignKey(d => d.NeighborhoodFk)
                .HasConstraintName("FK__Schools__Neighbo__4F7CD00D");
        });

        modelBuilder.Entity<Sex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sex__3214EC07E68CB178");

            entity.ToTable("Sex");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__States__3214EC073F0B9BFD");

            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07C82F43B2");

            entity.ToTable("Student");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.GroupFk).HasColumnName("GroupFK");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SexFk).HasColumnName("SexFK");

            entity.HasOne(d => d.GroupFkNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.GroupFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__GroupFK__276EDEB3");

            entity.HasOne(d => d.SexFkNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.SexFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__SexFK__267ABA7A");
        });

        modelBuilder.Entity<Town>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Town__3214EC073415B969");

            entity.ToTable("Town");

            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.StatesFk).HasColumnName("StatesFK");

            entity.HasOne(d => d.StatesFkNavigation).WithMany(p => p.Towns)
                .HasForeignKey(d => d.StatesFk)
                .HasConstraintName("FK__Town__StatesFK__164452B1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
