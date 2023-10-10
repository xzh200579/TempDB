using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DAO;
using Model;

namespace TempDB.Controllers
{
    public class EmreleaseController : Controller
    {


        EmreleaseDAO emreleaseDAO = new EmreleaseDAO();
        CmkindDAO CmkindDAO = new CmkindDAO();
        CmajorDAO CmajorDAO = new CmajorDAO();

        public async Task<ActionResult> Index()
        {

            IEnumerable<Config_file_first_kind> I = await emreleaseDAO.EmSelect1();
            ViewBag.List_Key1 = new SelectList(I.ToList(), "first_kind_name", "first_kind_name").AsEnumerable();


            //Key2、Key3 赋空值
            List<Config_file_third_kind> selectlist = new List<Config_file_third_kind>();
            ViewBag.List_Key2 = new SelectList(selectlist, "second_kind_name", "second_kind_name").AsEnumerable();
            ViewBag.List_Key3 = new SelectList(selectlist, "third_kind_name", "third_kind_name").AsEnumerable();
            await GetDropList2();
            await GetDropList1();
            await GetDropList();
            return View();
        }
        
        private async Task GetDropList()
        {
            IEnumerable<config_major_kind> ptables = await CmkindDAO.MkindSelete();
            SelectList selectListItems = new SelectList(ptables, "major_kind_name", "major_kind_name");
            ViewBag.s = selectListItems;


        }
        private async Task GetDropList2()
        {
            IEnumerable<Engage_major_release> ptables = await emreleaseDAO.EmSelect();
            SelectList selectListItems = new SelectList(ptables, "engage_type", "engage_type");
            ViewBag.s2 = selectListItems;


        }
        private async Task GetDropList4()
        {
            IEnumerable<Config_file_third_kind> ptables = await emreleaseDAO.Em1();
            SelectList selectListItems = new SelectList(ptables, "third_kind_name", "third_kind_name");
            ViewBag.s4 = selectListItems;


        }
        private async Task GetDropList3()
        {
            IEnumerable<Config_file_first_kind> ptables = await emreleaseDAO.EmSelect1();
            SelectList selectListItems1 = new SelectList(ptables, "first_kind_name", "first_kind_name");
            ViewBag.s3 = selectListItems1;


        }
        public async Task<JsonResult> IISelect(string name)
        {
            IEnumerable<Config_file_second_kind> IIcx = await emreleaseDAO.EmSelect4(name);
            return Json(IIcx, JsonRequestBehavior.AllowGet);
        }
      
        public async Task<JsonResult> IIISelect(string name, string name1)
        {
            IEnumerable<Config_file_third_kind> IIcx = await emreleaseDAO.EmSelect5(name, name1);
            return Json(IIcx, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> maor(string name)
        {
            IEnumerable<config_major> IIcx = await CmajorDAO.XXX(name);
            return Json(IIcx, JsonRequestBehavior.AllowGet);
        }
        private async Task GetDropList1()
        {
            IEnumerable<config_major> ptables = await CmajorDAO.MajorSelect();
            SelectList selectListItems1 = new SelectList(ptables, "major_name", "major_name");
            ViewBag.s1 = selectListItems1;


        }
        public async Task<ActionResult> Insert(Engage_major_release engage_Major_Release)
        {
            if (ModelState.IsValid)
            {
                int result = await emreleaseDAO.EmInsert(engage_Major_Release);
                if (result > 0)
                {
                    await Console.Out.WriteLineAsync("添加成功");
                    return RedirectToAction("Index");

                }
                else
                {
                    return View(engage_Major_Release);
                }
            }
            else
            {
                return View(engage_Major_Release);
            }
        }

        //职位发布变更分页查询
        public async Task<ActionResult> Index1()
        {
            return View();
        }
        public async Task<ActionResult> Index2(FenYe<Engage_major_release> fy)
        {
            fy = await emreleaseDAO.EngageSelect(fy);
            return Json(fy, JsonRequestBehavior.AllowGet);
        }
        //职位发布变更删除
        public async Task<ActionResult> EmDelete1(int id)
        {
            int result = await emreleaseDAO.EngageDelete(id);
            if (result > 0)
            {
                return RedirectToAction("Index1");
            }
            else
            {
                return RedirectToAction("Index1");
            }

        }
        public async Task<JsonResult> major(string name)
        {
            IEnumerable<config_major> IIcx = await CmajorDAO.Config_majorSelectIDAsync(name);
            return Json(IIcx, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Update(int id, string name, string name1, string name3)
        {
            ViewData.Model = await emreleaseDAO.EngageSelectId(id);
            IEnumerable<Config_file_first_kind> I = await emreleaseDAO.EmSelect1();
            ViewBag.List_Key1 = new SelectList(I.ToList(), "first_kind_name", "first_kind_name").AsEnumerable();

            IEnumerable<Config_file_second_kind> II = await emreleaseDAO.EmSelect4(name);
            ViewBag.List_Key2 = new SelectList(II.ToList(), "second_kind_name", "second_kind_name").AsEnumerable();

            IEnumerable<Config_file_third_kind> selectlist = await emreleaseDAO.EmSelect5(name, name1);
            ViewBag.List_Key3 = new SelectList(selectlist, "third_kind_name", "third_kind_name").AsEnumerable();

            IEnumerable<config_major> IIII = await CmajorDAO.MajorSelect();
            ViewBag.List_Key4 = new SelectList(IIII.ToList(), "major_kind_name", "major_kind_name").AsEnumerable();

            IEnumerable<config_major> major = await CmajorDAO.Config_majorSelectIDAsync(name3);
            ViewBag.List_Key5 = new SelectList(major.ToList(), "major_name", "major_name").AsEnumerable();
            await GetDropList();
            await GetDropList2();
            await GetDropList4();
            return View();
        }
        public async Task<ActionResult> Update2(Engage_major_release e)
        {
            if (ModelState.IsValid)
            {
                int result = await emreleaseDAO.Engage_major_releaseUpdateAsync(e);

                if (result > 0)
                {
                    return Content("<script>alert('提交成功！');location.href='/Emrelease/Index1'</script>");

                }
                else
                {

                    return Content("<script>alert('提交失败！')</script>");
                }
            }
            else
            {
                return View(e);
            }
        }

        public async Task<ActionResult> Index3()
        {
            return View();
        }
    }
}