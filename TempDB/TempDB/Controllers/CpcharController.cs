using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DAO;
using Model;

namespace TempDB.Controllers
{
    public class CpcharController: Controller
    {
        CpcharDAO cpcharDAO=new CpcharDAO();
         public async Task<ActionResult> Index()
        {
            return View();
        }
        public async Task<ActionResult> Index2(FenYe<Config_public_char>fy)
        {
                fy=await cpcharDAO.CharSelect(fy);
                return Json(fy,JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Insert() {
            return View();
        }

        public ActionResult InsertThree()
        {
            return View();
        }
        [HttpPost]

        public async Task<ActionResult> Insert1(Config_public_char config_Public_Char)
        {
            if (ModelState.IsValid)
            {
                int result = await cpcharDAO.CharInsert(config_Public_Char);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(config_Public_Char);
                }
                 }
            else
            {
                return View(config_Public_Char);
            }

        }
        public async Task<ActionResult> CharDelete1(int id) {
            int result = await cpcharDAO.CharDelete(id);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public async Task<ActionResult> Index1() { 
        return View();
        }
        public async Task<ActionResult> XCIndex()
        {
            return View();
        }
        public async Task<ActionResult> Index3()
        {
            IEnumerable<Config_public_char> cx = await cpcharDAO.CharSelect1();
            return Json(cx, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> PayIndex()
        {
            return View();
        }

        public async Task<ActionResult> FindXC()
        {
            return Json(await cpcharDAO.XCSZ(), JsonRequestBehavior.AllowGet);
        }

        public async Task<int> FindDelete(int id)
        {
            return await cpcharDAO.XCDelectAsync(id);
        }
        public ActionResult TianAdd()
        {
            return View();
        }

        [HttpGet]
        public async Task<int> Intset(Config_public_char config)
        {
            return await cpcharDAO.XCTinaAsync(config);
        }
    }

}