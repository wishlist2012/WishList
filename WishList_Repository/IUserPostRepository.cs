using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WishList_Repository.DBEntities;
using System.Collections.ObjectModel;

namespace WishList_Repository
{
    /// <summary>
    /// Common interface for user post repository
    /// </summary>
    public interface IUserPostRepository : IDisposable
    {
        UserPostEntity Get(long id);

        Collection<UserPostEntity> Get(int userId, int boardId);
    }
}
