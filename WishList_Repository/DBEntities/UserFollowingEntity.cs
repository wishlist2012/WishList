using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WishList_Repository.DBEntities
{
    public class UserFollowingEntity
    {
        public int UserId { get; set; }

        public int FollowingId { get; set; }
    }
}
