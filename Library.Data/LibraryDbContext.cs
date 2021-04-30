using Library.Data.Entities;
using Library.Data.Entities.Configurations;
using Library.Data.Extensions;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data
{
    public sealed class LibraryDbContext 
        : IdentityDbContext<User, Role, Guid>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthorEntityConfigurations());
            builder.ApplyConfiguration(new BookEntityConfigurations());
            builder.ApplyConfiguration(new GenreEntityConfigurations());
            builder.ApplyConfiguration(new BookShelveEntityConfigurations());
            builder.ApplyConfiguration(new SectorEntityConfigurations());

            builder.SeedSystemRoles();

            base.OnModelCreating(builder);
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<AuthoredBooks> AuthoredBooks { get; set; }
    }
}
