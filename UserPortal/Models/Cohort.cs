using System.ComponentModel.DataAnnotations;

namespace UserPortal.Models
{
    public partial class Cohort
    {
        public int CohortID { get; set; }

        [StringLength(50)]
        public string CohortName { get; set; }
        public int SpecialisationID { get; set; }

        public virtual Specialisation Specialisation { get; set; }
    }
}
