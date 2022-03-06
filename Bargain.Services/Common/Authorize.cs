using Bargain.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace Bargain.Services.Common
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params RoleType[] roles)
        {
            var allowedRoles = roles.Select(x => Enum.GetName(typeof(RoleType), x));

            Roles = string.Join($"{Constants.COMMA_DELIMITER} ", allowedRoles);
        }
    }
}
