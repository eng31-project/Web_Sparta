using System.ComponentModel.DataAnnotations;

namespace UserPortal.Models
{ 
    public partial class Role
    {
        public int RoleID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
    }
}
