using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WishList_Repository;
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
            Collection<UserPostEntity> posts = Repository.UserPostRepositoryInstance.Get(1, 1);
            Collection<UserEntity> users = Repository.UserRepositoryInstance.GetAll();

            Collection<PinViewModel> Pins = new Collection<PinViewModel>();

            foreach (UserPostEntity post in posts)
            {
                Collection<CommentEntity> comments = Repository.CommentRepositoryInstance.GetAllByPostId(post.Id);

                Pins.Add(new PinViewModel { UserPost = post, Users = users, Comments = comments });
            }

            return View(Pins);
        }

    }
}
