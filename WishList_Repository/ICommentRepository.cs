using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using WishList_Repository.DBEntities;

namespace WishList_Repository
{
    /// <summary>
    /// Common interface for comment repository
    /// </summary>
    public interface ICommentRepository : IDisposable
    {
        /// <summary>
        /// Get all comments by post id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>all comments</returns>
        Collection<CommentEntity> GetAllByPostId(long id);

        /// <summary>
        /// Create comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>created comment</returns>
        bool Create(CommentEntity comment);

        /// <summary>
        /// Update comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>updated comment</returns>
        bool Update(CommentEntity comment);

        /// <summary>
        /// Delete comment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bolean result</returns>
        bool Delete(int id);

        /// <summary>
        /// Gets count of comments
        /// </summary>
        /// <returns>Count of comments</returns>
        int GetCount();
    }
}
