using static Library.Common.GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Library.WebApp.Helpers.Attributes
{
    public sealed class InputSanitizationAttribute : ValidationAttribute, IClientModelValidator
    {
        #region CONSTANTS

        private const string REGEX_PATTERN = "<[^>]*(>|$)";

        #endregion

        #region OVERRIDED METHODS

        public override bool IsValid(object value)
        {
            if (value == null) return false;

            if (value.GetType() != typeof(string))
                return false;

            if (!Regex.IsMatch(value.ToString(), REGEX_PATTERN))
                return true;

            return false;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            ErrorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            MergeAttribute(context.Attributes, "data-val-sanitization", ErrorMessage);
        }

        #endregion

        #region PRIVATE METHODS

        private bool MergeAttribute(IDictionary<string, string> attributes,
            string key,
            string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }

        #endregion
    }
}
