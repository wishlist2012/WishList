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
    public class ObjectCommentRepository: ICommentRepository
    {
        private Collection<CommentEntity> _comments;

        #region Default constructor

        public ObjectCommentRepository()
        {
            _comments = new Collection<CommentEntity>();
            _comments.Add(new CommentEntity() { Id = 1, PostId = 1, UserId = 1, CreatedUTC = new DateTime(2012, 1, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 2, PostId = 1, UserId = 2, CreatedUTC = new DateTime(2012, 2, 1, 12, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 3, PostId = 1, UserId = 3, CreatedUTC = new DateTime(2012, 3, 21, 9, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 4, PostId = 2, UserId = 1, CreatedUTC = new DateTime(2012, 10, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 5, PostId = 2, UserId = 5, CreatedUTC = new DateTime(2012, 9, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 6, PostId = 2, UserId = 2, CreatedUTC = new DateTime(2012, 9, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 7, PostId = 3, UserId = 2, CreatedUTC = new DateTime(2012, 9, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 8, PostId = 3, UserId = 1, CreatedUTC = new DateTime(2012, 9, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 9, PostId = 3, UserId = 10, CreatedUTC = new DateTime(2012, 9, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 10, PostId = 4, UserId = 10, CreatedUTC = new DateTime(2012, 7, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 11, PostId = 4, UserId = 9, CreatedUTC = new DateTime(2012, 7, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 12, PostId = 5, UserId = 4, CreatedUTC = new DateTime(2012, 7, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 13, PostId = 5, UserId = 6, CreatedUTC = new DateTime(2012, 7, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 14, PostId = 6, UserId = 6, CreatedUTC = new DateTime(2012, 7, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 15, PostId = 6, UserId = 7, CreatedUTC = new DateTime(2012, 7, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 16, PostId = 7, UserId = 7, CreatedUTC = new DateTime(2012, 7, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 17, PostId = 7, UserId = 8, CreatedUTC = new DateTime(2012, 7, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 18, PostId = 8, UserId = 8, CreatedUTC = new DateTime(2012, 7, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 19, PostId = 8, UserId = 9, CreatedUTC = new DateTime(2012, 4, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 20, PostId = 9, UserId = 9, CreatedUTC = new DateTime(2012, 10, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 21, PostId = 9, UserId = 10, CreatedUTC = new DateTime(2012, 5, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 22, PostId = 9, UserId = 8, CreatedUTC = new DateTime(2012, 5, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 23, PostId = 9, UserId = 1, CreatedUTC = new DateTime(2012, 5, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 24, PostId = 10, UserId = 1, CreatedUTC = new DateTime(2012, 6, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 25, PostId = 10, UserId = 2, CreatedUTC = new DateTime(2012, 6, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 1, PostId = 10, UserId = 3, CreatedUTC = new DateTime(2012, 3, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 1, PostId = 10, UserId = 4, CreatedUTC = new DateTime(2012, 3, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 1, PostId = 10, UserId = 5, CreatedUTC = new DateTime(2012, 3, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 1, PostId = 10, UserId = 6, CreatedUTC = new DateTime(2012, 8, 10, 13, 54, 46), Message = "Nice picture!" });
            _comments.Add(new CommentEntity() { Id = 1, PostId = 10, UserId = 7, CreatedUTC = new DateTime(2012, 8, 10, 13, 54, 46), Message = "Nice picture!" });
        }

        #endregion

        public Collection<CommentEntity> GetAllByPostId(int id)
        {
            Collection<CommentEntity> comments = new Collection<CommentEntity>();
            foreach (CommentEntity comment in _comments.Where(c => c.PostId == id))
            {
                if (comment != null)
                {
                    comments.Add(comment);
                }
            }
            return comments;
        }

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

        public int GetCount()
        {
            return _comments.Count;
        }

        public void Dispose()
        {
            _comments.Clear();
        }
    }
}
