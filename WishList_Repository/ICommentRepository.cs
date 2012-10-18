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
    public interface ICommentRepository: IDisposable
    {
        Collection<CommentEntity> GetAllByPostId(int id);

        bool Create(CommentEntity comment);

        bool Update(CommentEntity comment);

        bool Delete(int id);

        int GetCount();
    }
}
