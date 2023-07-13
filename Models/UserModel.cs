using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PhotoSharingAppJessieDomingo.Models
{
    public class UserModel : IUserModel
    {
        [Display(Name = "User ID:")]
        public string UserID { get; set; }
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name:")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Display(Name = "Password:")]
        public string Password { get; set; }
        [Display(Name = "Date Created:")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Confirm Password:")]
        public string ConfirmPassword { get; set; }

    }
}
