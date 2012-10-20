using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WishList_Repository.DBEntities
{
    /// <summary>
    /// User post entity
    /// </summary>
    public class UserPostEntity
    {
        public long Id { get; set; }

        public long OriginalPostId { get; set; }

        public int AuthorUserId { get; set; }

        public int OriginalAuthorId { get; set; }

        public long BoardId { get; set; }

        public long OriginalBoardId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbnailUrl { get; set; }

        public int ImageWidth { get; set; }

        public int ImageHeight { get; set; }

        public int LikesCount { get; set; }
    }
}
