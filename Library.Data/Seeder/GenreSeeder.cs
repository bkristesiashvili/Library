using Library.Data.Entities;
using Library.Data.Seeder.Abstractions;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Seeder
{
    public sealed class GenreSeeder : IDataSeeder<Genre>
    {
        public IReadOnlyList<Genre> ExecuteSeeder() => new List<Genre>
        {
            new Genre { Id = Guid.NewGuid(), Name ="ავტობიოგრაფია"},
            new Genre { Id = Guid.NewGuid(), Name ="ბიოგრაფია"},
            new Genre { Id = Guid.NewGuid(), Name ="ბელეტრისტიკა"},
            new Genre { Id = Guid.NewGuid(), Name ="პროზა"},
            new Genre { Id = Guid.NewGuid(), Name ="რომანი"},
            new Genre { Id = Guid.NewGuid(), Name ="დეტექტივი"},
            new Genre { Id = Guid.NewGuid(), Name ="დრამა"},
        }.AsReadOnly();
    }
}
