using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DAO;
using Model;

namespace TempDB.Controllers
{
    public class CfthirdkController : Controller
    {
        CfthirdkDAO Cfthirdk = new CfthirdkDAO();

        // GET: Cfthirdk
        public ActionResult Index()
        {
            return View();
        }
        
        public async Task<ActionResult> FindThree()
        {
            return Json(await Cfthirdk.ThreeSelectTypeAsync(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DelectThree()
        {
            return View();
        }
        public ActionResult UpdateSuree()
        {
            return View();
        }

        [HttpGet] 
        public async Task<int> DeleteThree(int id)
        {
            return await Cfthirdk.ThreeDelectAsync(id);
        }

        /// <summary>
        /// 打开修改页面加载信息
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateThree()
        {
            return View();
        }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<int> IntsetXZ(Config_file_third_kind config)
        {
            return await Cfthirdk.TinaThreeAsync(config);
        }
        /// <summary>
        /// 打开增加页面加载信息
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertThree()
        {
            return View();
        }
        /// <summary>
        /// 添加成功跳转
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertSucceed()
        {
            return View();
        }
        /// <summary>
        /// 修改成功跳转页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateXiuThree()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> UpdateThree(int id)
        {
            ViewBag.s = await Cfthirdk.ChaXunThreeAsync(id);
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> UpdateGai(Config_file_third_kind config)
        {
            int xg = await Cfthirdk.XiuGaiThree(config);
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