using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using WishList_Repository.DBEntities;
using System.IO;
using System.Web;
using System.Security.Cryptography;
using System.Web.Security;

namespace WishList_Repository.ObjectRepositories
{
    /// <summary>
    /// Object-based user repository
    /// </summary>
    public class ObjectUserRepository : IUserRepository
    {
        private Collection<UserEntity> _users;

        #region Default constructor

        public ObjectUserRepository()
        {
            _users = new Collection<UserEntity>();
            _users.Add(new UserEntity() { Id = 1, UserName = "userName1", FirstName = "Сергей", LastName = "Пархоменко", UserPhoto = @"/Images/UserPhoto/medveput.jpg", Password = "welcome@1", PasswordSalt="qbJJGKOA0CJwgTq6z5KrD+au8mFa0Fb9dByVLWkcK24=", UserSettingId = 1, CreatedUTC = new DateTime(2012, 1, 10, 13, 54, 46), LastLoginDate = new DateTime(2012, 1, 10, 13, 54, 46), Email = "john@gmail.com", IsActivated = true, IsLockedOut = false });
			_users.Add(new UserEntity() { Id = 2, UserName = "userName2", FirstName = "Анатолий", LastName = "Белугин", UserPhoto = @"/Images/UserPhoto/medveput.jpg", Password = "welcome@1", UserSettingId = 2, CreatedUTC = new DateTime(2012, 2, 15, 10, 23, 13), LastLoginDate = new DateTime(2012, 1, 10, 13, 54, 46), Email = "michael@yandex.ru", IsActivated = true, IsLockedOut = false });
			_users.Add(new UserEntity() { Id = 3, UserName = "userName3", FirstName = "Вадим", LastName = "Иванов", UserPhoto = @"/Images/UserPhoto/medveput.jpg", Password = "welcome@1", UserSettingId = 3, CreatedUTC = new DateTime(2012, 1, 16, 23, 28, 17), LastLoginDate = new DateTime(2012, 1, 10, 13, 54, 46), Email = "tony@live.com", IsActivated = false, IsLockedOut = false });
			_users.Add(new UserEntity() { Id = 4, UserName = "userName4", FirstName = "Олег", LastName = "Корниенко", UserPhoto = @"/Images/UserPhoto/medveput.jpg", Password = "welcome@1", UserSettingId = 4, CreatedUTC = new DateTime(2012, 2, 19, 8, 15, 55), LastLoginDate = new DateTime(2012, 1, 10, 13, 54, 46), Email = "sarah@hotmail.com", IsActivated = true, IsLockedOut = false });
			_users.Add(new UserEntity() { Id = 5, UserName = "userName5", FirstName = "Анна", LastName = "Солодовник", UserPhoto = @"/Images/UserPhoto/medveput.jpg", Password = "welcome@1", UserSettingId = 5, CreatedUTC = new DateTime(2012, 1, 30, 15, 44, 37), LastLoginDate = new DateTime(2012, 1, 10, 13, 54, 46), Email = "daniel@yahoo.com", IsActivated = true, IsLockedOut = false });
			_users.Add(new UserEntity() { Id = 6, UserName = "userName6", FirstName = "Юлия", LastName = "Зеленская", UserPhoto = @"/Images/UserPhoto/medveput.jpg", Password = "welcome@1", UserSettingId = 6, CreatedUTC = new DateTime(2012, 1, 8, 12, 8, 55), LastLoginDate = new DateTime(2012, 1, 10, 13, 54, 46), Email = "helen@inbox.com", IsActivated = true, IsLockedOut = false });
			_users.Add(new UserEntity() { Id = 7, UserName = "userName7", FirstName = "Инна", LastName = "Сорока", UserPhoto = @"/Images/UserPhoto/medveput.jpg", Password = "welcome@1", UserSettingId = 7, CreatedUTC = new DateTime(2012, 2, 19, 5, 11, 24), LastLoginDate = new DateTime(2012, 1, 10, 13, 54, 46), Email = "alex@gmail.com", IsActivated = true, IsLockedOut = false });
			_users.Add(new UserEntity() { Id = 8, UserName = "userName8", FirstName = "Константин", LastName = "Беляев", UserPhoto = @"/Images/UserPhoto/medveput.jpg", Password = "welcome@1", UserSettingId = 8, CreatedUTC = new DateTime(2012, 2, 2, 13, 42, 19), LastLoginDate = new DateTime(2012, 1, 10, 13, 54, 46), Email = "james@mail.ru", IsActivated = true, IsLockedOut = false });
			_users.Add(new UserEntity() { Id = 9, UserName = "userName9", FirstName = "Владимир", LastName = "Романенко", UserPhoto = @"/Images/UserPhoto/medveput.jpg", Password = "welcome@1", UserSettingId = 9, CreatedUTC = new DateTime(2012, 1, 17, 3, 45, 18), LastLoginDate = new DateTime(2012, 1, 10, 13, 54, 46), Email = "leonard@mail.ru", IsActivated = true, IsLockedOut = false });
			_users.Add(new UserEntity() { Id = 10, UserName = "userName10", FirstName = "Ольга", LastName = "Васильева", UserPhoto = @"/Images/UserPhoto/medveput.jpg", Password = "welcome@1", UserSettingId = 10, CreatedUTC = new DateTime(2012, 1, 20, 21, 34, 20), LastLoginDate = new DateTime(2012, 1, 10, 13, 54, 46), Email = "kate@hotmail.com", IsActivated = false, IsLockedOut = false });
        }

        #endregion		

        public void Dispose()
        {
            _users.Clear();
        }

        public UserEntity GetUserById(int userId)
        {
            return _users.SingleOrDefault(u => u.Id == userId);
        }

		public UserEntity GetUserByUserName(string userName)
		{
			return _users.SingleOrDefault(u => u.UserName == userName);
		}

		public string GetUserNameByEmail(string email)
		{
			UserEntity user = _users.SingleOrDefault(u => u.Email == email);

			if (user != null)
				return user.UserName;
			else
				return string.Empty;
		}

        public Collection<UserEntity> GetAll()
        {
            return _users;
        }

        public bool Update(UserEntity user)
        {
            bool updateResult = false;

            UserEntity old = _users.SingleOrDefault(u => u.Id == user.Id);
            if (old != null)
            {
                old.Email = user.Email;
                old.FirstName = user.FirstName;
                old.LastName = user.LastName;
                updateResult = true;
            }

            return updateResult;
        }

		public bool Create(string userName, string firstName, string lastName, string email, string password)
        {
			bool createResult = false;
			UserEntity user = new UserEntity();

			if (_users.SingleOrDefault(u => u.UserName == userName) == null)
			{
				string passwordSalt = CreateSalt();

				user.Id = GenerateNewID();
				user.UserName = userName;
				user.FirstName = firstName;
				user.LastName = lastName;
				user.Email = email;
				user.PasswordSalt = passwordSalt;
				user.Password = CreatePasswordHash(password, passwordSalt);
				user.CreatedUTC = DateTime.Now;
				user.LastLoginDate = DateTime.Now;
				user.UserSettingId = 1;
				user.UserPhoto = @"/Images/UserPhoto/medveput.jpg";
				user.IsActivated = false;
				user.IsLockedOut = false;
				user.LastLockedOutDate = user.CreatedUTC;

				_users.Add(user);
				createResult = true;
			}
            return createResult;
        }

        public bool Delete(int userId)
        {
            bool deleteResult = false;

            UserEntity userToDelete = _users.SingleOrDefault(u => u.Id == userId);
            if (userToDelete != null)
            {
                _users.Remove(userToDelete);
                deleteResult = true;
            }

            return deleteResult;
        }

        public bool IsExists(string email, string password)
        {
            return (_users.Count(u => string.Equals(u.Email, email) && string.Equals(u.Password, password)) == 1);
        }
                
        public bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            bool changePasswordResult = false;

            UserEntity userToChange = _users.SingleOrDefault(u => u.Id == userId);
            if (userToChange != null)
            {
                userToChange.Password = newPassword;
                changePasswordResult = true;
            }

            return changePasswordResult;
        }

        public int GetCount()
        {
            return _users.Count;
        }

        public bool IsExists(int userId)
        {
            return (_users.Count(u => u.Id == userId) == 1);
        }

        public Collection<UserEntity> GetFollowings(int userId)
        {
            Collection<UserEntity> followingUsers = new Collection<UserEntity>();

            var followingRepository = Repository.UserFollowingRepositoryInstance;
            foreach (UserFollowingEntity following in followingRepository.GetByUserId(userId))
                followingUsers.Add(this.GetUserById(following.FollowingId));

            return followingUsers;
        }

		public bool IsUniqueEmail(string email)
		{
			bool EmailExist = true;
			UserEntity user = _users.FirstOrDefault(u => u.Email == email);
			if (user != null)
				EmailExist = false;

			return EmailExist;
		}

		public bool ValidateUser(string email, string password)
		{
			UserEntity user = _users.FirstOrDefault(u => u.Email == email);

			return (user != null && user.Password == CreatePasswordHash(password, user.PasswordSalt));
		}


		/// <summary>
		/// Helper Methods
		/// </summary>
		#region Helper Methods

		//Generate new random id
		private static int GenerateNewID()
		{
			Random rnd = new Random();
			int ID = rnd.Next(200, int.MaxValue);

			return ID;
		}

		//Create salt for password
		private static string CreateSalt()
		{
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			byte[] buff = new byte[32];
			rng.GetBytes(buff);

			return Convert.ToBase64String(buff);
		}

		//Create password hash
		private static string CreatePasswordHash(string password, string salt)
		{			
			string saltAndPwd = String.Concat(password, salt);
			string hashedPassword = password;//FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "md5");
			
			return hashedPassword;
		}

		#endregion
	}
}
