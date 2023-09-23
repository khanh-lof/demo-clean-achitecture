using System;
using System.Collections.Generic;
using CabinetManagement.Application.Common.Interfaces;
using CabinetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CabinetManagement.Infrastructure.Entities;

public partial class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Box> Boxes { get; set; }

    public virtual DbSet<BoxActivity> BoxActivities { get; set; }

    public virtual DbSet<BoxType> BoxTypes { get; set; }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<CabinetType> CabinetTypes { get; set; }

    public virtual DbSet<Command> Commands { get; set; }

    public virtual DbSet<Controller> Controllers { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database=CMS;Uid=sa;Pwd=12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Box>(entity =>
        {
            entity.HasKey(e => e.BoxId).HasName("PK__Box__136CF704605B07A3");

            entity.ToTable("Box");

            entity.Property(e => e.BoxId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("BoxID");
        });

        modelBuilder.Entity<BoxActivity>(entity =>
        {
            entity.HasKey(e => e.LogBoxId).HasName("PK__BoxActiv__1D9E06BE6161F291");

            entity.ToTable("BoxActivity");

            entity.Property(e => e.LogBoxId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("LogBoxID");
            entity.Property(e => e.Action)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Time).HasColumnType("datetime");
        });

        modelBuilder.Entity<BoxType>(entity =>
        {
            entity.HasKey(e => e.BoxTypeId).HasName("PK__BoxType__5D8892502B8B0732");

            entity.ToTable("BoxType");

            entity.Property(e => e.BoxTypeId).HasColumnName("BoxTypeID");
            entity.Property(e => e.Depth).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Height).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Width).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Cabinet>(entity =>
        {
            entity.HasKey(e => e.CabinetId).HasName("PK__Cabinet__9C173EB3010C01DB");

            entity.ToTable("Cabinet");

            entity.Property(e => e.CabinetId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CabinetID");
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<CabinetType>(entity =>
        {
            entity.HasKey(e => e.CabinetTypeId).HasName("PK__CabinetT__ADD80ABBA141D7F0");

            entity.ToTable("CabinetType");

            entity.Property(e => e.CabinetTypeId).HasColumnName("CabinetTypeID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Command>(entity =>
        {
            entity.HasKey(e => e.CommandId).HasName("PK__Command__6B4108E6A0810BCC");

            entity.ToTable("Command");

            entity.Property(e => e.CommandId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CommandID");
            entity.Property(e => e.CommandType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Time).HasColumnType("datetime");
        });

        modelBuilder.Entity<Controller>(entity =>
        {
            entity.HasKey(e => e.ControllerId).HasName("PK__Controll__5A8912B07632E83C");

            entity.ToTable("Controller");

            entity.Property(e => e.ControllerId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ControllerID");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(26)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8C4F0A53C");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CustomerID");
            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PK__District__85FDA4A67EB5724F");

            entity.ToTable("District");

            entity.Property(e => e.DistrictId).HasColumnName("DistrictID");
            entity.Property(e => e.DistrictName).HasMaxLength(50);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA477F0741AA8");

            entity.ToTable("Location");

            entity.Property(e => e.LocationId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("LocationID");
            entity.Property(e => e.LocationDetail).HasMaxLength(100);
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.ProvinceId).HasName("PK__Province__FD0A6FA3E7F049B4");

            entity.ToTable("Province");

            entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");
            entity.Property(e => e.ProvinceName).HasMaxLength(50);
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.WardId).HasName("PK__Ward__C6BD9BEAE6D920B6");

            entity.ToTable("Ward");

            entity.Property(e => e.WardId).HasColumnName("WardID");
            entity.Property(e => e.WardName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
