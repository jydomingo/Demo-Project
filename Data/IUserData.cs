using PhotoSharingAppJessieDomingo.Models;

namespace PhotoSharingAppJessieDomingo.Data
{
	public interface IUserData
	{
		Task<int> InsertUser(UserModel user);
		Task<LoginModel?> Login(string userid, string password);
	}
}