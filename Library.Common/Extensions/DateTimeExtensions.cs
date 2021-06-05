using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common.Extensions
{
    public static class DateTimeExtensions
    {
        #region EXTENSION METHODS

        public static string ToDateString(this DateTime dateTime)
            => dateTime.ToString("dd/MM/yyyy");

        #endregion
    }
}
