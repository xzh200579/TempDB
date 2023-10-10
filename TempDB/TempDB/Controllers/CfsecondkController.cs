using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Model;
namespace TempDB.Controllers
{
    public class CfsecondkController : Controller
    {
        // GET: Cfsecondk
        CfsecondkDAO cfdao = new CfsecondkDAO();
        public async Task<ActionResult> Index()
        {
            return View();
        }
      
        /// <summary>
        /// 加载
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> FindTwo()
        {
            return Json(await cfdao.TwoKindSelectTypeAsync(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查询一级类型
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> CXOne()
        {
            return Json(await cfdao.XSTypeAsync(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 加载添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertTwo()
        {
            return View();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<int> Intset(Config_file_second_kind config)
        {
            return await cfdao.TinaTwoAsync(config);
        }
        /// <summary>
        /// 删除成功页面
        /// </summary>
        /// <returns></returns>
        public ActionResult DelectTwo()
        {
            return View();
        }

        /// <summary>
        /// 添加成功跳转页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddTwo()
        {
            return View();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<int> DeleteTwo(int id)
        {
            return await cfdao.TwoCDelectAsync(id);
        }

        /// <summary>
        /// 打开修改页面加载信息
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateTwo()
        {
            return View();
        }
        /// <summary>
        /// 修改成功跳转页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateXiuTwo()
        {
            return View();
        }
        /// <summary>
        /// 修改查询单个信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> UpdateTwo(int id)
        {
            ViewBag.s = await cfdao.ChaXunTwoAsync(id);
            return View();
        }
        /// <summary>
        /// 二级修改
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> UpdateXiuTwoTT(Config_file_second_kind config)
        {
            int xg = await cfdao.XiuGaiTwo(config);
            if (xg > 0)
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