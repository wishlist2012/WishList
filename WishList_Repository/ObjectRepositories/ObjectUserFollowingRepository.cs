using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WishList_Repository.DBEntities;
using System.Collections.ObjectModel;

namespace WishList_Repository.ObjectRepositories
{
    public class ObjectUserFollowingRepository : IUserFollowingRepository
    {
        private Collection<UserFollowingEntity> _userFollowings;

        #region Default constructor

        public ObjectUserFollowingRepository()
        {
            _userFollowings = new Collection<UserFollowingEntity>();

            Random rnd = new Random();
            IUserRepository userRepository = Repository.UserRepositoryInstance;
            
            foreach (UserEntity user in userRepository.GetAll())
            {
                int followingCount = rnd.Next(1, userRepository.GetCount());
                for (int i = 0; i < followingCount; i++)
                {
                    int followingUserId = rnd.Next(1, userRepository.GetCount());
                    if (_userFollowings.Count(r => r.UserId == user.Id && r.FollowingId == followingUserId) == 0 && user.Id != followingUserId)
                        _userFollowings.Add(new UserFollowingEntity() { UserId = user.Id, FollowingId = followingUserId });
                }
            }
        }

        #endregion

        public void Dispose()
        {
            _userFollowings.Clear();
        }

        public Collection<UserFollowingEntity> GetByUserId(int userId)
        {
            Collection<UserFollowingEntity> followings = new Collection<UserFollowingEntity>();
            var userRepository = Repository.UserRepositoryInstance;

            foreach (UserFollowingEntity userFollowing in _userFollowings.Where(r => r.UserId == userId))
            {
                if (userRepository.IsExists(userFollowing.UserId))
                    followings.Add(userFollowing);
            }

            return followings;
        }
    }
}
