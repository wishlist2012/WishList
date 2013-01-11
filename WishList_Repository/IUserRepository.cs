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
        /// <summary>
        /// Gets user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>user by id</returns>
        UserEntity GetUserById(int id);

        /// <summary>
        /// Gets user by user name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>user by user name</returns>
		UserEntity GetUserByUserName(string userName);

        /// <summary>
        /// Gets user name by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>user name by email</returns>
		string GetUserNameByEmail(string email);

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>all users</returns>
        Collection<UserEntity> GetAll();

        /// <summary>
        /// Check if email is unique
        /// </summary>
        /// <param name="email"></param>
        /// <returns>boolean result</returns>
		bool IsUniqueEmail(string email);

        /// <summary>
        /// Validate user by email and pasword
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>boolean result</returns>
		bool ValidateUser(string email, string password);

        /// <summary>
        /// Update current user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>bolean result</returns>
        bool Update(UserEntity user);

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>bolean result</returns>
		bool Create(string userName, string firstName, string lastName, string email, string password);

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>bolean result</returns>
        bool Delete(int id);

        /// <summary>
        /// Check if user exist by email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>bolean result</returns>
        bool IsExists(string email, string password);

        /// <summary>
        /// Check if user exist by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>bolean result</returns>
        bool IsExists(int userId);

        /// <summary>
        /// Changes pasword
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns>bolean result</returns>
        bool ChangePassword(int userId, string oldPassword, string newPassword);

        /// <summary>
        /// Gets count of all users
        /// </summary>
        /// <returns>bolean result</returns>
        int GetCount();

        /// <summary>
        /// Gets user followers by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>user followers</returns>
        Collection<UserEntity> GetFollowings(int userId);
		
    }
}
