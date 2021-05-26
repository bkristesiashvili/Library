using Library.Common.Responses;
using Library.Data.Repositories.Uow.Abstractions;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Abstractions
{
    public abstract class BaseService 
    {
        #region PROTECTED PROPERTIES

        protected IUnitOfWorks UnitOfWorks { get; }

        #endregion

        #region CTOR

        public BaseService(IUnitOfWorks uow)
            => UnitOfWorks = uow;

        #endregion

        #region PROTECTED METHODS

        protected abstract void EnsureDependencies();

        protected static ServiceResult ServiceResult(bool succeed, Exception error = null)
        {
            return new ServiceResult
            {
                Succeed = succeed,
                Error = error
            };
        }

        #endregion
    }
}
