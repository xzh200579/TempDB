using DAO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TempDB.Controllers
{
    public class UsersController : Controller
    {   
        
        UsersDAO ud = new UsersDAO();


        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectUser()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> SelectUserTwo(string name,string password)
        {

            Users u = await ud.ChaXunUserAsync(name, password);
            return Content(u.u_name);
            
        }
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> UserYH()
        {
            IEnumerable<Users> users = await ud.ChaSyAsync();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}