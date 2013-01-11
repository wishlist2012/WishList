using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using WishList_Repository.DBEntities;

namespace WishList_Repository
{
    /// <summary>
    /// Common interface for category repository
    /// </summary>
    public interface ICategoryRepository : IDisposable
    {
        /// <summary>
        /// Gets category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> category </returns>
        CategoryEntity Get(int id);

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>all categories </returns>
        Collection<CategoryEntity> GetAll();
    }
}
