using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebApp.Helpers.Extensions
{
    public static class DateTimeExtensions
    {
        #region EXTENSION METHODS

        public static string ToDateString(this DateTime dateTime)
            => dateTime.ToString("dd/MM/yyyy");

        #endregion
    }
}
