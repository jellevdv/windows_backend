using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using windows_backend.Models;

namespace windows_backend.Data.Mappers
{
    public class TaskConfiguration : IEntityTypeConfiguration<ItemTask>
    {
        public void Configure(EntityTypeBuilder<ItemTask> builder)
        {
            builder.HasKey(t => t.id);

            builder.Property(t => t.Description).IsRequired();
            builder.Property(t => t.IsDone).IsRequired();

        }
    }
}
