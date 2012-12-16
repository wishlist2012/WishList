using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WishList_Repository.DBEntities
{
    /// <summary>
    /// Coment entity
    /// </summary>
    public class CommentEntity
    {
        /// <summary>
        /// Gets or sets the comment Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the post Id of comment
        /// </summary>
        public long PostId { get; set; }

        /// <summary>
        /// Gets or sets the user Id of comment
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the message of comment
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the created date
        /// </summary>
        public DateTime CreatedUTC { get; set; }
    }
}
