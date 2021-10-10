using Microsoft.AspNetCore.Authorization;

namespace WebApp_HaidarAldiWintoro_ManageCompany.Permission
{
    internal class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; private set; }

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
