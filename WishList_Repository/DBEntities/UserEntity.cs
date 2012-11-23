using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WishList_Repository.DBEntities
{
    /// <summary>
    /// User entity
    /// </summary>
    public class UserEntity
    {
        public int Id { get; set; }
        
        public string Password { get; set; }

		public string PasswordSalt { get; set; }

		public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

		public string UserPhoto { get; set; }

        public string Email { get; set; }

        public DateTime CreatedUTC { get; set; }

		public DateTime LastLoginDate { get; set; }

        public Collection<int> BusinessRuleIdList { get; set; }

        public int UserSettingId { get; set; }

        public bool IsActivated { get; set; }

		public bool IsLockedOut { get; set; }

		public DateTime LastLockedOutDate { get; set; }
    }
}
