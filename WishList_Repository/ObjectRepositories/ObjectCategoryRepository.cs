using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using WishList_Repository.DBEntities;

namespace WishList_Repository.ObjectRepositories
{
    /// <summary>
    /// Object-based category repository
    /// </summary>
    public class ObjectCategoryRepository : ICategoryRepository
    {
        private Collection<CategoryEntity> _categories;

        #region Default constructor

        public ObjectCategoryRepository()
        {
            _categories = new Collection<CategoryEntity>();
            _categories.Add(new CategoryEntity() { Id = 1, Name = "Animals" });
            _categories.Add(new CategoryEntity() { Id = 2, Name = "DIY & Crafts" });
            _categories.Add(new CategoryEntity() { Id = 3, Name = "Gardening" });
            _categories.Add(new CategoryEntity() { Id = 4, Name = "History" });
            _categories.Add(new CategoryEntity() { Id = 5, Name = "Outdoors" });
            _categories.Add(new CategoryEntity() { Id = 6, Name = "Sports" });
            _categories.Add(new CategoryEntity() { Id = 7, Name = "Women's Fashion" });
            _categories.Add(new CategoryEntity() { Id = 8, Name = "Architecture" });
            _categories.Add(new CategoryEntity() { Id = 9, Name = "Design" });
            _categories.Add(new CategoryEntity() { Id = 10, Name = "Geek" });
            _categories.Add(new CategoryEntity() { Id = 11, Name = "Home Decor" });
            _categories.Add(new CategoryEntity() { Id = 12, Name = "Photography" });
            _categories.Add(new CategoryEntity() { Id = 13, Name = "Tatoos" });
            _categories.Add(new CategoryEntity() { Id = 14, Name = "Videos" });
            _categories.Add(new CategoryEntity() { Id = 15, Name = "Art" });
            _categories.Add(new CategoryEntity() { Id = 16, Name = "Education" });
            _categories.Add(new CategoryEntity() { Id = 17, Name = "Health & Fitness" });
            _categories.Add(new CategoryEntity() { Id = 18, Name = "Illustration" });
            _categories.Add(new CategoryEntity() { Id = 19, Name = "Illustration & Posters" });
            _categories.Add(new CategoryEntity() { Id = 20, Name = "Products" });
            _categories.Add(new CategoryEntity() { Id = 21, Name = "Technology" });
            _categories.Add(new CategoryEntity() { Id = 22, Name = "Cars & Motocycles" });
            _categories.Add(new CategoryEntity() { Id = 23, Name = "Film, Music & Books" });
            _categories.Add(new CategoryEntity() { Id = 24, Name = "Hear & Beauty" });
            _categories.Add(new CategoryEntity() { Id = 25, Name = "Kids" });
            _categories.Add(new CategoryEntity() { Id = 26, Name = "Quotes" });
            _categories.Add(new CategoryEntity() { Id = 27, Name = "Travel" });
            _categories.Add(new CategoryEntity() { Id = 28, Name = "Celebrities" });
            _categories.Add(new CategoryEntity() { Id = 29, Name = "Food & Drink" });
            _categories.Add(new CategoryEntity() { Id = 30, Name = "Holidays & Events" });
            _categories.Add(new CategoryEntity() { Id = 31, Name = "Men's Fashions" });
            _categories.Add(new CategoryEntity() { Id = 32, Name = "Scince & Natur" });
            _categories.Add(new CategoryEntity() { Id = 33, Name = "Weddings" });
        }

        #endregion

        public void Dispose()
        {
            _categories.Clear();
        }

        public CategoryEntity Get(int id)
        {
            return _categories.SingleOrDefault(r => r.Id == id);
        }

        public Collection<CategoryEntity> GetAll()
        {
            return _categories;
        }
    }
}
