using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WishList_Repository.DBEntities;
using System.Collections.ObjectModel;

namespace WishList_Repository
{
    /// <summary>
    /// Common interface for user following repository
    /// </summary>
    public interface IUserFollowingRepository : IDisposable
    {
        /// <summary>
        /// Gets all followers of user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>all followers of user by id</returns>
        Collection<UserFollowingEntity> GetByUserId(int userId);
    }
}
