using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WishList_Repository.DBEntities;
using System.Collections.ObjectModel;

namespace WishList_Repository
{
    public interface IUserFollowingRepository : IDisposable
    {
        Collection<UserFollowingEntity> GetByUserId(int userId);
    }
}
