using Microsoft.EntityFrameworkCore;
using webapi.EF.Models;

namespace webapi.EF
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options) { }
        public DbSet<EnumWorkType> WorkTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Location> Locations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.EnableSensitiveDataLogging(false);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnumWorkType>(entity =>
            {
                entity.ToTable("enum.Work.Type");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.LocationId)
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                entity.Property(e => e.WorkTypeId)
                    .HasColumnType("tinyint");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted)
                    .HasColumnType("bit")
                    .HasDefaultValue(false);

                // Foreign key to EnumWorkType
                entity.HasOne(e => e.WorkType)
                    .WithMany(w => w.Contacts)
                    .HasForeignKey(e => e.WorkTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Contact_enum.Work.Type");

                // Foreign key to Location
                entity.HasOne(e => e.Location)
                    .WithMany(l => l.Contacts)
                    .HasForeignKey(e => e.LocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Contact_Location");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted)
                    .HasColumnType("bit")
                    .HasDefaultValue(false);

                entity.HasMany(e => e.Contacts)
                    .WithOne(c => c.Location)
                    .HasForeignKey(c => c.LocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Contact_Location");
            });

            // --- Configure Contact
            var contact1Id = new Guid("d3351cd6-bd41-4892-8629-4404fa6f46a8");

            // --- Configure Location
            var location1Id = new Guid("f27c04d5-53e7-4962-9d68-604034a044c7");
            var location2Id = new Guid("5cd999ba-d860-4071-8132-375fe49f27f1");

            // --- SEED DATA ---
            modelBuilder.Entity<EnumWorkType>().HasData(
                new EnumWorkType { Id = 1, Name = "Engineer" },
                new EnumWorkType { Id = 2, Name = "Designer" },
                new EnumWorkType { Id = 3, Name = "Manager" }
            );

            var contact1 = new Contact
            {
                Id = contact1Id,
                Email = "juan@example.com",
                FullName = "Juan Dela Cruz",
                MobileNumber = "09171234567",
                LocationId = location1Id,
                WorkTypeId = 1,
                CreatedAt = new DateTime(2025, 1, 1),
                IsDeleted = false
            };

            var location1 = new Location
            {
                Id = location1Id,
                City = "Cebu City",
                Country = "Philippines",
                CreatedAt = new DateTime(2025, 1, 1),
                IsDeleted = false
            };

            var location2 = new Location
            {
                Id = location2Id,
                City = "Davao City",
                Country = "Philippines",
                CreatedAt = new DateTime(2025, 1, 1),
                IsDeleted = false
            };

            modelBuilder.Entity<Contact>().HasData(contact1);

            modelBuilder.Entity<Location>().HasData(location1, location2);
        }
    }
}
