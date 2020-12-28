using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using windows_backend.Models;

namespace windows_backend.Data.Mappers
{
    public class HolidayCategoryConfiguration : IEntityTypeConfiguration<HolidayCategory>
    {
        public void Configure(EntityTypeBuilder<HolidayCategory> builder)
        {
            builder.HasKey(h => new { h.HolidayId, h.CategoryId });

            builder.ToTable("HOLIDAY_CATEGORY");

            builder.Property(hc => hc.HolidayId)
                .HasColumnName("HolidayId")
                .HasColumnType("numeric(19, 0)");

            builder.Property(hc => hc.CategoryId)
                .HasColumnName("CategoryId")
                .HasColumnType("numeric(19, 0)");

            builder.HasOne(hc => hc.Holiday)
                .WithMany(h => h.Categories)
                .HasForeignKey(hc => hc.HolidayId);

            builder.HasOne(hc => hc.Category)
                .WithMany(c => c.Holidays)
                .HasForeignKey(hc => hc.CategoryId);
        }
    }
}
