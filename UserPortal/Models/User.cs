﻿using System.ComponentModel.DataAnnotations;

namespace UserPortal.Models
{ 
    public partial class User
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [RegularExpression(@"^([\w\.\-]+)@([spartaglobal]+)((\.(com))+)$")]
        [StringLength(50)]
        public string Email { get; set; }


        [Required]
        public string Password;

        public int CohortID { get; set; }

        public int RoleID { get; set; }

        public virtual Cohort Cohort { get; set; }

        public virtual Role Role { get; set; }

    }
}
