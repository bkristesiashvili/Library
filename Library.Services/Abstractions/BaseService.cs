using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Abstractions
{
    public abstract class BaseService 
    {
        #region PROTECTED METHODS

        protected abstract void EnsureDependencies();

        #endregion
    }
}
