using Library.Common.Enums;

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Common
{
    public static class GlobalVariables
    {
        public static readonly IReadOnlyDictionary<SystemDefaultRole, string> DefaultRoles =
            new Dictionary<SystemDefaultRole, string>
            {
                { SystemDefaultRole.SuperAdmin, SuperAdminRoleName },
                { SystemDefaultRole.Admin, AdminRoleName },
                { SystemDefaultRole.User, UserRoleName }
            };

        public const string SuperAdminRoleName = "SuperAdmin";
        public const string AdminRoleName = "Admin";
        public const string UserRoleName = "User";

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

        public const string UserRoleErrorMessage = "როლის დამატება აუცილებელია!";

        public const string AuthorizedUserDeleteErrorMessage = "ავტორიზებული მომხმარებლის წაშლა შეუძლებელია!";
        public const string UserDeleteFailed = "მომხმარებლის წაშლა დასრულდა შეცდომით!";
        public const string UserDeletedSuccessfull = "მომხმარებელი წარმატებით წაიშალა.";

        public const string PasswordUpdatedSuccessfull = "პაროლი წარმატებით განახლდა.";
        public const string PasswordUpdateFailedErrorMessage = "პაროლის განახლება ვერ შესრულდა!";

        public const string UserCreatedSuccessMessage = "მამხმარებელი წარმატებით შეიქმნა.";
        public const string UserCreateFailedMessage = "ასეთი მომხმარებელი უკვე არსებობს!";

        public const string AuthorizationSuccess = "ავტორიზაცია წარმატებით განხორციელდა.";
        public const string AuthorizationFailed = "არასწორი მომხმარებელი ან პაროლი!";
        public const string UserSignedOutSuccess = "მომხმარებელი წარმატებით გავიდა სისტემიდან";

        public const string Space = "\u0020";
        public const string DefaultUrl = "/";

        public const string AccountIndexLink = "/accounts";
        public const string AccountProfileLink = "/accounts/profile";

        public const string CustomerIndexLink = "/customers";

        public const string UOW_ExceptionMessage = "UOW object null refference exception!";
        public const string RecordNotFound = "Record doesn't existed!";
    }
}
