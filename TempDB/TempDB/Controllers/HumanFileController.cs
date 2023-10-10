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
    public class HumanFileController : Controller
    {
        HumanFileDAO humanFileDAO = new HumanFileDAO();

        CfsecondkDAO cfsecondk = new CfsecondkDAO();

        SalaStandDAO salaStand = new SalaStandDAO();

        MchangeDAO Mchange = new MchangeDAO();

        CmkindDAO Cmkind = new CmkindDAO();
        // GET: HumanFile
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult IssueOne()
        {
            return View();
        }

        /// <summary>
        /// 调动审核
        /// </summary>
        /// <returns></returns>
        public ActionResult AuditOnew()
        {
            return View();
        }

        public ActionResult Suer()
        {
            return View();
        }
        public ActionResult MobilizeCX()
        {
            return View();
        }
        public ActionResult CkView(string id) {
            ViewBag.s = id;
            return View();
        }
        public async Task<ActionResult> Linkage()
        {
            IEnumerable<LevelTwo> ie = await cfsecondk.ChaLian1();
            return Json(ie, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LinkeTwo(string condition)
        {
            ViewBag.s = condition;
            return View();
        }

        
        public async Task<ActionResult> MoObscure(int PageSize, int CurrentPage, string Condition)
        {
            FenYe<Human_file> fenYe = await humanFileDAO.MoFen(PageSize, CurrentPage, Condition);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> MoObscureTwo(int PageSize, int CurrentPage, string Condition)
        {
            FenYe<Major_change> fenYe = await Mchange.MoFenTwo(PageSize, CurrentPage, Condition);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 调动登记详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult XQ(string id)
        {
            ViewBag.s = id;
            return View();
        }
        /// <summary>
        /// 调动审核
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ReviewOK(string id)
        {
            ViewBag.s = id;
            return View();
        }
        public async Task<ActionResult> ChaC1(string id)
        {
            Human_file human = await humanFileDAO.ChaYiAsync1(id);
            return Json(human, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 根据id查询所有
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> ChaC(string id)
        {
            Human_file human = await humanFileDAO.ChaYiAsync(id);
            return Json(human, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> SLian()
        {
            IEnumerable<LevelTwo> ie = await cfsecondk.ChaLian1();
            return Json(ie, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 进行查询职位
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Lian2()
        {
            IEnumerable<LevelTwo> ie = await Cmkind.ChaLian();
            return Json(ie, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Zui(string id)
        {
            Major_change change = await Mchange.changesAsync1(id);
            return Json(change, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 调动查询
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public ActionResult DInquire(string condition)
        {
            ViewBag.s = condition;
            return View();
        }
        /// <summary>
        /// 根据条件查询调动
        /// </summary>
        /// <param name="tiao"></param>
        /// <returns></returns>
        public async Task<ActionResult> Ck(int PageSize, int CurrentPage, string Condition)
        {
            FenYe<Major_change> fenYe = await Mchange.changesAsync(PageSize, CurrentPage, Condition);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Chaxin()
        {
            IEnumerable<Salary_standard> ie = await salaStand.Cha2();
            return Json(ie, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 进行查询总薪酬
        /// </summary>
        public async Task<ActionResult> CZong(string id)
        {
            int ie = await salaStand.Chajin(id);
            return Json(ie, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Xs1(string id)
        {
            Major_change change = await Mchange.Yg(id);
            return Json(change, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> AcaUpd(Major_change change, string tg)
        {
            if (tg == "通过")
            {
                int cg = await Mchange.Xiu(change);
                if (cg > 0)
                {
                    return Content("1");
                }
                else
                {
                    return Content("0");
                }
            }
            else
            {
                int cg = await Mchange.Xiu1(change);
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
        /// 进行调动的添加
        /// </summary>
        /// <param name="change"></param>
        /// <returns></returns>
        public async Task<ActionResult> Tina(Major_change change)
        {
            int cg = await humanFileDAO.Tian(change);
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