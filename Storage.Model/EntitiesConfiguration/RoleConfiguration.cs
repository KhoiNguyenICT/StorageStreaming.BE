using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storage.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Model.EntitiesConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //builder.HasMany<Permission>(x => x.Permissions).WithMany;
                //.WithMany(x => x.FilmTags)
                //.HasForeignKey(x => x.);

            //builder.HasOne(x => x.Tag)
            //    .WithMany(x => x.FilmTags)
            //    .HasForeignKey(x => x.TagId);
        }
    }
}
