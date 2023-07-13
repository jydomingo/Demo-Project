namespace PhotoSharingAppJessieDomingo.Models
{
	public interface IUserModel
	{
		string ConfirmPassword { get; set; }
		DateTime DateCreated { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
		string MiddleName { get; set; }
		string Password { get; set; }
		string UserID { get; set; }
	}
}