using Am.ApplicationCore.Domain;
using AM.Infra.Configurartion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Infra
{
    public class AMContext: DbContext
    {
        //Les entités que nous allons manipuler dans notre application
        public DbSet<Flight> Flights { get; set; }

        public DbSet<Plane> Planes { get; set; }

        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Traveller> Travellers { get; set; }

        // Chaine de connexion à la base de données
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer

              (@"Data Source=(localdb)\mssqllocaldb;

                Initial Catalog=ACC;

                Integrated Security=true;

                MultipleActiveResultSets=true");


            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FlightConfig());
            modelBuilder.ApplyConfiguration(new PlaneConfig());
        }

    }
}
