using Entities;
using Entities.Modals;
using Microsoft.EntityFrameworkCore;


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
    }
}
