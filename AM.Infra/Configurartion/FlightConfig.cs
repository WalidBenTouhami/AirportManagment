using Am.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AM.Infra.Configurartion
{
    public class FlightConfig : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {


            builder.HasOne(f => f.Plane)
                .WithMany(p => p.Flights)
                .HasForeignKey(f => f.PlaneFK)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
