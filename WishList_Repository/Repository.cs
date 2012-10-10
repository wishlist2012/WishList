using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using WishList_Repository.DBEntities;
using WishList_Repository.ObjectRepositories;

namespace WishList_Repository
{
    public static class Repository
    {
        private static IUserRepository _userRepositoryInstance;
        private static IUserFollowingRepository _userFollowingRepositoryInstance;
        private static IUserPostRepository _userPostRepositoryInstance;

        /// <summary>
        /// Get new instance of user repository
        /// </summary>
        /// <returns></returns>
        public static IUserRepository UserRepositoryInstance
        {
            get
            {
                if (_userRepositoryInstance == null)
                    _userRepositoryInstance = new ObjectUserRepository();

                return _userRepositoryInstance;
            }
        }

        /// <summary>
        /// Get new instance of user following repository
        /// </summary>
        public static IUserFollowingRepository UserFollowingRepositoryInstance
        {
            get
            {
                if (_userFollowingRepositoryInstance == null)
                    _userFollowingRepositoryInstance = new ObjectUserFollowingRepository();

                return _userFollowingRepositoryInstance;
            }
        }

        /// <summary>
        /// Get new instance of user post repository
        /// </summary>
        public static IUserPostRepository UserPostRepositoryInstance
        {
            get
            {
                if (_userPostRepositoryInstance == null)
                    _userPostRepositoryInstance = new ObjectUserPostRepository();

                return _userPostRepositoryInstance;
            }
        }
    }
}
