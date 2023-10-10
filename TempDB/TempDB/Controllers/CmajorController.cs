using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DAO;
using Model;

namespace TempDB.Controllers
{
    public class CmajorController : Controller
    {
        CmajorDAO cmajorDAO = new CmajorDAO();
       CmkindDAO mkindDAO = new CmkindDAO();

        public async Task<ActionResult> Index()
        {
            return View();
        }
        public async Task<ActionResult> Index1()
        {
            IEnumerable<config_major> cx = await cmajorDAO.MajorSelect();
            return Json(cx, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Insert()
        {
            await GetDropList1();
            return View();
        }

        public async Task<ActionResult> Insert1(config_major config_Major)
        {
                int result = await cmajorDAO.MojorInsert(config_Major);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            
          
        }

        private async Task GetDropList()
        {
            IEnumerable<config_major> ptables = await cmajorDAO.MajorSelect();
            SelectList selectListItems = new SelectList(ptables, "major_kind_name", "major_kind_id");
            ViewBag.s = selectListItems;

          
        }

            public async Task<ActionResult> MajorDelete1(int id)
        {
            int result = await cmajorDAO.MojorDelete(id);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public async Task<ActionResult> MajorAdd(config_major c)
        {
            int result = await cmajorDAO.Config_majorInsertAsync111(c);
            if (result > 0)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                return View(c);
            }
        }
        public async Task GetDropList1()
        {

            IEnumerable<config_major_kind> id = await cmajorDAO.Config_major_kindSelectAsync111();
            SelectList selectListItems = new SelectList(id, "major_kind_name", "major_kind_id");
            ViewBag.s1 = selectListItems;
        }

    }
}