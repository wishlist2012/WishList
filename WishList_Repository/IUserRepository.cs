﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WishList_Repository.DBEntities;

namespace WishList_Repository
{
    /// <summary>
    /// Common interface for user repository
    /// </summary>
    public interface IUserRepository : IDisposable
    {
        User Get(int id);

        bool Update(User user);

        bool Create(User user);

        bool Delete(int id);
    }
}