using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cw_11.Models
{
    public class HospitalContext : DbContext
    {

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        public HospitalContext(DbContextOptions options) : base(options)
        {

        }

        //zad1 - seedowanie danych

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                IdDoctor = 1,
                FirstName = "Ferdek",
                LastName = "Kiepski",
                Email = "ferdekKiepski@gmail.com"
            });

            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                IdPatient = 1,
                FirstName = "Marian",
                LastName = "Pazdzioch",
                BirthDate = DateTime.Now
            });

            modelBuilder.Entity<Prescription>().HasData(new Prescription
            {
                IdPrescription = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddDays(2),
                IdPatient = 1,
                IdDoctor = 1
            });




        }

    }
}
