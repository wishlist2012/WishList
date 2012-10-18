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
        public long Id { get; set; }

        public long PostId { get; set; }

        public long UserId { get; set; }

        public string Message { get; set; }

        public DateTime CreatedUTC { get; set; }
    }
}
