using Microsoft.EntityFrameworkCore;
using webapi.EF.Models;

namespace webapi.EF
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options) { }
        public DbSet<EnumWorkType> WorkTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.EnableSensitiveDataLogging(false);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.MobileNumber).IsRequired().HasMaxLength(15);
                entity.Property(e => e.Location).IsRequired().HasMaxLength(100);
                entity.Property(e => e.WorkType).IsRequired().HasMaxLength(50);
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.WorkTypeId);
                entity.HasOne(e => e.WorkType)
                    .WithOne(e => e.Contact)
                    .HasForeignKey<Contact>(e => e.WorkTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Contact_enum.Work.Type");
            });

            modelBuilder.Entity<EnumWorkType>(entity =>
            {
                entity.ToTable("enum.Work.Type");
                entity.Property(e => e.Id)
                    .HasColumnType("tinyint")
                    .ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)");
            });
        }
    }
}
