using System.ComponentModel.DataAnnotations;

namespace UserPortal.Models
{
    public partial class Specialisation
    {
        public int SpecialisationID { get; set; }

        [Required]
        [StringLength(50)]
        public string SpecialisationName { get; set; }
    }

}
