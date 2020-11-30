﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using windows_backend.Models;

namespace windows_backend.Data.Mappers
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            
            builder.HasKey(c => c.id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.Items);
        }
    }
}
