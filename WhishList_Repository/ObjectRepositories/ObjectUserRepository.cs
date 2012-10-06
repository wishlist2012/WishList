using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using WhishList_Repository.DBEntities;

namespace WhishList_Repository.ObjectRepositories
{
    /// <summary>
    /// Object-based user repository
    /// </summary>
    public class ObjectUserRepository : IUserRepository
    {
        private Collection<User> _users;

        #region Default constructor

        public ObjectUserRepository()
        {
            _users = new Collection<User>();
            _users.Add(new User() { Id = 1, Username = "John", CreatedUTC = new DateTime(2012, 1, 10, 13, 54, 46) });
            _users.Add(new User() { Id = 2, Username = "Michael", CreatedUTC = new DateTime(2012, 2, 15, 10, 23, 13) });
            _users.Add(new User() { Id = 3, Username = "Tony", CreatedUTC = new DateTime(2012, 1, 16, 23, 28, 17) });
            _users.Add(new User() { Id = 4, Username = "Sarah", CreatedUTC = new DateTime(2012, 2, 19, 8, 15, 55) });
            _users.Add(new User() { Id = 5, Username = "Daniel", CreatedUTC = new DateTime(2012, 1, 30, 15, 44, 37) });
        }

        #endregion

        public User Get(int id)
        {
            return _users.SingleOrDefault(r => r.Id == id);
        }

        public bool Update(User user)
        {
            bool updateResult = false;

            User old = _users.SingleOrDefault(r => r.Id == user.Id);
            if (old != null)
            {
                old.CreatedUTC = user.CreatedUTC;
                old.Username = user.Username;
                updateResult = true;
            }

            return updateResult;
        }

        public bool Create(User user)
        {
            bool createResult = false;

            if (user != null)
            {
                _users.Add(user);
                createResult = true;
            }

            return createResult;
        }

        public bool Delete(int id)
        {
            bool deleteResult = false;

            User userToDelete = _users.SingleOrDefault(r => r.Id == id);
            if (userToDelete != null)
            {
                _users.Remove(userToDelete);
                deleteResult = true;
            }

            return deleteResult;
        }

        public void Dispose()
        {
            _users.Clear();
        }
    }
}
