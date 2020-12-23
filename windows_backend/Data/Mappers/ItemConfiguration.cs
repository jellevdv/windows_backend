using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using windows_backend.Models;

namespace windows_backend.Data.Mappers
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.HasKey(i => i.id);

            builder.Property(i => i.Name).IsRequired().HasMaxLength(50);
            builder.HasMany(t => t.Tasks).WithOne(x => x.Item);
          //  builder.Property(i => i.Tasks);
        }
    }
}
