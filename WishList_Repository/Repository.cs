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
        /// <summary>
        /// Get new instance of user repository
        /// </summary>
        /// <returns></returns>
        public static IUserRepository GetUserRepositoryInstance() { return new ObjectUserRepository(); }
    }
}
