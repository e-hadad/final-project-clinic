using System.Reflection.Emit;
using Clinic.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace clinic
{
    public class DataContext : DbContext
    {
        public DbSet<RoutesClass> ListRoutes { get; set; }
        public DbSet<DoctorClass> ListDoctors { get; set; }
        public DbSet<PatientClass> ListPatient { get; set; }
        public DbSet<UserClass> userClass { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8ED3CL9;Database=ClinicDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientClass>()
                .HasOne(c => c.User)
                .WithMany() // או WithOne אם זה 1:1
                .HasForeignKey(c => c.Id)
                .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה



            modelBuilder.Entity<DoctorClass>()
                .HasOne(d => d.User)
                .WithMany() // או WithOne אם זה 1:1
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה


            modelBuilder.Entity<UserClass>(b =>
            {
                b.Property(e => e.Role)
                    .HasConversion(
                        v => v.ToString(), // המרה לstring
                        v => Enum.Parse<eRole>(v)); // המרה חזרה לenum
            });




            modelBuilder.Entity<UserClass>(b =>
            {
                b.Property(e => e.Role)
                    .HasConversion(
                        v => v.ToString(), // המרה לstring
                        v => Enum.Parse<eRole>(v)); // המרה חזרה לenum
            });
            {
            }

        }
        /*        protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<PatientClass>()
                       .HasOne(c => c.User)
                       .WithMany() // או WithOne אם זה 1:1
                       .HasForeignKey(c => c.Id)
                       .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה

                    modelBuilder.Entity<DoctorClass>()
                      .HasOne(c => c.User)
                      .WithMany() // או WithOne אם זה 1:1
                      .HasForeignKey(c => c.Id)
                      .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה

                    modelBuilder.Entity<RoutesClass>()
                    .HasOne(c => c.Patient)
                    .WithMany() // או WithOne אם זה 1:1
                    .HasForeignKey(c => c.PatientId)
                    .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה

                    modelBuilder.Entity<RoutesClass>()
                  .HasOne(c => c.Doctor)
                  .WithMany() // או WithOne אם זה 1:1
                  .HasForeignKey(c => c.DoctorId)
                  .OnDelete(DeleteBehavior.Restrict); // הגבלת מחיקה

                    modelBuilder.Entity<UserClass>(b =>
                    {
                        b.Property(e => e.Role)
                            .HasConversion(
                                v => v.ToString(), // המרה לstring
                                v => Enum.Parse<eRole>(v)); // המרה חזרה לenum
                    });
                }*/

    }
};