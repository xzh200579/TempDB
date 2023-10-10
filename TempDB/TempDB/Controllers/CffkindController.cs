using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dapper;
using DAO;
using Model;
using System.Web.UI.WebControls;

namespace TempDB.Controllers
{
    public class CffkindController : Controller
    {
        CffkindDAO cffkindDAO = new CffkindDAO();
        // GET: Cffkind

        public async Task<ActionResult> Index()
        {
            return View();
        }

        public ActionResult Insert()
        {
            return View();
        }
        //public ActionResult Update()
        //{
        //    return View();
        //}

        public ActionResult AddTo()
        {
            return View();
        }

        public ActionResult UpdateTo()
        {
            return View();
        }

        public async Task<ActionResult> Find()
        {
            return Json(await cffkindDAO.KindSelectTypeAsync(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<int> Delete(int id)
        {
            return await cffkindDAO.TreesDelectAsync(id);
        }
        [HttpGet]
        public async Task<int> Intset(Config_file_first_kind config)
        {
            return await cffkindDAO.TinaAsync(config);
        }
        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            ViewBag.s= await cffkindDAO.ChaXunAsync(id);
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> UpdateXiu(Config_file_first_kind config)
        {
            int xg = await cffkindDAO.XiuGai(config);
            if (xg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }

        /// <summary>
        /// III级机构级联查询
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> InsertLian()
        {
            IEnumerable<LevelTwo> ie = await cffkindDAO.ChaLianOne();
            return Json(ie, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Index()
        //{

        //    return View();
        //}
        //public async Task<ActionResult> FenYe(FenYe<Config_file_first_kind> fenYe)
        //{
        //    fenYe = await cffkindDAO.KindSelectTypeAsync(fenYe);
        //    return Json(fenYe, JsonRequestBehavior.AllowGet);
        //}
    }
}