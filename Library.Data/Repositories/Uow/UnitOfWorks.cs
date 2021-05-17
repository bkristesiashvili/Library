﻿using Library.Data.Entities;
using Library.Data.Repositories.Abstractions;
using Library.Data.Repositories.Uow.Abstractions;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data.Repositories.Uow
{
    public sealed class UnitOfWorks : IUnitOfWorks
    {
        #region PRIVATE FIELDS

        private readonly LibraryDbContext _dbContext;

        private IRepository<Author> _authorsRepo;
        private IRepository<Genre> _genresRepo;
        private IRepository<Sector> _sectorsRepo;
        private IRepository<Section> _sectionsRepo;
        private IRepository<BookShelve> _bookShelvessRepo;

        #endregion

        #region CTOR

        public UnitOfWorks(LibraryDbContext context)
            => _dbContext = context;

        #endregion

        #region PUBLIC PROPERTIES

        public IRepository<Author> AuthorsRepository
        {
            get
            {
                if (_authorsRepo == null)
                    _authorsRepo = new AuthorsRepository(_dbContext);
                return _authorsRepo;
            }
        }

        public IRepository<Genre> GenresRepository
        {
            get
            {
                if (_genresRepo == null)
                    _genresRepo = new GenresRepository(_dbContext);
                return _genresRepo;
            }
        }

        public IRepository<Sector> SectorsRepository
        {
            get
            {
                if (_sectorsRepo == null)
                    _sectorsRepo = new SectorsRepository(_dbContext);
                return _sectorsRepo;
            }
        }

        public IRepository<Section> SectionsRepository
        {
            get
            {
                if (_sectionsRepo == null)
                    _sectionsRepo = new SectionsRepository(_dbContext);
                return _sectionsRepo;
            }
        }

        public IRepository<BookShelve> BookShelvesRepository
        {
            get
            {
                if (_bookShelvessRepo == null)
                    _bookShelvessRepo = new BookShelvesRepository(_dbContext);
                return _bookShelvessRepo;
            }
        }

        #endregion
    }
}