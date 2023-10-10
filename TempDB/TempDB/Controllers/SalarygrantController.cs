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
    public class SalarygrantController : Controller
    {
        SalarygrantDAO Salarygrant = new SalarygrantDAO();
        SalaStandDAO salaStand = new SalaStandDAO();
        SaladetailsDAO saladetails = new SaladetailsDAO();
        // GET: Salarygrant
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Suer()
        {
            return View();
        }

        /// <summary>
        /// 发放查询
        /// </summary>
        /// <returns></returns>
        public ActionResult IssueInquiries()
        {
            return View();
        }
        public ActionResult LssueMethod()
        {
            return View();
        }

        public ActionResult CheckTwo()
        {
            return View();
        }

        public ActionResult CheckIn(string tiao)
        {
            ViewBag.i = tiao;
            return View();
        }

        public ActionResult PayCheck(string id, string name)
        {
            ViewBag.s = id;
            ViewBag.i = name;
            return View();
        }


        public async Task<ActionResult> ChaJuTi(string tiao)
        {
            IEnumerable<Human_file> ie = await Salarygrant.SXuanAsync(tiao);
            return Json(ie, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ChaJuTiTwo(string id)
        {
            IEnumerable<Human_file> ie = await Salarygrant.SXuanAsync(id);
            return Json(ie, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Examine(string id)
        {
            IEnumerable<Salary_standard_details> ie = await saladetails.ChaYi(id);
            return Json(ie, JsonRequestBehavior.AllowGet);
        }
        
        public async Task<ActionResult> Den(List<Salary_grant_details> submittedDat, string djr, string time, List<Salary_grant> l, string id)
        {
            int cg = await Salarygrant.FindAsync(submittedDat, djr, time, l, id);
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
        /// 薪酬发放登记
        /// </summary>
        /// <param name="fy"></param>
        /// <returns></returns>
        public async Task<ActionResult> CheckSala(FenYe<Salary_grant> fy)
        {
            fy = await Salarygrant.CharXCSelect(fy);
            return Json(fy, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 薪酬发放复核查询
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bh"></param>
        /// <returns></returns>
        public ActionResult Checkfu(string id, string bh)
        {
            ViewBag.s = id;
            ViewBag.i = bh;
            return View();
        }

        /// <summary>
        /// 薪酬发放复核
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Review(string id)
        {
            ViewBag.s = await salaStand.Detail(id);
            return View();
        }

        public async Task<ActionResult> ChaTwo(string id)
        {
            IEnumerable<Salary_standard_details> ie = await saladetails.ChaYi(id);
            return Json(ie, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> FheCg(List<Salary_grant_details> submittedDat, string djr, string time, string jin, List<Human_file> h)
        {
            int cg = await Salarygrant.FuAsync(submittedDat, djr, time, jin, h);
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
        /// 发放查询
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public ActionResult CXun(string condition)
        {
            ViewBag.s = condition;
            return View();
        }

        public async Task<ActionResult> MoObscureTwo(int PageSize, int CurrentPage, string Condition)
        {
            FenYe<Salary_grant> obs = await Salarygrant.InquireSelectFF(PageSize, CurrentPage, Condition);
            return Json(obs, JsonRequestBehavior.AllowGet);
        }

        public ActionResult XSfa(string id)
        {
            ViewBag.s = id;
            return View();
        }

        public async Task<ActionResult> CFJu(string id)
        {
            IEnumerable<Salary_grant_details> de = await Salarygrant.ChaAsync(id);
            return Json(de, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> CFJu1(string id)
        {
            IEnumerable<Salary_standard_details> de = await Salarygrant.FaCha(id);
            return Json(de, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> CFJu2(string id)
        {
            Salary_grant de = await Salarygrant.ChaYi(id);
            return Json(de, JsonRequestBehavior.AllowGet);
        }
    }
}