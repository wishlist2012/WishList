using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            return View();
        }

    }
}
