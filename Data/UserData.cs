using PhotoSharingAppJessieDomingo.DataAccess;
using PhotoSharingAppJessieDomingo.Models;

namespace PhotoSharingAppJessieDomingo.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }


        public async Task<LoginModel?> Login(string userid, string password)
        {
            var results = await _db.LoadData<LoginModel, dynamic>(
                "dbo.sp_validate_user",
                new { UserID = userid, Password = password }, "default");
            return results.FirstOrDefault();
        }

        public Task<int> InsertUser(UserModel user) =>
        _db.SaveData("dbo.sp_insert_user", new { user.UserID, user.FirstName, user.MiddleName, user.LastName, user.Password }, "default");
    }
}