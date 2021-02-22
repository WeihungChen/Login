using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using AuthorityAPI.SQL;
using Newtonsoft.Json;

namespace AuthorityAPI
{
    internal class UserManager
    {
        private int _timeout = 5;
        private UserDB userDB = new UserDB();
        private string cookieKey = "delicious_cookie";

        public void Login(string user, string password)
        {
            var idx = userDB.Login(user, password);
            DateTime expires = DateTime.Now.AddMinutes(_timeout);
            var ticket = new FormsAuthenticationTicket(1
                , user
                , DateTime.Now
                , expires
                , true
                , JsonConvert.SerializeObject(idx)
                , FormsAuthentication.FormsCookiePath);
            var encTicket = FormsAuthentication.Encrypt(ticket);
            HttpContext.Current.Session.Timeout = _timeout;
            HttpContext.Current.Session.Add(idx, expires);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(cookieKey)
            {
                Value = encTicket
            });
        }

        public void Logout()
        {
            var cookie = HttpContext.Current.Request.Cookies[cookieKey];
            if (cookie == null)
                return;
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string userIdx = JsonConvert.DeserializeObject<string>(ticket.UserData);
            HttpContext.Current.Session.Remove(userIdx);
            HttpContext.Current.Response.Cookies[cookieKey].Expires = DateTime.Now.AddYears(-1);
        }

        public bool Register(string user, string password)
        {
            if (user == string.Empty || password == string.Empty)
                return false;
            if(!userDB.UserExist(user))
                return userDB.AddNewUser(user, password);
            throw new CustomException("User has already registered!!");
        }

        public List<string> PageAuthority()
        {
            List<string> pages = new List<string>();
            if (IsExpired(out string userIdx))
                return pages;
            return userDB.GetAuthority(userIdx).PageNames;
        }

        public bool IsExpired(out string userIdx)
        {
            var cookie = HttpContext.Current.Request.Cookies[cookieKey];
            if (cookie == null)
            {
                userIdx = string.Empty;
                return true;
            }
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            userIdx = JsonConvert.DeserializeObject<string>(ticket.UserData);
            var session = HttpContext.Current.Session[userIdx];
            if (session == null)
            {
                HttpContext.Current.Response.Cookies.Remove(cookieKey);
                return true;
            }
            if (DateTime.Now > Convert.ToDateTime(session))
            {
                HttpContext.Current.Session.Remove(userIdx);
                HttpContext.Current.Response.Cookies[cookieKey].Expires = DateTime.Now.AddYears(-1);
                return true;
            }
            return false;
        }

        public void UpdateExpires()
        {
            var cookie = HttpContext.Current.Request.Cookies[cookieKey];
            if (cookie == null)
                throw new CustomException("Please login first!!");
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string userIdx = JsonConvert.DeserializeObject<string>(ticket.UserData);
            HttpContext.Current.Session[userIdx] = DateTime.Now.AddMinutes(_timeout);
        }

        public string[] GetAllPages()
        {
            return userDB.GetAllPageNames();
        }

        public bool ChangePageAuthority(string page, bool isOpen)
        {
            var cookie = HttpContext.Current.Request.Cookies[cookieKey];
            if (cookie == null)
                throw new CustomException("Please login first!!");
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string userIdx = JsonConvert.DeserializeObject<string>(ticket.UserData);

            return userDB.ChangePageAuthority(Convert.ToInt32(userIdx), page, isOpen);
        }

        public string[] GetAllowedPages()
        {
            var cookie = HttpContext.Current.Request.Cookies[cookieKey];
            if (cookie == null)
                throw new CustomException("Please login first!!");
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string userIdx = JsonConvert.DeserializeObject<string>(ticket.UserData);

            return userDB.GetAllowedPages(Convert.ToInt32(userIdx));
        }
    }
}