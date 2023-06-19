using Entities;
using Entities.Modals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


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

        private readonly IConfiguration configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public ApplicationDbContext()
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Doctor>().HasIndex(u => u.Tckn).IsUnique();
            modelBuilder.Entity<Doctor>().HasIndex(u => u.PhoneNumber).IsUnique();
            modelBuilder.Entity<Patient>().HasIndex(u => u.Tckn).IsUnique();
            modelBuilder.Entity<Patient>().HasIndex(u => u.PhoneNumber).IsUnique(); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
                //optionsBuilder.UseNpgsql(configuration["database"]);
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=bitirme;Username=postgres;Password=654525");
        }
    }
}
