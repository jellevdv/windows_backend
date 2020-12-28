using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using windows_backend.Models;

namespace windows_backend.Data.Mappers
{
    public class HolidayConfiguration : IEntityTypeConfiguration<Holiday>
    {
        public void Configure(EntityTypeBuilder<Holiday> builder)
        {
            builder.ToTable("Holiday");
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(h => h.Description)
                .IsRequired();

            builder.Property(h => h.Destination)
                .IsRequired();

            builder.Property(h => h.DepartureDate)
                .IsRequired();

            //  builder.Property(h => h.Users);           
        }
    }
}
