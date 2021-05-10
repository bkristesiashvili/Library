using Library.Common.Enums;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common
{
    public static class GlobalVariables
    {
        public static readonly IReadOnlyDictionary<SystemDefaultRoles, string> DefaultRoles =
            new Dictionary<SystemDefaultRoles, string>
            {
                { SystemDefaultRoles.SuperAdmin, "SuperAdmin" },
                { SystemDefaultRoles.Admin, "Admin" },
                { SystemDefaultRoles.User, "User" }
            };

        public const string SystemUserAuthEmail = "admin@library.app";
        public const string SystemUserAuthPass = "@admin1234!";

        public const string EmailErrorMessage = "ელ.ფოსტის ველი აუცილებელია!";
        public const string EmailConfirmErrorMessage = "ელ.ფოსტის დადასტურება აუცილებელია!";
        public const string EmailMismatchErrorMesssage = "ელ.ფოსტა არ ემთხვევა ერთმანეთს!";
        public const string EmailFormatError = "არასწორი ელ.ფოსტის მისამართი!";

        public const string FirstNameRequiredErrorMessage = "სახელის ველი აუცილებელია!";
        public const string LastNameRequiredErrorMessage = "გვარის ველი აუცილებელია!";

        public const string PasswordRequiredErrorMessage = "პაროლის ველი აუცილებელია!";
        public const string PasswordConfirmErrorMessage = "პაროლის დადასტურება აუცილებელია!";
        public const string PasswordMismatchErrorMessage = "პაროლი არ ემთხვევა ერთმანეთს!";

        public const string RoleRequiredErrorMessage = "როლის დამატება აუცილებელია!";

        public const string EmailDisplayName = "ელ.ფოსტა";
        public const string PasswordDisplayName = "პაროლი";
        public const string RememberMeDisplayName = "დამიმახსოვრე";

        public const string UserProfileUpdateFailed = "პროფილის განახლება დასრულდა შეცდომით!";
        public const string UserNotFound = "მოხმარებელი ვერ მოიძებნა!";
        public const string UserUpdatedSuccess = "პროფილის განახლება წარმატებით შესრულდა.";
    }
}
