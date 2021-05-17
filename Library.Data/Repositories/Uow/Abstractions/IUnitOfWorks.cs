using Library.Data.Entities;
using Library.Data.Repositories.Abstractions;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Repositories.Uow.Abstractions
{
    public interface IUnitOfWorks
    {
        #region PROPERTIES

        IRepository<Author> AuthorsRepository { get; }

        IRepository<Genre> GenresRepository { get; }

        IRepository<Sector> SectorsRepository { get; }

        IRepository<Section> SectionsRepository { get; }

        IRepository<BookShelve> BookShelvesRepository { get; }

        #endregion
    }
}
