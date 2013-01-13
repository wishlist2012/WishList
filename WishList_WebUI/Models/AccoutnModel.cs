using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WishList_WebUI.Models
{
	public class RegisterModel
	{
		[Required]
		public string UserName { get; set; }

        public string UserPhoto { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]		
		public string Email { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]		
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
	}

	public class LogOnModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		
		public bool RememberMe { get; set; }
	}

	public class ChangePasswordModel
	{
		[Required]
		[DataType(DataType.Password)]
		public string OldPassword { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

	}
}