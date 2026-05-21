using Am.ApplicationCore.Domain;
using AM.Infra.Configurartion;
using Microsoft.EntityFrameworkCore;

namespace AM.Infra;

public class AMContext : DbContext
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

                Initial Catalog=ACC3;

                Integrated Security=true;

                MultipleActiveResultSets=true");


        base.OnConfiguring(optionsBuilder);

    }

    //Configuration fluent API pour les entités de notre application
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new FlightConfig());
        modelBuilder.ApplyConfiguration(new PlaneConfig());
        //TPH(Table Per Hierarchy)
        //modelBuilder.Entity<Passenger>()
        //    .HasDiscriminator<int>("PassengerType")
        //    .HasValue<Passenger>(0)
        //    .HasValue<Traveller>(1)
        //    .HasValue<Staff>(2);

        //TPT(Table Per Type)
        modelBuilder.Entity<Staff>().ToTable("Staffs");
        modelBuilder.Entity<Traveller>().ToTable("Travellers");
    }

    //Configuration convention
    override protected void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<string>().HaveMaxLength(100);
    }

}
