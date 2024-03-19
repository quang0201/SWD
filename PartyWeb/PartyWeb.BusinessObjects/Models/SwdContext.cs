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

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDecor> OrderDecors { get; set; }

    public virtual DbSet<OrderFood> OrderFoods { get; set; }

    public virtual DbSet<OrderRoom> OrderRooms { get; set; }

    public virtual DbSet<PartyHost> PartyHosts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =103.110.33.123; database = swd;uid=swd;pwd=123456789;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83F2BDA6CF1");

            entity.ToTable("account");

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(1000)
                .HasColumnName("address");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.DeletedTime).HasColumnName("deleted_time");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(1000)
                .HasColumnName("fullname");
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

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__feedback__7A6B2B8CEE93A5BD");

            entity.ToTable("feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");
            entity.Property(e => e.Content)
                .HasMaxLength(1000)
                .HasColumnName("content");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Stars).HasColumnName("stars");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__feedback__create__5070F446");
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
            entity.Property(e => e.Note)
                .HasColumnType("ntext")
                .HasColumnName("note");
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
            entity.Property(e => e.Status).HasColumnName("status ");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("money")
                .HasColumnName("total_price");

            entity.HasOne(d => d.IdDecorNavigation).WithMany(p => p.OrderDecors)
                .HasForeignKey(d => d.IdDecor)
                .HasConstraintName("fk_order_decor_decor_id");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderDecors)
                .HasForeignKey(d => d.IdOrder)
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
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("money")
                .HasColumnName("total_price");

            entity.HasOne(d => d.IdFoodNavigation).WithMany(p => p.OrderFoods)
                .HasForeignKey(d => d.IdFood)
                .HasConstraintName("fk_order_food_food_id");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderFoods)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("fk_order_food_order_id");
        });

        modelBuilder.Entity<OrderRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_ro__3213E83FF864F977");

            entity.ToTable("order_room");

            entity.HasIndex(e => e.IdOrder, "id_order_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdRoom).HasColumnName("id_room");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("money")
                .HasColumnName("total_price");

            entity.HasOne(d => d.IdOrderNavigation).WithOne(p => p.OrderRoom)
                .HasForeignKey<OrderRoom>(d => d.IdOrder)
                .HasConstraintName("fk_order_room_order_id");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.OrderRooms)
                .HasForeignKey(d => d.IdRoom)
                .HasConstraintName("fk_order_room_room_id");
        });

        modelBuilder.Entity<PartyHost>(entity =>
        {
            entity.HasKey(e => e.PartyHostId).HasName("PK__party_ho__F491A0BBB9A5A2F0");

            entity.ToTable("party_host");

            entity.Property(e => e.PartyHostId).HasColumnName("party_host_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EndedTime)
                .HasColumnType("datetime")
                .HasColumnName("ended_time");
            entity.Property(e => e.NumberOfPeople).HasColumnName("number_of_people");
            entity.Property(e => e.PartyHostDetails)
                .HasMaxLength(1000)
                .HasColumnName("party_host_details");
            entity.Property(e => e.PartyHostTitle)
                .HasMaxLength(1000)
                .HasColumnName("party_host_title");
            entity.Property(e => e.StartedTime)
                .HasColumnType("datetime")
                .HasColumnName("started_time");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PartyHosts)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__party_hos__creat__59063A47");
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

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__status__3213E83FD3D5B31E");

            entity.ToTable("status");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
