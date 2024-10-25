using eStore.Infrastructure.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace eStore.ViewsModel
{
    public class UpdateRoleModel
    {
        public string UserId { get; set; }
        public List<string> AssignRoles { get; set; }
    }
    public class AspNetRoleCreateVModel
    {
        [Required]
        public string Name { get; set; }
        public bool? IsActive { get; set; }
    }
    public class AspNetRoleUpdateVModel : AspNetRoleCreateVModel
    {
        public string Id { get; set; }
        public ERole ToEntity(ERole actionName)
        {
            actionName.RoleName = Name;
            return actionName;
        }
    }
    public class AspNetRoleGetAllVModel : AspNetRoleUpdateVModel
    {
        public string ConcurrencyStamp { get; set; }
        public string NormalizedName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
    public class AspNetRoleGetByIdVModel : AspNetRoleGetAllVModel
    {
        public string JsonRoleHasFunctions { get; set; }
    }
    public class UpadateJsonHasFunctionByRoleIdVModel
    {
        public string Id { get; set; }
        public string JsonRoleHasFunctions { get; set; }
    }
    public class RoleVModel
    {
        public string ControllerName { get; set; }
        public List<RoleModel> PermissionModels { get; set; }

    }
    public class RoleModel
    {
        public bool IsAllow { get; set; } = false;
        public string ActionName { get; set; }
        public string HttpMethod { get; set; }
    }

    public class FiltersGetAllByQueryStringRoleVModel
    {
        public string Keyword { get; set; }
        public string CreatedDate { get; set; }
        public bool? Status { get; set; }
        public string OrderBy { get; set; }
        public string OrderDirection { get; set; }
        public int PageSize { get; set; } = 200;
        public int PageNumber { get; set; } = 1;
        public bool IsExport { get; set; } = false;
    }
}
