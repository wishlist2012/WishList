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
        /// <summary>
        /// Get post by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>singlt post or null</returns>
        UserPostEntity Get(long id);

        /// <summary>
        /// Gets all user posts from certain board
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="boardId"></param>
        /// <returns>all user posts from certain board</returns>
        Collection<UserPostEntity> Get(int userId, int boardId);

        /// <summary>
        /// Gets all user posts
        /// </summary>
        /// <returns>all user posts</returns>
        Collection<UserPostEntity> GetAll();

        /// <summary>
        /// Check if post exists by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>if exists</returns>
        bool IsExists(long id);

        /// <summary>
        /// Gets count of posts
        /// </summary>
        /// <returns>count of posts</returns>
        long GetCount();
    }
}
