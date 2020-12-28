using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using windows_backend.Models;

namespace windows_backend.Data.Mappers
{
    public class TaskConfiguration : IEntityTypeConfiguration<ItemTask>
    {
        public void Configure(EntityTypeBuilder<ItemTask> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Description)
                .IsRequired();

            builder.Property(t => t.IsDone)
                .IsRequired();

            builder.HasOne(t => t.Item)
                .WithMany(i => i.Tasks)
                .HasForeignKey(t => t.ItemId);

        }
    }
}
