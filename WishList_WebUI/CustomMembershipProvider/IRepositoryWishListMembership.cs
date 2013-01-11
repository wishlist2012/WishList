using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WishList_WebUI.CustomMembershipProvider
{
	public interface IRepositoryWishListMembership
	{
        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="status"></param>
        /// <returns>status creation</returns>
		MembershipUser CreateUser(string userName, string firstName, string lastName, string email, string password, out MembershipCreateStatus status);
	}
}