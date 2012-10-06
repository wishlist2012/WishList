using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using WhishList_Repository.DBEntities;
using WhishList_Repository.ObjectRepositories;

namespace WhishList_Repository
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
