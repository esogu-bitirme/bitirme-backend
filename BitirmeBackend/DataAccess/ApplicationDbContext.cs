using Entities;
using Entities.Modals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        public DbSet<Image> Images { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public ApplicationDbContext()
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique(); //todo : doesn't work Idk why
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Doctor>().HasIndex(u => u.Tckn).IsUnique();
            modelBuilder.Entity<Doctor>().HasIndex(u => u.PhoneNumber).IsUnique();
            modelBuilder.Entity<Patient>().HasIndex(u => u.Tckn).IsUnique();
            modelBuilder.Entity<Patient>().HasIndex(u => u.PhoneNumber).IsUnique(); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=bitirme;Username=postgres;Password=admin");

        }
    }
}
