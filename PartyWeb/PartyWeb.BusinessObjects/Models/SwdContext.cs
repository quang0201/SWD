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

    public virtual DbSet<PartyPost> PartyPosts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=SWD;User ID=sa;Password=12345;Trusted_Connection=True;Trust Server Certificate=True;Timeout=30;");

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

        modelBuilder.Entity<PartyPost>(entity =>
        {
            entity.HasKey(e => e.PartyPostId).HasName("PK__party_po__F46F9EEC8C477DD2");

            entity.ToTable("party_post");

            entity.Property(e => e.PartyPostId).HasColumnName("party_post_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime)
                .HasColumnType("datetime")
                .HasColumnName("created_time");
            entity.Property(e => e.PartyPostDetails).HasColumnName("party_post_details");
            entity.Property(e => e.PartyPostTitle).HasColumnName("party_post_title");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.PartyPosts)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__party_pos__creat__6383C8BA");
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
