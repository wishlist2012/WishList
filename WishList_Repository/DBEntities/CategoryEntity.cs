using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WishList_Repository.DBEntities
{
    /// <summary>
    /// Category entity
    /// </summary>
    public class CategoryEntity
    {
        /// <summary>
        /// Gets or sets the category Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of category
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the parent category Id
        /// </summary>
        public int ParentCategoryId { get; set; }
    }
}
