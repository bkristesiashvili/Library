using Library.Data.Entities;
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
        private IRepository<Customer> _customersRepo;
        private IRepository<Book> _booksRepo;

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
                EnsureDependencies();

                if (_authorsRepo == null)
                    _authorsRepo = new AuthorsRepository(_dbContext);
                return _authorsRepo;
            }
        }

        public IRepository<Genre> GenresRepository
        {
            get
            {
                EnsureDependencies();

                if (_genresRepo == null)
                    _genresRepo = new GenresRepository(_dbContext);
                return _genresRepo;
            }
        }

        public IRepository<Sector> SectorsRepository
        {
            get
            {
                EnsureDependencies();

                if (_sectorsRepo == null)
                    _sectorsRepo = new SectorsRepository(_dbContext);
                return _sectorsRepo;
            }
        }

        public IRepository<Section> SectionsRepository
        {
            get
            {
                EnsureDependencies();

                if (_sectionsRepo == null)
                    _sectionsRepo = new SectionsRepository(_dbContext);
                return _sectionsRepo;
            }
        }

        public IRepository<BookShelve> BookShelvesRepository
        {
            get
            {
                EnsureDependencies();

                if (_bookShelvessRepo == null)
                    _bookShelvessRepo = new BookShelvesRepository(_dbContext);
                return _bookShelvessRepo;
            }
        }

        public IRepository<Customer> CustomersRepository
        {
            get
            {
                EnsureDependencies();

                if (_customersRepo == null)
                    _customersRepo = new CustomersRepository(_dbContext);
                return _customersRepo;
            }
        }

        public IRepository<Book> BooksRepository
        {
            get
            {
                EnsureDependencies();

                if (_booksRepo == null)
                    _booksRepo = new BooksRepository(_dbContext);
                return _booksRepo;
            }
        }

        #endregion

        #region PUBLIC METHODS

        public void SaveChanges()
        {
            try
            {
                EnsureDependencies();

                _dbContext.SaveChanges();
            }
            catch { throw; }
        }

        #endregion

        #region PRIVATE METHODS

        private void EnsureDependencies()
        {
            if (_dbContext == null)
                throw new ArgumentNullException("DbContext object null refference exception!");
        }

        #endregion
    }
}
