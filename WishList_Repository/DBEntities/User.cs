using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WishList_Repository.DBEntities
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public DateTime CreatedUTC { get; set; }
    }
}
