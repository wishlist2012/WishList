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
    }
}
