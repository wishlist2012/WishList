using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using WishList_Repository.DBEntities;

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
            _users.Add(new UserEntity() { Id = 1, FirstName = "Сергей", LastName = "Пархоменко", Password = "welcome@1", UserSettingId = 1, CreatedUTC = new DateTime(2012, 1, 10, 13, 54, 46), Email = "john@gmail.com", IsActive = true });
            _users.Add(new UserEntity() { Id = 2, FirstName = "Анатолий", LastName = "Белугин", Password = "welcome@1", UserSettingId = 2, CreatedUTC = new DateTime(2012, 2, 15, 10, 23, 13), Email = "michael@yandex.ru", IsActive = true });
            _users.Add(new UserEntity() { Id = 3, FirstName = "Вадим", LastName = "Иванов", Password = "welcome@1", UserSettingId = 3, CreatedUTC = new DateTime(2012, 1, 16, 23, 28, 17), Email = "tony@live.com", IsActive = false });
            _users.Add(new UserEntity() { Id = 4, FirstName = "Олег", LastName = "Корниенко", Password = "welcome@1", UserSettingId = 4, CreatedUTC = new DateTime(2012, 2, 19, 8, 15, 55), Email = "sarah@hotmail.com", IsActive = true });
            _users.Add(new UserEntity() { Id = 5, FirstName = "Анна", LastName = "Солодовник", Password = "welcome@1", UserSettingId = 5, CreatedUTC = new DateTime(2012, 1, 30, 15, 44, 37), Email = "daniel@yahoo.com", IsActive = true });
            _users.Add(new UserEntity() { Id = 6, FirstName = "Юлия", LastName = "Зеленская", Password = "welcome@1", UserSettingId = 6, CreatedUTC = new DateTime(2012, 1, 8, 12, 8, 55), Email = "helen@inbox.com", IsActive = true });
            _users.Add(new UserEntity() { Id = 7, FirstName = "Инна", LastName = "Сорока", Password = "welcome@1", UserSettingId = 7, CreatedUTC = new DateTime(2012, 2, 19, 5, 11, 24), Email = "alex@gmail.com", IsActive = true });
            _users.Add(new UserEntity() { Id = 8, FirstName = "Константин", LastName = "Беляев", Password = "welcome@1", UserSettingId = 8, CreatedUTC = new DateTime(2012, 2, 2, 13, 42, 19), Email = "james@mail.ru", IsActive = true });
            _users.Add(new UserEntity() { Id = 9, FirstName = "Владимир", LastName = "Романенко", Password = "welcome@1", UserSettingId = 9, CreatedUTC = new DateTime(2012, 1, 17, 3, 45, 18), Email = "leonard@mail.ru", IsActive = true });
            _users.Add(new UserEntity() { Id = 10, FirstName = "Ольга", LastName = "Васильева", Password = "welcome@1", UserSettingId = 10, CreatedUTC = new DateTime(2012, 1, 20, 21, 34, 20), Email = "kate@hotmail.com", IsActive = false });
        }

        #endregion

        public void Dispose()
        {
            _users.Clear();
        }

        public UserEntity Get(int userId)
        {
            return _users.SingleOrDefault(r => r.Id == userId);
        }

        public Collection<UserEntity> GetAll()
        {
            return _users;
        }

        public bool Update(UserEntity user)
        {
            bool updateResult = false;

            UserEntity old = _users.SingleOrDefault(r => r.Id == user.Id);
            if (old != null)
            {
                old.Email = user.Email;
                old.FirstName = user.FirstName;
                old.LastName = user.LastName;
                updateResult = true;
            }

            return updateResult;
        }

        public bool Create(UserEntity user)
        {
            bool createResult = false;

            if (user != null)
            {
                _users.Add(user);
                createResult = true;
            }

            return createResult;
        }

        public bool Delete(int userId)
        {
            bool deleteResult = false;

            UserEntity userToDelete = _users.SingleOrDefault(r => r.Id == userId);
            if (userToDelete != null)
            {
                _users.Remove(userToDelete);
                deleteResult = true;
            }

            return deleteResult;
        }

        public bool IsExists(string email, string password)
        {
            return (_users.Count(r => string.Equals(r.Email, email) && string.Equals(r.Password, password)) == 1);
        }
                
        public bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            bool changePasswordResult = false;

            UserEntity userToChange = _users.SingleOrDefault(r => r.Id == userId);
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
            return (_users.Count(r => r.Id == userId) == 1);
        }

        public Collection<UserEntity> GetFollowings(int userId)
        {
            Collection<UserEntity> followingUsers = new Collection<UserEntity>();

            var followingRepository = Repository.UserFollowingRepositoryInstance;
            foreach (UserFollowingEntity following in followingRepository.GetByUserId(userId))
                followingUsers.Add(this.Get(following.FollowingId));

            return followingUsers;
        }
    }
}
