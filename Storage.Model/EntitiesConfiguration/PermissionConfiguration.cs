using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Model.EntitiesConfiguration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            //builder.HasMany<Role>(s=>s.Roles);

            ////builder.HasOne(x => x.Tag)
            ////    .WithMany(x => x.FilmTags)
            ////    .HasForeignKey(x => x.TagId);
        }
    }
}
