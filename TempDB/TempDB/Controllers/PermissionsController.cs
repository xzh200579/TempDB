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
    public class PermissionsController : Controller
    {

        PermissionsDAO permissions = new PermissionsDAO();
         UsersDAO usersDAO = new UsersDAO();
        RolesDAO rolesDAO = new RolesDAO();
        // GET: Permissions/Role
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 打开添加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddTwo()
        {
            return View();
        }


        /// <summary>
        ///打开角色管理添加 
        /// </summary>
        /// <returns></returns>
        public ActionResult Insert()
        {
            return View();
        }
        /// <summary>
        /// 进行添加角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task<ActionResult> Tianj(Roles roles)
        {
            int cg = await rolesDAO.Tian(roles);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }

        /// <summary>
        /// 打开角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Role()
        {
            return View();
        }

        /// <summary>
        /// 角色管理显示
        /// </summary>
        /// <param name="fy"></param>
        /// <returns></returns>
        public async Task<ActionResult> pagination(FenYe<Roles> fy)
        {
            fy = await rolesDAO.CharSelect(fy);
            return Json(fy, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 角色管理进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> JueSc(int id)
        {
            int ji = await usersDAO.Ji(id);
            if (ji > 0)
            {
                return Content("2");
            }
            else
            {
                int cg = await rolesDAO.ScAsync(id);
                if (cg > 0)
                {
                    return Content("1");
                }
                else
                {
                    return Content("0");
                }
            }
        }
        /// <summary>
        /// 进行添加
        /// </summary>
        /// <param name="zh"></param>
        /// <param name="mi"></param>
        /// <param name="name"></param>
        /// <param name="zw"></param>
        /// <returns></returns>
        public async Task<ActionResult> Tj(string zh, string mi, string name, int zw)
        {
            int cg = await usersDAO.TianAsync(zh, mi, name, zw);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }
        /// <summary>
        /// 查询用户管理
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Display()
        {
            IEnumerable<Users> use = await permissions.ChaSyAsync1();
            return Json(use, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 打开编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            ViewBag.s = id;
            return View();
        }

        /// <summary>
        /// 进行显示下拉框
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Xiadownbox()
        {
            IEnumerable<Roles> roles = await rolesDAO.downbox();
            return Json(roles, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 显示详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Xju(string id)
        {
            Users u = await usersDAO.ChaZwMo(id);
            return Json(u, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int id)
        {
            int gc = await permissions.ScAsync(id);
            if (gc > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }

        /// <summary>
        /// 进行修改
        /// </summary>
        /// <param name="zh"></param>
        /// <param name="mi"></param>
        /// <param name="name"></param>
        /// <param name="zw"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Xiu(string zh, string mi, string name, int zw, int id)
        {
            int cg = await usersDAO.XiuAsync(zh, mi, name, zw, id);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }
    }
}