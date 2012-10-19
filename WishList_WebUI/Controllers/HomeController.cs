using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WishList_Repository.DBEntities;
using System.Collections.ObjectModel;
using WishList_WebUI.Models;

namespace WishList_WebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Home()
        {
            // for testing
            //var t1 = WishList_Repository.Repository.UserRepositoryInstance;
            //var t2 = WishList_Repository.Repository.UserFollowingRepositoryInstance;
            //var t3 = WishList_Repository.Repository.UserPostRepositoryInstance;
            //var t4 = WishList_Repository.Repository.CommentRepositoryInstance;
            //var t5 = WishList_Repository.Repository.CategoryRepositoryInstance;

			Collection<UserPostEntity> posts = WishList_Repository.Repository.UserPostRepositoryInstance.Get(1, 1);

			Collection<PinViewModel> Pins = new Collection<PinViewModel>();

			foreach (UserPostEntity post in posts)
			{
				Collection<CommentEntity> comments = WishList_Repository.Repository.CommentRepositoryInstance.GetAllByPostId(post.Id);
				Pins.Add(new PinViewModel(post, comments));
			}

			return View(Pins);
        }

    }
}
