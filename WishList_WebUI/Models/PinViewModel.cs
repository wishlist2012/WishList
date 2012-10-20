using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WishList_Repository.DBEntities;
using System.Collections.ObjectModel;

namespace WishList_WebUI.Models
{
	public class PinViewModel
	{
		public UserPostEntity UserPost { get; set; }
		public Collection<UserEntity> Users { get; set; }
		public Collection<CommentEntity> Comments { get; set; }		
	}
}