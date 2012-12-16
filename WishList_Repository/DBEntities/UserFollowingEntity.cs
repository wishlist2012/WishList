using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WishList_Repository.DBEntities
{
    public class UserFollowingEntity
    {
        /// <summary>
        /// Gets or sets the following user Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the follower Id
        /// </summary>
        public int FollowingId { get; set; }
    }
}
