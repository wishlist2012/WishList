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
        /// <summary>
        /// Gets or sets the post Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the original post Id
        /// </summary>
        public long OriginalPostId { get; set; }

        /// <summary>
        /// Gets or sets the author Id
        /// </summary>
        public int AuthorUserId { get; set; }

        /// <summary>
        /// Gets or sets the original author Id
        /// </summary>
        public int OriginalAuthorId { get; set; }

        /// <summary>
        /// Gets or sets the board Id
        /// </summary>
        public long BoardId { get; set; }

        /// <summary>
        /// Gets or sets the original board Id
        /// </summary>
        public long OriginalBoardId { get; set; }

        /// <summary>
        /// Gets or sets the title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the comment
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the image url
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail url
        /// </summary>
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// Gets or sets the image width
        /// </summary>
        public int ImageWidth { get; set; }

        /// <summary>
        /// Gets or sets the image height
        /// </summary>
        public int ImageHeight { get; set; }

        /// <summary>
        /// Gets or sets the likes count
        /// </summary>
        public int LikesCount { get; set; }
    }
}
