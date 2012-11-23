using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Collections.Specialized;
using WishList_Repository;
using WishList_Repository.DBEntities;

namespace WishList_WebUI.CustomMembershipProvider
{
	public class WishListMembershipProvider : MembershipProvider, IRepositoryWishListMembership
	{

		/// <summary>
		/// Default constructor
		/// </summary>
		public WishListMembershipProvider() { }


		/// <summary>
		/// Properties from web.config
		/// </summary>
		private string _ApplicationName;
		private bool _EnablePasswordReset;
		private bool _EnablePasswordRetrieval = false;
		private bool _RequiresQuestionAndAnswer = false;
		private bool _RequiresUniqueEmail = true;
		private int _MaxInvalidPasswordAttempts;
		private int _PasswordAttemptWindow;
		private int _MinRequiredPasswordLength;
		private int _MinRequiredNonalphanumericCharacters;
		private string _PasswordStrengthRegularExpression;
		private MembershipPasswordFormat _PasswordFormat = MembershipPasswordFormat.Hashed;

		public override void Initialize(string name, NameValueCollection config)
		{
			if (config == null)
				throw new ArgumentException("config");

			if (name == null || name.Length == 0)
				name = "CustomMembershipProvider";

			if (string.IsNullOrEmpty(config["description"]))
			{
				config.Remove("description");
				config.Add("description", "WishList Membership Provider");
			}

			base.Initialize(name, config);

			_ApplicationName = GetConfigValue(config["applicationName"], System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
			_MaxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "50"));
			_PasswordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));
			_MinRequiredNonalphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredNonalphanumericCharacters"], "0"));
			_MinRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "1"));
			_EnablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "true"));
			_PasswordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], ""));
		}


		public override string ApplicationName
		{
			get	{ return _ApplicationName; }
			set { _ApplicationName = value; }
		}

		public override bool ChangePassword(string username, string oldPassword, string newPassword)
		{
			throw new NotImplementedException();
		}

		public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
		{
			return false;
		}

		public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
		{
			throw new NotImplementedException();
		}

		public MembershipUser CreateUser(string userName, string firstName, string lastName, string email, string password, out MembershipCreateStatus status)
		{
			ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(userName, password, true);
			
			OnValidatingPassword(args);

			if (args.Cancel)
			{
				status = MembershipCreateStatus.InvalidPassword;
				return null;
			}

			if (RequiresUniqueEmail)
			{
				if (!Repository.UserRepositoryInstance.IsUniqueEmail(email))
				{
					status = MembershipCreateStatus.DuplicateEmail;
					return null;
				}
			}

			if (!string.IsNullOrEmpty(Repository.UserRepositoryInstance.GetUserNameByEmail(email)))
			{
				status = MembershipCreateStatus.DuplicateUserName;
				return null;
			}

			MembershipUser user = GetUser(userName);
			if (user == null)
			{
				bool newUser = Repository.UserRepositoryInstance.Create(userName, firstName, lastName, email, password);
				status = MembershipCreateStatus.Success;

				return GetUser(userName, false);
			}
			else
			{
				status = MembershipCreateStatus.DuplicateUserName;
			}

			return null;
		}

		public override bool DeleteUser(string username, bool deleteAllRelatedData)
		{
			throw new NotImplementedException();
		}

		public override bool EnablePasswordReset
		{
			get { return _EnablePasswordReset; }
		}

		public override bool EnablePasswordRetrieval
		{
			get { return _EnablePasswordRetrieval; }
		}

		public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override int GetNumberOfUsersOnline()
		{
			throw new NotImplementedException();
		}

		public override string GetPassword(string username, string answer)
		{
			throw new NotImplementedException();
		}

		public override MembershipUser GetUser(string username, bool userIsOnline)
		{
			return GetUser(username);
		}

		public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
		{
			throw new NotImplementedException();
		}

		public override string GetUserNameByEmail(string email)
		{
			throw new NotImplementedException();
		}

		public override int MaxInvalidPasswordAttempts
		{
			get { return _MaxInvalidPasswordAttempts; }
		}

		public override int MinRequiredNonAlphanumericCharacters
		{
			get { return _MinRequiredNonalphanumericCharacters; }
		}

		public override int MinRequiredPasswordLength
		{
			get { return _MinRequiredPasswordLength; }
		}

		public override int PasswordAttemptWindow
		{
			get { return _PasswordAttemptWindow; }
		}

		public override MembershipPasswordFormat PasswordFormat
		{
			get { return _PasswordFormat; }
		}

		public override string PasswordStrengthRegularExpression
		{
			get { return _PasswordStrengthRegularExpression; }
		}

		public override bool RequiresQuestionAndAnswer
		{
			get { return _RequiresQuestionAndAnswer; }
		}

		public override bool RequiresUniqueEmail
		{
			get { return _RequiresUniqueEmail; }
		}

		public override string ResetPassword(string username, string answer)
		{
			throw new NotImplementedException();
		}

		public override bool UnlockUser(string userName)
		{
			throw new NotImplementedException();
		}

		public override void UpdateUser(MembershipUser user)
		{
			throw new NotImplementedException();
		}

		public override bool ValidateUser(string email, string password)
		{
			return Repository.UserRepositoryInstance.ValidateUser(email, password);			
		}
		

		/// <summary>
		/// Helper Methods
		/// </summary>
		#region Helper Methods

		private string GetConfigValue(string configValue, string defaultValue)
		{
			return (string.IsNullOrEmpty(configValue)) ? defaultValue : configValue;
		}

		private static MembershipUser GetUser(string userName)
		{
			UserEntity newUser = Repository.UserRepositoryInstance.GetUserByUserName(userName);
			if (newUser != null)
			{
				string _username = newUser.UserName;
				int _providerUserKey = newUser.Id;
				string _email = newUser.Email;
				string _passwordQuestion = String.Empty;
				string _comment = String.Empty;
				bool _isApproved = newUser.IsActivated;
				bool _isLockedOut = newUser.IsLockedOut;
				DateTime _creationDate = newUser.CreatedUTC;
				DateTime _lastLoginDate = newUser.LastLoginDate;
				DateTime _lastActivityDate = DateTime.Now;
				DateTime _lastPasswordChangedDate = DateTime.Now;
				DateTime _lastLockedOutDate = newUser.LastLockedOutDate;

				MembershipUser user = new MembershipUser("CustomMembershipProvider",
					_username,
					_providerUserKey,
					_email,
					_passwordQuestion,
					_comment,
					_isApproved,
					_isLockedOut,
					_creationDate,
					_lastLoginDate,
					_lastActivityDate,
					_lastPasswordChangedDate,
					_lastLockedOutDate);

				return user;
			}

			return null;
		}

		#endregion
	}
}