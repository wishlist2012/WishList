using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using WishList_Repository.DBEntities;

namespace WishList_Repository.ObjectRepositories
{
    /// <summary>
    /// Object-based comment repository
    /// </summary>
    public class ObjectCommentRepository : ICommentRepository
    {
        private Collection<CommentEntity> _comments;
        private long identityIdCounter = 1;

        #region Default constructor

        /// <summary>
        /// Default constructur
        /// </summary>
        public ObjectCommentRepository()
        {
            _comments = new Collection<CommentEntity>();

            Random rand = new Random();
            for (long i = 1; i < Repository.UserPostRepositoryInstance.GetCount(); i++)
            {
                // random count of comments for post
                for (int j = 1; j < rand.Next(1, 100); j++)
                {
                    if (Repository.UserPostRepositoryInstance.IsExists(i))
                    {
                        CommentEntity comment = new CommentEntity();
                        comment.Id = identityIdCounter++;
                        comment.CreatedUTC = DateTime.Now;
                        comment.PostId = i;
                        comment.UserId = Repository.UserPostRepositoryInstance.Get(i).AuthorUserId;
                        comment.Message = "";
                        for (int k = 0; k < rand.Next(1, 10); k++)
                            comment.Message += "Nice post!";

                        _comments.Add(comment);
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Clear all comments
        /// </summary>
        public void Dispose()
        {
            _comments.Clear();
        }

        /// <summary>
        /// Get all comments by post id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>all comments</returns>
        public Collection<CommentEntity> GetAllByPostId(long id)
        {
            Collection<CommentEntity> comments = new Collection<CommentEntity>();

            if (Repository.UserPostRepositoryInstance.IsExists(id))
            {
                foreach (CommentEntity comment in _comments.Where(c => c.PostId == id))
                    comments.Add(comment);
            }
            return comments;
        }

        /// <summary>
        /// Create comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>created comment</returns>
        public bool Create(CommentEntity comment)
        {
            bool createResult = false;

            if (comment != null)
            {
                _comments.Add(comment);
                createResult = true;
            }

            return createResult;
        }

        /// <summary>
        /// Update comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>updated comment</returns>
        public bool Update(CommentEntity comment)
        {
            bool updateResult = false;

            CommentEntity old = _comments.SingleOrDefault(c => c.Id == comment.Id);

            if (old != null)
            {
                old.Message = comment.Message;
                updateResult = true;
            }

            return updateResult;

        }

        /// <summary>
        /// Delete comment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bolean result</returns>
        public bool Delete(int id)
        {
            bool deleteResult = false;

            CommentEntity comment = _comments.SingleOrDefault(c => c.Id == id);
            if (comment != null)
            {
                _comments.Remove(comment);
                deleteResult = true;
            }

            return deleteResult;
        }

        /// <summary>
        /// Gets count of comments
        /// </summary>
        /// <returns>Count of comments</returns>
        public int GetCount()
        {
            return _comments.Count;
        }

    }
}
