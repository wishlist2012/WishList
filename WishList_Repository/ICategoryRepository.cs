using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WishList_Repository.DBEntities;
using System.Collections.ObjectModel;

namespace WishList_Repository
{
    /// <summary>
    /// Common interface for category repository
    /// </summary>
    public interface ICategoryRepository : IDisposable
    {
        CategoryEntity Get(int id);

        Collection<CategoryEntity> GetAll();
    }
}
