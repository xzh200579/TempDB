using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using DAO;
using Model;

namespace TempDB.Controllers
{
    public class EiController: Controller
    {
        EiDAO eiDAO=new EiDAO();
        public async Task<ActionResult> Index()
        {
            return View();
        }
        public async Task<ActionResult> Index2(FenYe<Engage_interview> fy)
        {
            fy = await eiDAO.EiSelect(fy);
            return Json(fy, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> EiSelectId(int id)
        {
            IEnumerable<Engage_interview> I = await eiDAO.EmSelect();
            SelectList selectListItems = new SelectList(I, "checker", "checker");
            ViewBag.u = selectListItems;
            Engage_interview se= await eiDAO.EiSelect2(id);
            ViewBag.d = await eiDAO.EnSelect3(se.resume_id);
            ViewBag.s = se;
            return View();
        }
        public async Task<ActionResult> MianShi_UPDATE(int id, int name, int bid)
        {
            int name2 = 0;
            if (name == 3)
            {
                name2 = 3;
            }
            else if (name == 2)
            {
                name2 = 2;
            }
            else if (name == 1)
            {
                name2 = 1;
            }
            int se2 = await eiDAO.GenGaiMianShi(bid, name2);
            int se = await eiDAO.MianShi_ZhuangTaiUPDATE(id, name);
            if (se > 0 & se2 > 0)
            {
                return RedirectToAction("/Ei/IndexLyCx");
            }
            else
            {
                return RedirectToAction("Index");
            

        }

    }
        public async Task<ActionResult> MianShiXG2(Engage_interview e)
        {
            int result = await eiDAO.MianShiXG2(e);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public async Task<ActionResult> IndexLyCx()
        {
            return View();
        }
        public async Task<ActionResult> Index2LyCx(FenYe<Engage_resume> fy)
        {
            fy = await eiDAO.ErSelect(fy);
            return Json(fy, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> ErSelectId(int id)
        {
            IEnumerable<Engage_interview> I = await eiDAO.EmSelect();
            SelectList selectListItems = new SelectList(I, "checker", "checker");
            ViewBag.u = selectListItems;
            Engage_interview se = await eiDAO.EiSelect2(id);
            ViewBag.d = await eiDAO.EnSelect3(se.resume_id);
            ViewBag.s = se;
            return View();
        }
        public async Task<ActionResult> MianShiXG1(Engage_interview e)
        {
            int result = await eiDAO.MianShiXG22(e);
            if (result > 0)
            {
                return RedirectToAction("/Ei/IndexLyCx");
            }
            else
            {
                return RedirectToAction("/Ei/IndexLyCx");
            }

        }
        public async Task<ActionResult> luyou_shenqin(string id, string name)
        {
            int re = await eiDAO.luyou_shenqin(id, name);
            if (re > 0)
            {
                return RedirectToAction("Lu_SP");
            }
            else
            {
                return Content("0");
            }
        }
        public async Task<ActionResult> luyou_shenqin11(string id, string name)
        {
            int re = await eiDAO.luyou_shenqin1(id, name);
            if (re > 0)
            {
                return RedirectToAction("Lu_CX");
            }
            else
            {
                return Content("0");
            }
        }
        public async Task<ActionResult> MianShi_DEL(int id, int id2)
        {
            int result = await eiDAO.mianshisc(id2);
            int result1 = await eiDAO.mianshisc1(id);
            if (result > 0 & result1 > 0)
            {
                return RedirectToAction("Index");
            }
            else {
                return RedirectToAction("Index");
            }
        }
        public async Task<ActionResult> Lu_SP(int? currentPage)
        {
            await shenpi(currentPage);
            return View();
        }
        /// <summary>
        ///   查询录用审批页面
        /// </summary>
        /// <param name="currentPage"></param>
        /// <returns></returns>
        public async Task shenpi(int? currentPage)
        {
            FenYe<Engage_resume> chars = await eiDAO.shenpi(currentPage);

            ViewBag.z = chars.Rows;
            ViewBag.s = chars.List;
            ViewBag.m = chars.CurrentPage;
            ViewBag.h = ++chars.CurrentPage;
            ViewBag.a = --chars.CurrentPage;

        }
        public async Task<ActionResult> ErSelectId1(int id)
        {
            IEnumerable<Engage_interview> I = await eiDAO.EmSelect();
            SelectList selectListItems = new SelectList(I, "checker", "checker");
            ViewBag.u = selectListItems;
            Engage_interview se = await eiDAO.EiSelect2(id);
            ViewBag.d = await eiDAO.EnSelect3(se.resume_id);
            ViewBag.s = se;
            return View();
        }
        public async Task<ActionResult> ErSelectId2(int id)
        {
            IEnumerable<Engage_interview> I = await eiDAO.EmSelect();
            SelectList selectListItems = new SelectList(I, "checker", "checker");
            ViewBag.u = selectListItems;
            Engage_interview se = await eiDAO.EiSelect2(id);
            ViewBag.d = await eiDAO.EnSelect3(se.resume_id);
            ViewBag.s = se;
            return View();
        }



        public async Task<ActionResult> MianShiXG3(Engage_interview e)
        {
            int result = await eiDAO.MianShiXG2(e);
            if (result > 0)
            {
                return RedirectToAction("/Ei/Lu_SP");
            }
            else
            {
                return RedirectToAction("/Ei/Lu_SP");
            }

        }
        public async Task<ActionResult> Lu_CX()
        {
            return View();
        }
        /// <summary>
        /// 
        /// 录用审批申请查询
        /// </summary>
        /// <param name="currentPage"></param>
        /// <returns></returns>
        //public async Task<ActionResult> LU_YoShePi(int id)
        //{

        //}
    }
}