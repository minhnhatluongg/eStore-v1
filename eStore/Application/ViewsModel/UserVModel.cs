using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.ViewsModel
{
    public class UserCreateVModel
    {
        [JsonIgnore]
        public string? Id { get; set; }
        public string? Address { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        [RegularExpression(@"^[^\d!@#$%^&*()_+]+(?: [^\d!@#$%^&*()_+]+)*$", ErrorMessage = "Invalid Name")]
        public string? FullName { get; set; }
        public string? PasswordHash { get; set; }
        [Required]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Invalid Phone Number")]
        public string? Phone { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public class UserUpdateVModel : UserCreateVModel
    {
    }
    public class UserGetAllVModel : UserUpdateVModel
    {
        public string? RoleName { get; set; }
    }
    public class UserGetByIdVModel : UserGetAllVModel
    {
    }
}
