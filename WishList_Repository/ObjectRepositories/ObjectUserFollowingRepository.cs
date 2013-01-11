using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WishList_Repository.DBEntities;
using System.Collections.ObjectModel;

namespace WishList_Repository.ObjectRepositories
{
    /// <summary>
    /// Object-based user following repository
    /// </summary>
    public class ObjectUserFollowingRepository : IUserFollowingRepository
    {
        private Collection<UserFollowingEntity> _userFollowings;

        #region Default constructor

        /// <summary>
        /// Default constructor
        /// </summary>
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

        /// <summary>
        /// Clear all followers of user
        /// </summary>
        public void Dispose()
        {
            _userFollowings.Clear();
        }

        /// <summary>
        /// Gets all followers of user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>all followers of user by id</returns>
        public Collection<UserFollowingEntity> GetByUserId(int userId)
        {
            Collection<UserFollowingEntity> followings = new Collection<UserFollowingEntity>();

            if (Repository.UserRepositoryInstance.IsExists(userId))
            {
                foreach (UserFollowingEntity userFollowing in _userFollowings.Where(r => r.UserId == userId))
                    followings.Add(userFollowing);
            }

            return followings;
        }
    }
}
