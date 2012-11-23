using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WishList_Repository.DBEntities;
using System.Collections.ObjectModel;

namespace WishList_Repository
{
    /// <summary>
    /// Common interface for user repository
    /// </summary>
    public interface IUserRepository : IDisposable
    {
        UserEntity GetUserById(int id);

		UserEntity GetUserByUserName(string userName);

		string GetUserNameByEmail(string email);

        Collection<UserEntity> GetAll();

		bool IsUniqueEmail(string email);

		bool ValidateUser(string email, string password);

        bool Update(UserEntity user);

		bool Create(string userName, string firstName, string lastName, string email, string password);

        bool Delete(int id);

        bool IsExists(string email, string password);

        bool IsExists(int userId);

        bool ChangePassword(int userId, string oldPassword, string newPassword);

        int GetCount();

        Collection<UserEntity> GetFollowings(int userId);
		
    }
}
