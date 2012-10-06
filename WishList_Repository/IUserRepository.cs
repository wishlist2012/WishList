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
        UserEntity Get(int id);

        Collection<UserEntity> GetAll();

        bool Update(UserEntity user);

        bool Create(UserEntity user);

        bool Delete(int id);

        bool IsExists(string email, string password);

        bool ChangePassword(int userId, string oldPassword, string newPassword);
    }
}
