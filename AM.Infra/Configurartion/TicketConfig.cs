using Am.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infra.Configurartion
{
    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => new { t.PassengerFK, t.FlightFK });

            builder.HasOne(t => t.Passenger)
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.PassengerFK);

            builder.HasOne(t => t.Flight)
                .WithMany(f => f.Tickets)
                .HasForeignKey(t => t.FlightFK);
        }
    }
}
