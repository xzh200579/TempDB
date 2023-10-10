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
    public class SalaController : Controller
    {

        SalaStandDAO standDAO = new SalaStandDAO();
        // GET: Sala
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpdateSala()
        {
            return View();
        }

        public ActionResult InquireIndex()
        {
            return View();
        }

        public ActionResult SalaAlter()
        {
            return View();
        }

        /// <summary>
        /// 打开标准薪酬登记
        /// </summary>
        /// <returns></returns>
        public ActionResult Grade(string condition)
        {
            ViewBag.s = condition;
            return View();
        }


        public ActionResult BianGen()
        {
            return View();
        }
        /// <summary>
        /// 打开标准薪酬变更
        /// </summary>
        /// <param name="tiao"></param>
        /// <returns></returns>
        public ActionResult ChangeAlter(string condition)
        {
            ViewBag.s = condition;
            return View();
        }
        /// <summary>
        /// 显示登记复核
        /// </summary>
        /// <param name="fy"></param>
        /// <returns></returns>
        public async Task<ActionResult> IndexSala(FenYe<Salary_standard> fy)
        {
            fy = await standDAO.CharSelect(fy);
            return Json(fy, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateSuree()
        {
            return View();
        }

        /// <summary>
        /// 查询单个信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> UpdateSala(string id)
        {
            ViewBag.s = await standDAO.Detail(id);
            return View();
        }

        /// <summary>
        /// 薪酬标准登记
        /// </summary>
        /// <param name="jin"></param>
        /// <param name="name"></param>
        /// <param name="bh"></param>
        /// <param name="salary"></param>
        /// <returns></returns>
        public async Task<ActionResult> TianShi(string TotalAmount, string name, string XCnumbering, Salary_standard salary)
        {
            int cg = await standDAO.Addto(TotalAmount, name, XCnumbering, salary);
            if (cg == 0)
            {
                return Content("0");
            }
            else
            {
                return Content("1");
            }
        }

            /// <summary>
            /// 修改事务
            /// </summary>
            /// <param name="id"></param>
            /// <param name="TotalAmount"></param>
            /// <param name="salary"></param>
            /// <returns></returns>
        public async Task<ActionResult> UpdateSX(string id,string TotalAmount, Salary_standard salary)
        {
            int xg = await standDAO.UpdateRevise(id, TotalAmount, salary);
            if (xg == 0)
            {
                return Content("0");
            }else
            {
                return Content("1");
            }
        }


        /// <summary>
        /// 薪酬标准查询
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public async Task<ActionResult> MoObscure(int PageSize, int CurrentPage, string Condition)
        {
            FenYe<Salary_standard> obs = await standDAO.InquireSelect(PageSize, CurrentPage, Condition);
            return Json(obs, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 薪酬详情查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Salarydetails(string id)
        {
            ViewBag.s = await standDAO.Detail(id);
            return View();
        }

        /// <summary>
        /// 薪酬标准变更
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> SalarydetailsTwo(string id)
        {
            ViewBag.s = await standDAO.Detail(id);
            return View();
        }


        /// <summary>
        /// 薪酬标准变更修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Total"></param>
        /// <param name="salary"></param>
        /// <returns></returns>
        public async Task<ActionResult> StanChanges(string id, string Total, Salary_standard salary)
        {
            int xg = await standDAO.StanChanges(id, Total, salary);
            if (xg == 0)
            {
                return Content("0");
            }
            else
            {
                return Content("1");
            }
        }


    }
}