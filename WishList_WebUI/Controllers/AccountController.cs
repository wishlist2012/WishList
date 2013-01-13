using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Net;
using System.IO;
using Facebook;
using Newtonsoft.Json.Linq;
using WishList_WebUI.Models;
using WishList_WebUI.CustomMembershipProvider;

namespace WishList_WebUI.Controllers
{
    public class AccountController : Controller
    {
		/// <summary>
		/// Get new instance of WishListMembershipProvider
		/// </summary>
		/// <returns></returns>
		private static IRepositoryWishListMembership _wishListMembershipProvider;
		public static IRepositoryWishListMembership WishListMembershipProvider
		{
			get
			{
				if (_wishListMembershipProvider == null)
					_wishListMembershipProvider = new WishListMembershipProvider();

				return _wishListMembershipProvider;
			}
		} 

		//
		// GET: /Account/LogOn

		public ActionResult LogOn()
		{
			return View();
		}

		//
		// POST: /Account/LogOn

		[HttpPost]
		public ActionResult LogOn(LogOnModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				if (Membership.ValidateUser(model.Email, model.Password))
				{
					FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
					if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
						&& !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
					{
						return Redirect(returnUrl);
					}
					else
					{
						return RedirectToAction("Home", "Home");
					}
				}
				else
				{
					ModelState.AddModelError("", "The email or password provided is incorrect.");
				}
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		//
		// GET: /Account/LogOff

		public ActionResult LogOff()
		{
			FormsAuthentication.SignOut();

			return RedirectToAction("Home", "Home");
		}

		//
		// GET: /Account/Register

		public ActionResult Register()
		{
			return View();
		}

		//
		// POST: /Account/Register

		[HttpPost]
		public ActionResult Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				// Attempt to register the user
				MembershipCreateStatus createStatus;
				WishListMembershipProvider.CreateUser(model.UserName, model.FirstName, model.LastName, model.Email, model.Password, out createStatus);

				if (createStatus == MembershipCreateStatus.Success)
				{
					FormsAuthentication.SetAuthCookie(model.Email, false /* createPersistentCookie */);
					return RedirectToAction("Home", "Home");
				}
				else
				{
					ModelState.AddModelError("", ErrorCodeToString(createStatus));
				}
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		//
		// GET: /Account/ChangePassword

		[Authorize]
		public ActionResult ChangePassword()
		{
			return View();
		}

		//
		// POST: /Account/ChangePassword

		[Authorize]
		[HttpPost]
		public ActionResult ChangePassword(ChangePasswordModel model)
		{
			if (ModelState.IsValid)
			{

				// ChangePassword will throw an exception rather
				// than return false in certain failure scenarios.
				bool changePasswordSucceeded;
				try
				{
					MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
					changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
				}
				catch (Exception)
				{
					changePasswordSucceeded = false;
				}

				if (changePasswordSucceeded)
				{
					return RedirectToAction("ChangePasswordSuccess");
				}
				else
				{
					ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
				}
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		//
		// GET: /Account/ChangePasswordSuccess

		public ActionResult ChangePasswordSuccess()
		{
			return View();
		}

        //
        // GET: /Account/LoginWithFacebook
        
        public ActionResult LoginWithFacebook()
        {
            string req = string.Format("https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri=http://{1}/Account/ReturnFromFacebook&scope=user_about_me,user_hometown,user_location,email,offline_access", System.Web.Configuration.WebConfigurationManager.AppSettings["facebookAppId"], System.Web.Configuration.WebConfigurationManager.AppSettings["DomainName"]);
            return Redirect(req);
        }

        //
        // POST: /Account/LoginWithFacebook

        public ActionResult ReturnFromFacebook()
        {
            string code = Request.QueryString["code"];

            if (code == null)
            {
                return RedirectToAction("Home", "Home");
            }

            string AccessToken = "";
            try
            {
                if (code != null)
                {
                    string str = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri=http://{1}/Account/ReturnFromFacebook&client_secret={2}&code={3}", System.Web.Configuration.WebConfigurationManager.AppSettings["facebookAppId"], Request.Url.Authority, System.Web.Configuration.WebConfigurationManager.AppSettings["facebookAppSecret"], code);
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(str);
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    byte[] Param = Request.BinaryRead(System.Web.HttpContext.Current.Request.ContentLength);
                    string strRequest = System.Text.Encoding.ASCII.GetString(Param);

                    req.ContentLength = strRequest.Length;

                    StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
                    streamOut.Write(strRequest);
                    streamOut.Close();
                    StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
                    string strResponse = streamIn.ReadToEnd();
                    if (strResponse.Contains("&expires"))
                        strResponse = strResponse.Substring(0, strResponse.IndexOf("&expires"));
                    AccessToken = strResponse.Replace("access_token=", "");
                    streamIn.Close();
                }

                Facebook.FacebookAPI api = new Facebook.FacebookAPI(AccessToken);
                string request = "/me";

                JSONObject fbobject = api.Get(request);
                try
                {
                    ViewBag.FacebookID = fbobject.Dictionary["id"].String;
                    ViewBag.FirstName = fbobject.Dictionary["first_name"].String;
                    ViewBag.LastName = fbobject.Dictionary["last_name"].String;
                    ViewBag.Email = fbobject.Dictionary["email"].String;

                    //Here we can get all data using fbobject.Dictionary

                    string str = string.Format("http://graph.facebook.com/{0}?fields=picture&type=normal", fbobject.Dictionary["id"].String);
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(str);
                    StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
                    string strResponse = streamIn.ReadToEnd();
                    JObject je = new JObject();
                    je = JObject.Parse(strResponse);                    
                    string pictureuser = je["picture"]["data"]["url"].ToString();
                    
                    ViewBag.Photo = pictureuser;

                    FormsAuthentication.SetAuthCookie(ViewBag.Email, true);

                }
                catch (Exception ex)
                {
                    //errorLog.setError(ex, "LoginController.SaveFacebookData");
                }
            }
            catch (Exception ex)
            {
                //errorLog.setError(ex, "LoginController.returnfromfb");
            }
            return RedirectToAction("Home", "Home");
        }

		#region Status Codes
		private static string ErrorCodeToString(MembershipCreateStatus createStatus)
		{
			// See http://go.microsoft.com/fwlink/?LinkID=177550 for
			// a full list of status codes.
			switch (createStatus)
			{
				case MembershipCreateStatus.DuplicateUserName:
					return "User name already exists. Please enter a different user name.";

				case MembershipCreateStatus.DuplicateEmail:
					return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

				case MembershipCreateStatus.InvalidPassword:
					return "The password provided is invalid. Please enter a valid password value.";

				case MembershipCreateStatus.InvalidEmail:
					return "The e-mail address provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidAnswer:
					return "The password retrieval answer provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidQuestion:
					return "The password retrieval question provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidUserName:
					return "The user name provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.ProviderError:
					return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				case MembershipCreateStatus.UserRejected:
					return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				default:
					return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
			}
		}
		#endregion
	}
}
