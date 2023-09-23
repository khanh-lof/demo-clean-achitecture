using CabinetManagement.Application.Common.Interfaces;
using CabinetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CabinetManagement.Infrastructure;

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
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Box>(entity =>
        {
            entity.HasKey(e => e.BoxId).HasName("PK__Box__136CF704E605EBE4");

            entity.ToTable("Box");

            entity.Property(e => e.BoxId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("BoxID");
            entity.Property(e => e.BoxTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("BoxTypeID");
            entity.Property(e => e.CabinetId).HasColumnName("CabinetID");

            entity.HasOne(d => d.BoxType).WithMany(p => p.Boxes)
                .HasForeignKey(d => d.BoxTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Box__BoxTypeID__5AEE82B9");

            entity.HasOne(d => d.Cabinet).WithMany(p => p.Boxes)
                .HasForeignKey(d => d.CabinetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Box__CabinetID__59FA5E80");
        });

        modelBuilder.Entity<BoxActivity>(entity =>
        {
            entity.HasKey(e => e.LogBoxId).HasName("PK__BoxActiv__1D9E06BE45E221FF");

            entity.ToTable("BoxActivity");

            entity.Property(e => e.LogBoxId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("LogBoxID");
            entity.Property(e => e.Action)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BoxId).HasColumnName("BoxID");
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Box).WithMany(p => p.BoxActivities)
                .HasForeignKey(d => d.BoxId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BoxActivi__BoxID__5BE2A6F2");
        });

        modelBuilder.Entity<BoxType>(entity =>
        {
            entity.HasKey(e => e.BoxTypeId).HasName("PK__BoxType__5D8892500B61648E");

            entity.ToTable("BoxType");

            entity.Property(e => e.BoxTypeId).HasColumnName("BoxTypeID");
            entity.Property(e => e.Depth).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Height).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Width).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Cabinet>(entity =>
        {
            entity.HasKey(e => e.CabinetId).HasName("PK__Cabinet__9C173EB359127449");

            entity.ToTable("Cabinet");

            entity.Property(e => e.CabinetId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CabinetID");
            entity.Property(e => e.CabinetTypeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CabinetTypeID");
            entity.Property(e => e.ControllerId).HasColumnName("ControllerID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");

            entity.HasOne(d => d.CabinetType).WithMany(p => p.Cabinets)
                .HasForeignKey(d => d.CabinetTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cabinet__Cabinet__571DF1D5");

            entity.HasOne(d => d.Controller).WithMany(p => p.Cabinets)
                .HasForeignKey(d => d.ControllerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cabinet__Control__59063A47");

            entity.HasOne(d => d.Customer).WithMany(p => p.Cabinets)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cabinet__Custome__5629CD9C");

            entity.HasOne(d => d.Location).WithMany(p => p.Cabinets)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cabinet__Locatio__5812160E");
        });

        modelBuilder.Entity<CabinetType>(entity =>
        {
            entity.HasKey(e => e.CabinetTypeId).HasName("PK__CabinetT__ADD80ABB27A50DC3");

            entity.ToTable("CabinetType");

            entity.Property(e => e.CabinetTypeId).HasColumnName("CabinetTypeID");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Command>(entity =>
        {
            entity.HasKey(e => e.CommandId).HasName("PK__Command__6B4108E61FFA6198");

            entity.ToTable("Command");

            entity.Property(e => e.CommandId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CommandID");
            entity.Property(e => e.CommandType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ControllerId).HasColumnName("ControllerID");
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Controller).WithMany(p => p.Commands)
                .HasForeignKey(d => d.ControllerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Command__Control__5DCAEF64");
        });

        modelBuilder.Entity<Controller>(entity =>
        {
            entity.HasKey(e => e.ControllerId).HasName("PK__Controll__5A8912B015B3C621");

            entity.ToTable("Controller");

            entity.Property(e => e.ControllerId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ControllerID");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(26)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");

            entity.HasOne(d => d.Location).WithMany(p => p.Controllers)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Controlle__Locat__5CD6CB2B");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B84B9D482E");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CustomerID");
            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Location).WithMany(p => p.Customers)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customer__Locati__5535A963");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PK__District__85FDA4A6FB8F6187");

            entity.ToTable("District");

            entity.Property(e => e.DistrictId).HasColumnName("DistrictID");
            entity.Property(e => e.DistrictName).HasMaxLength(50);
            entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

            entity.HasOne(d => d.Province).WithMany(p => p.Districts)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__District__Provin__52593CB8");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA477F0AE4FE1");

            entity.ToTable("Location");

            entity.Property(e => e.LocationId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("LocationID");
            entity.Property(e => e.LocationDetail).HasMaxLength(100);
            entity.Property(e => e.WardId).HasColumnName("WardID");

            entity.HasOne(d => d.Ward).WithMany(p => p.Locations)
                .HasForeignKey(d => d.WardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Location__WardID__5441852A");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.ProvinceId).HasName("PK__Province__FD0A6FA3B9A3A933");

            entity.ToTable("Province");

            entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");
            entity.Property(e => e.ProvinceName).HasMaxLength(50);
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.WardId).HasName("PK__Ward__C6BD9BEA0432376F");

            entity.ToTable("Ward");

            entity.Property(e => e.WardId).HasColumnName("WardID");
            entity.Property(e => e.DistrictId).HasColumnName("DistrictID");
            entity.Property(e => e.WardName).HasMaxLength(50);

            entity.HasOne(d => d.District).WithMany(p => p.Wards)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ward__DistrictID__534D60F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
