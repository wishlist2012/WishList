using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WishList_WebUI.CustomMembershipProvider
{
	public interface IRepositoryWishListMembership
	{
		MembershipUser CreateUser(string userName, string firstName, string lastName, string email, string password, out MembershipCreateStatus status);
	}
}