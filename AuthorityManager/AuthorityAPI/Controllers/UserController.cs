using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using AuthorityAPI.Models;
using AuthorityAPI.Attribute;

namespace AuthorityAPI.Controllers
{
    [RoutePrefix("api/user")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private UserManager userManager = new UserManager();

        [User, Exception]
        [HttpPost, Route("pageauthority")]
        public List<string> PageAuthority()
        {
            return userManager.PageAuthority();
        }

        [User, Exception]
        [HttpPost, Route("login")]
        public IHttpActionResult LogIn([FromBody]dynamic data)
        {
            userManager.Login(Convert.ToString(data.user), Convert.ToString(data.password));
            return Ok("Login Success!!");
        }

        [User, Exception]
        [HttpGet, Route("logout")]
        public IHttpActionResult Logout()
        {
            userManager.Logout();
            return Ok("Logout!!");
        }

        [User, Exception]
        [HttpGet, Route("register_{user}_{password}")]
        public IHttpActionResult Register(string user, string password)
        {
            if (userManager.Register(user, password))
                return Ok("New User Added!!");
            throw new CustomException("Add user failed!!");
        }

        [User, Exception]
        [HttpPost, Route("isexpired")]
        public bool IsExpired()
        {
            return userManager.IsExpired(out string userIdx);
        }

        [User, Exception]
        [HttpGet, Route("getallpages")]
        public string[] GetAllPages()
        {
            return userManager.GetAllPages();
        }

        [Result, Exception, Authority]
        [HttpGet, Route("changepageauthority_{page}_{isOpen}")]
        public bool ChangePageAuthority(string page, bool isOpen)
        {
            userManager.ChangePageAuthority(page, isOpen);
            return true;
        }

        [Result, Exception, Authority]
        [HttpGet, Route("getallowedpages")]
        public string[] GetAllowedPages()
        {
            return userManager.GetAllowedPages();
        }
    }
}
