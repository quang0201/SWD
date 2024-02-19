using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects.Models;

public partial class PartyContext : DbContext
{
    public PartyContext()
    {
    }

    public PartyContext(DbContextOptions<PartyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Decor> Decors { get; set; }

    public virtual DbSet<FeedBack> FeedBacks { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Tran> Trans { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83F2BDA6CF1");

            entity.ToTable("Account");

            entity.HasIndex(e => e.IdNumber, "number").IsUnique();

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_number");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Decor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Decor__3213E83FA0308936");

            entity.ToTable("Decor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
        });

        modelBuilder.Entity<FeedBack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FeedBack__3213E83F6043647A");

            entity.ToTable("FeedBack");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.IdParty)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_party");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Food__3213E83F0641FA08");

            entity.ToTable("Food");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Quality).HasColumnName("quality");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3213E83F14AF5DB6");

            entity.ToTable("Order");

            entity.HasIndex(e => e.IdNumber, "number_order").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ActualPrice)
                .HasColumnType("money")
                .HasColumnName("actual_price");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.IdNumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_number");
            entity.Property(e => e.ListDecor)
                .HasColumnType("text")
                .HasColumnName("list_decor");
            entity.Property(e => e.ListFood)
                .HasColumnType("text")
                .HasColumnName("list_food");
            entity.Property(e => e.Note)
                .HasColumnType("ntext")
                .HasColumnName("note");
            entity.Property(e => e.PrePrice)
                .HasColumnType("money")
                .HasColumnName("pre_price");
            entity.Property(e => e.Room)
                .HasColumnType("text")
                .HasColumnName("room");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Package__3213E83FA519874B");

            entity.ToTable("Package");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(1)
                .HasColumnName("content");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Party__3213E83F57A5724C");

            entity.ToTable("Party");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3213E83F15738CFD");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("content");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.IdPayment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_payment");
            entity.Property(e => e.Money)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("money");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Int).HasName("PK__Room__DC50F6D88CA75E56");

            entity.ToTable("Room");

            entity.HasIndex(e => e.Number, "numberr").IsUnique();

            entity.Property(e => e.Int).HasColumnName("int");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.MaxCapacity).HasColumnName("max_capacity");
            entity.Property(e => e.Number)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
        });

        modelBuilder.Entity<Tran>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trans__3213E83F3CBCFE47");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.IdOrder)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_order");
            entity.Property(e => e.IdPayment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_payment");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Voucher__3213E83F372D42F3");

            entity.ToTable("Voucher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("deleted_by");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
