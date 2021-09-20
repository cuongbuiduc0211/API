using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DatabaseAccess.Entities
{
    public partial class CarWorldContext : DbContext
    {
        public CarWorldContext()
        {
        }

        public CarWorldContext(DbContextOptions<CarWorldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accessory> Accessories { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarAccessory> CarAccessories { get; set; }
        public virtual DbSet<Contest> Contests { get; set; }
        public virtual DbSet<ContestPrize> ContestPrizes { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<ExchangeAccessorryDetail> ExchangeAccessorryDetails { get; set; }
        public virtual DbSet<ExchangeAccessory> ExchangeAccessories { get; set; }
        public virtual DbSet<ExchangeCar> ExchangeCars { get; set; }
        public virtual DbSet<ExchangeCarDetail> ExchangeCarDetails { get; set; }
        public virtual DbSet<ExchangeResponse> ExchangeResponses { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Prize> Prizes { get; set; }
        public virtual DbSet<Proposal> Proposals { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserContest> UserContests { get; set; }
        public virtual DbSet<UserEvent> UserEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=cosplane.asia;Database=CarWorld;User Id=buicuong;Password=BuiCuong!@#123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Accessory>(entity =>
            {
                entity.ToTable("Accessory");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Accessories)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accessory_Brand");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.HasIndex(e => e.Name, "UQ__Brand__737584F69CC4B6C1")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Image).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.HasIndex(e => e.Name, "UQ__Car__737584F672718C61")
                    .IsUnique();

                entity.Property(e => e.BodyType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EngineType).HasMaxLength(100);

                entity.Property(e => e.FogLamps).HasMaxLength(50);

                entity.Property(e => e.GearBox).HasMaxLength(100);

                entity.Property(e => e.HeadLights).HasMaxLength(50);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.InteriorMaterial).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TailLights).HasMaxLength(50);

                entity.Property(e => e.TyreSize).HasMaxLength(100);

                entity.Property(e => e.WheelSize).HasMaxLength(100);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_Brand");
            });

            modelBuilder.Entity<CarAccessory>(entity =>
            {
                entity.ToTable("Car_Accessory");

                entity.HasOne(d => d.Accessory)
                    .WithMany(p => p.CarAccessories)
                    .HasForeignKey(d => d.AccessoryId)
                    .HasConstraintName("FK_Car_Accessory_Accessory");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.CarAccessories)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK_Car_Accessory_Car");
            });

            modelBuilder.Entity<Contest>(entity =>
            {
                entity.ToTable("Contest");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EndRegister).HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartRegister).HasColumnType("datetime");

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.Venue).IsRequired();

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.ContestManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contest_Users");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.ContestModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Contest_Modifier");

                entity.HasOne(d => d.Proposal)
                    .WithMany(p => p.Contests)
                    .HasForeignKey(d => d.ProposalId)
                    .HasConstraintName("FK_Contest_Proposal");
            });

            modelBuilder.Entity<ContestPrize>(entity =>
            {
                entity.ToTable("Contest_Prize");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Contest)
                    .WithMany(p => p.ContestPrizes)
                    .HasForeignKey(d => d.ContestId)
                    .HasConstraintName("FK_Contest_Prize_Contest");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.ContestPrizeManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Contest_Prize_Manager");

                entity.HasOne(d => d.Prize)
                    .WithMany(p => p.ContestPrizes)
                    .HasForeignKey(d => d.PrizeId)
                    .HasConstraintName("FK_Contest_Prize_Prize");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ContestPrizeUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Contest_Prize_Users");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EndRegister).HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartRegister).HasColumnType("datetime");

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.Venue).IsRequired();

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.EventManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Users");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.EventModifiedByNavigations)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_Event_Modifier");

                entity.HasOne(d => d.Proposal)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ProposalId)
                    .HasConstraintName("FK_Event_Proposal");
            });

            modelBuilder.Entity<ExchangeAccessorryDetail>(entity =>
            {
                entity.ToTable("ExchangeAccessorryDetail");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.ExchangeAccessory)
                    .WithMany(p => p.ExchangeAccessorryDetails)
                    .HasForeignKey(d => d.ExchangeAccessoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExchangeAccessorryDetail_ExchangeAccessory");
            });

            modelBuilder.Entity<ExchangeAccessory>(entity =>
            {
                entity.ToTable("ExchangeAccessory");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Feedback)
                    .WithMany(p => p.ExchangeAccessories)
                    .HasForeignKey(d => d.FeedbackId)
                    .HasConstraintName("FK_ExchangeAccessory_Feedback");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExchangeAccessories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExchangeAccessory_Users");
            });

            modelBuilder.Entity<ExchangeCar>(entity =>
            {
                entity.ToTable("ExchangeCar");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Feedback)
                    .WithMany(p => p.ExchangeCars)
                    .HasForeignKey(d => d.FeedbackId)
                    .HasConstraintName("FK_Exchange_Feedback");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExchangeCars)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exchange_Users");
            });

            modelBuilder.Entity<ExchangeCarDetail>(entity =>
            {
                entity.ToTable("ExchangeCarDetail");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LicensePlate)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ExchangeCar)
                    .WithMany(p => p.ExchangeCarDetails)
                    .HasForeignKey(d => d.ExchangeCarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExchangeCarDetail_ExchangeCar");
            });

            modelBuilder.Entity<ExchangeResponse>(entity =>
            {
                entity.ToTable("ExchangeResponse");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ExchangeAccessory)
                    .WithMany(p => p.ExchangeResponses)
                    .HasForeignKey(d => d.ExchangeAccessoryId)
                    .HasConstraintName("FK_ExchangeResponse_ExchangeAccessory");

                entity.HasOne(d => d.ExchangeCar)
                    .WithMany(p => p.ExchangeResponses)
                    .HasForeignKey(d => d.ExchangeCarId)
                    .HasConstraintName("FK_ExchangeResponse_ExchangeCar");

                entity.HasOne(d => d.Feedback)
                    .WithMany(p => p.ExchangeResponses)
                    .HasForeignKey(d => d.FeedbackId)
                    .HasConstraintName("FK_ExchangeResponse_Feedback");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExchangeResponses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExchangeResponse_Users");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackDate).HasColumnType("datetime");

                entity.Property(e => e.ReplyDate).HasColumnType("datetime");

                entity.HasOne(d => d.FeedbackUser)
                    .WithMany(p => p.FeedbackFeedbackUsers)
                    .HasForeignKey(d => d.FeedbackUserId)
                    .HasConstraintName("FK_Feedback_Users");

                entity.HasOne(d => d.ReplyUser)
                    .WithMany(p => p.FeedbackReplyUsers)
                    .HasForeignKey(d => d.ReplyUserId)
                    .HasConstraintName("FK_ReplyFeedback_User");
            });

            modelBuilder.Entity<Prize>(entity =>
            {
                entity.ToTable("Prize");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Proposal>(entity =>
            {
                entity.ToTable("Proposal");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.ProposalManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proposal_Approver");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProposalUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proposal_Users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Role");
            });

            modelBuilder.Entity<UserContest>(entity =>
            {
                entity.ToTable("User_Contest");

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.HasOne(d => d.Contest)
                    .WithMany(p => p.UserContests)
                    .HasForeignKey(d => d.ContestId)
                    .HasConstraintName("FK_User_Contest_Contest");

                entity.HasOne(d => d.Feedback)
                    .WithMany(p => p.UserContests)
                    .HasForeignKey(d => d.FeedbackId)
                    .HasConstraintName("FK_User_Contest_Feedback");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserContests)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Contest_Users");
            });

            modelBuilder.Entity<UserEvent>(entity =>
            {
                entity.ToTable("User_Event");

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.UserEvents)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_User_Event_Event");

                entity.HasOne(d => d.Feedback)
                    .WithMany(p => p.UserEvents)
                    .HasForeignKey(d => d.FeedbackId)
                    .HasConstraintName("FK_User_Event_Feedback");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEvents)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Event_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
