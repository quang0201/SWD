using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessObjects.Models;

public partial class SwdContext : DbContext
{
    public SwdContext()
    {
    }

    public SwdContext(DbContextOptions<SwdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Decor> Decors { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDecor> OrderDecors { get; set; }

    public virtual DbSet<OrderFood> OrderFoods { get; set; }

    public virtual DbSet<OrderRoom> OrderRooms { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server =localhost; database = swd;uid=sa;pwd=sa;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83F2BDA6CF1");

            entity.ToTable("account");

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Infomation)
                .HasColumnType("ntext")
                .HasColumnName("infomation");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_account_role_id");
        });

        modelBuilder.Entity<Decor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__food__3213E83F0AE3A13E_copy_1_copy_1");

            entity.ToTable("decor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Decors)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("fk_decor_account_id");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__food__3213E83F0AE3A13E");

            entity.ToTable("food");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Foods)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_food_account_id");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__food__3213E83F0AE3A13E_copy_1_copy_1_copy_1");

            entity.ToTable("order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("fk_order_account_id");
        });

        modelBuilder.Entity<OrderDecor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_de__3213E83FCF2C3A66");

            entity.ToTable("order_decor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDecor).HasColumnName("id_decor");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.Quality).HasColumnName("quality");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("money")
                .HasColumnName("total_price");

            entity.HasOne(d => d.IdDecorNavigation).WithMany(p => p.OrderDecors)
                .HasForeignKey(d => d.IdDecor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_decor_decor_id");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderDecors)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_decor_order_id");
        });

        modelBuilder.Entity<OrderFood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_fo__3213E83FBA641C1D");

            entity.ToTable("order_food");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdFood).HasColumnName("id_food");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.Quality).HasColumnName("quality");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("money")
                .HasColumnName("total_price");

            entity.HasOne(d => d.IdFoodNavigation).WithMany(p => p.OrderFoods)
                .HasForeignKey(d => d.IdFood)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_food_food_id");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderFoods)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_food_order_id");
        });

        modelBuilder.Entity<OrderRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_ro__3213E83FF864F977");

            entity.ToTable("order_room");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdRoom).HasColumnName("id_room");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("money")
                .HasColumnName("total_price");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderRooms)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_room_order_id");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.OrderRooms)
                .HasForeignKey(d => d.IdRoom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_room_room_id");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__role__3213E83F6E9CDBB5");

            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__food__3213E83F0AE3A13E_copy_1");

            entity.ToTable("room");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("content");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedTime).HasColumnName("updated_time");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("fk_room_account_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
