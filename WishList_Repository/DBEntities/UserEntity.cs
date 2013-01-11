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
        /// <summary>
        /// Gets or sets the user Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the user password salt
        /// </summary>
		public string PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets the user name
        /// </summary>
		public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the user's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the user's photo
        /// </summary>
        public string UserPhoto { get; set; }

        /// <summary>
        /// Gets or sets the user's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the created date
        /// </summary>
        public DateTime CreatedUTC { get; set; }

        /// <summary>
        /// Gets or sets the last last login date
        /// </summary>
		public DateTime LastLoginDate { get; set; }

        /// <summary>
        /// Gets or sets the bussines rule list
        /// </summary>
        public Collection<int> BusinessRuleIdList { get; set; }

        /// <summary>
        /// Gets or sets the user setting Id
        /// </summary>
        public int UserSettingId { get; set; }

        /// <summary>
        /// Gets or sets is user activated
        /// </summary>
        public bool IsActivated { get; set; }

        /// <summary>
        /// Gets or sets is user locked
        /// </summary>
		public bool IsLockedOut { get; set; }

        /// <summary>
        /// Gets or sets last locked date
        /// </summary>
		public DateTime LastLockedOutDate { get; set; }
    }
}
