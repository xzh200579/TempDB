using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DAO;
using Model;

namespace TempDB.Controllers
{
    public class CmkindController : Controller
    {
        CmkindDAO mkindDAO = new CmkindDAO();

        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> Index1()
        {
            IEnumerable<config_major_kind> cx = await mkindDAO.MkindSelete();
            return Json(cx, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> MikindDelete1(int id) {
            int result = await mkindDAO.MkindDelete(id);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public async Task<ActionResult> Insert()
        {
            return View();
        }
        public async Task<ActionResult> Insert1(config_major_kind config_Major_Kind)
        {
            int result = await mkindDAO.MkindInsert(config_Major_Kind);
            if (result > 0)
            {
                return RedirectToAction("/Index");
            }
            else
            {
                return View(config_Major_Kind);
            }
        }

    }
}