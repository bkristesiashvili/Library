using Library.Data.Entities;
using Library.Data.Entities.Abstractions;
using Library.Data.Entities.Configurations;
using Library.Data.Extensions;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Data
{
    public sealed class LibraryDbContext
        : IdentityDbContext<User, Role, Guid>
    {
        #region CTOR

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options) { }

        #endregion

        #region OVERRIDED METHODS

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthorEntityConfigurations());
            builder.ApplyConfiguration(new BookEntityConfigurations());
            builder.ApplyConfiguration(new GenreEntityConfigurations());
            builder.ApplyConfiguration(new BookShelveEntityConfigurations());
            builder.ApplyConfiguration(new SectorEntityConfigurations());
            builder.ApplyConfiguration(new SectionEntityConfigurations());
            builder.ApplyConfiguration(new CustomerEntityConfigurations());


            builder.SeedSystemRoles();

            base.OnModelCreating(builder);
        }

        #endregion

        #region DBSETS

        public DbSet<Author> Authors { get; set; }

        public DbSet<AuthoredBooks> AuthoredBooks { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<BookGenres> BookGenres { get; set; }

        public DbSet<BooksBookshelve> ShelvesOfBook { get; set; }

        public DbSet<BorrowedBook> BorrowedBooks { get; set; }

        public DbSet<Sector> Sectors { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<BookShelve> BookShelves { get; set; }

        public DbSet<Customer> Customers { get; set; }

        #endregion

        #region UNUSED OVERRIDED METHOD

        //public override int SaveChanges()
        //{
        //    //var entries = ChangeTracker.Entries()
        //    //    .Where(entry => entry.Entity is BaseEntity &&
        //    //                    entry.State == EntityState.Modified ||
        //    //                    entry.State == EntityState.Deleted);

        //    //foreach (var entry in entries)
        //    //{
        //    //    if (entry.State == EntityState.Modified)
        //    //    {
        //    //        ((BaseEntity)entry.Entity).UpdatedAt = DateTime.Now;
        //    //        ((BaseEntity)entry.Entity).CreatedAt = entry.OriginalValues.GetValue<DateTime>("CreatedAt");
        //    //    }
        //    //    else if (entry.State == EntityState.Deleted)
        //    //    {
        //    //        ((BaseEntity)entry.Entity).CreatedAt = entry.OriginalValues.GetValue<DateTime>("CreatedAt");
        //    //        ((BaseEntity)entry.Entity).UpdatedAt = entry.OriginalValues.GetValue<DateTime>("UpdatedAt");
        //    //        ((BaseEntity)entry.Entity).DeletedAt = DateTime.Now;
        //    //    }
        //    //}

        //    return base.SaveChanges();
        //}

        #endregion
    }
}
