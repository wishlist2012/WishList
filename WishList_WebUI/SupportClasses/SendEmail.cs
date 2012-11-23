using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace WishList_WebUI.SupportClasses
{
	public static class SendEmail
	{
		public static void SendRegisterEmail(string messageBody, string emailTo)
		{
			SmtpClient client = new SmtpClient();
			NetworkCredential basicAuthenticationInfo = new NetworkCredential("wishlistteam2012@gmail.com", "wishlist@2012");

			client.Host = "smtp.gmail.com";
			client.UseDefaultCredentials = false;
			client.Credentials = basicAuthenticationInfo;
			client.EnableSsl = true;

			MailAddress to = new MailAddress(emailTo);
			MailAddress from = new MailAddress("wishlistteam2012@gmail.com", "Account activation", System.Text.Encoding.UTF8);

			MailMessage message = new MailMessage(from, to);
			message.Body = messageBody;
			message.IsBodyHtml = true;
			message.BodyEncoding = System.Text.Encoding.UTF8;
			message.Subject = "Account activation";
			message.SubjectEncoding = System.Text.Encoding.UTF8;

			client.Send(message);
 
		}
	}
}