 
namespace UserPortal.Models
{ 
    public partial class Users
    {
        public int UsersID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password;
        public int CohortID { get; set; }
        public int RoleID { get; set; }

    }
}
