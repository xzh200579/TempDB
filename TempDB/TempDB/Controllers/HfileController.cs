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
    public class HfileController: Controller
    {
        HfileDAO hfileDAO=new HfileDAO();
        CmajorDAO cmajorDAO=new CmajorDAO();
        EresumeDAO eresumeDAO=new EresumeDAO();
        public async Task<ActionResult> Insert(int id)
        {
            Engage_resume se = await hfileDAO.HrSelect2(id);
            ViewBag.s = se.human_picture;
            ViewData.Model = se;
            IEnumerable<Config_file_first_kind> I = await hfileDAO.EmSelect1();
            ViewBag.List_Key1 = new SelectList(I.ToList(), "first_kind_name", "first_kind_name").AsEnumerable();
            //Key2、Key3 赋空值
            List<Config_file_third_kind> selectlist = new List<Config_file_third_kind>();
            ViewBag.List_Key2 = new SelectList(selectlist, "second_kind_name", "second_kind_name").AsEnumerable();
            ViewBag.List_Key3 = new SelectList(selectlist, "third_kind_name", "third_kind_name").AsEnumerable();
            IEnumerable<config_major> IIII = await cmajorDAO.MajorSelect();
            ViewBag.List_Key4 = new SelectList(IIII.ToList(), "major_kind_name", "major_kind_name").AsEnumerable();
            IEnumerable<Config_public_char> zc = await hfileDAO.Hfzc();
            ViewBag.List_Key5 = new SelectList(zc.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Human_file> sex = await hfileDAO.HfSexCx();
            ViewBag.List_Key6 = new SelectList(sex.ToList(), "human_sex", "human_sex").AsEnumerable();
            IEnumerable<Config_public_char> gj = await hfileDAO.HfGjCx();
            ViewBag.List_Key7 = new SelectList(gj.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> mz = await hfileDAO.HfmzCx();
            ViewBag.List_Key8 = new SelectList(mz.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> zjxy = await hfileDAO.HfzjxyCx();
            ViewBag.List_Key9 = new SelectList(zjxy.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> zzmm = await hfileDAO.HfzzmmCx();
            ViewBag.List_Key10 = new SelectList(zzmm.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> xl = await hfileDAO.HfxlCx();
            ViewBag.List_Key11 = new SelectList(xl.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> nx = await hfileDAO.HfnxCx();
            ViewBag.List_Key12 = new SelectList(nx.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> zy = await hfileDAO.HfzyCx();
            ViewBag.List_Key13 = new SelectList(zy.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Human_file> xc = await hfileDAO.HfxcCx();
            ViewBag.List_Key14 = new SelectList(xc.ToList(), "salary_standard_name", "salary_standard_name").AsEnumerable();
            IEnumerable<Config_public_char> tc = await hfileDAO.HftcCx();
            ViewBag.List_Key15 = new SelectList(tc.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> ah = await hfileDAO.HfahCx();
            ViewBag.List_Key16 = new SelectList(ah.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Salary_standard_details> e = await hfileDAO.SaxcCx();
            ViewBag.List_Key11 = new SelectList(e.ToList(), "standard_name", "standard_name").AsEnumerable();
            await GetDropList1();
            return View();
        }
        public async Task<ActionResult> Insert2(Human_file h)
        {

            int result = await hfileDAO.HfInsert(h);
            if (result > 0)
            {
                return Content("<script>alert('新增成功！');location.href='/Hfile/Index'</script>");
            }
            else
            {
                return View(h);
            }

        }
        public async Task<ActionResult> Inde2()
        {
            return View();
        }
        private async Task GetDropList1()
        {
            IEnumerable<config_major> ptables = await eresumeDAO.MajorSelect();
            SelectList selectListItems1 = new SelectList(ptables, "major_name", "major_name");
            ViewBag.s1 = selectListItems1;


        }
        public async Task<ActionResult> Index()
        {
            return View();
        }
        public async Task<ActionResult> Index2(FenYe<Human_file> fy)
        {
            fy = await hfileDAO.HfSelect(fy);
            return Json(fy, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> IISelect(string name)
        {
            IEnumerable<Config_file_second_kind> IIcx = await hfileDAO.EmSelect11(name);
            return Json(IIcx, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> IIISelect(string name, string name1)
        {
            IEnumerable<Config_file_third_kind> IIcx = await hfileDAO.EmSelect12(name, name1);
            return Json(IIcx, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> UpdateCx(int id)
        {
            Human_file se = await hfileDAO.HfSelect2(id);
            ViewBag.s = se.human_picture;
            ViewData.Model =se;
            //国籍
            IEnumerable<Config_public_char> guoji = await eresumeDAO.Config_public_charSelectAsync("国籍");
            ViewBag.List_Key1 = new SelectList(guoji.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            //民族
            IEnumerable<Config_public_char> 民族 = await eresumeDAO.Config_public_charSelectAsync("民族");
            ViewBag.List_Key2 = new SelectList(民族.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            //宗教信仰
            IEnumerable<Config_public_char> 宗教信仰 = await eresumeDAO.Config_public_charSelectAsync("宗教信仰");
            ViewBag.List_Key3 = new SelectList(宗教信仰.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            //政治面貌
            IEnumerable<Config_public_char> 政治面貌 = await eresumeDAO.Config_public_charSelectAsync("政治面貌");
            ViewBag.List_Key4 = new SelectList(政治面貌.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            //教育年限
            IEnumerable<Config_public_char> 教育年限 = await eresumeDAO.Config_public_charSelectAsync("教育年限");
            ViewBag.List_Key6 = new SelectList(教育年限.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            //学历
            IEnumerable<Config_public_char> 学历 = await eresumeDAO.Config_public_charSelectAsync("学历");
            ViewBag.List_Key5 = new SelectList(学历.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            //专业
            IEnumerable<Config_public_char> 专业 = await eresumeDAO.Config_public_charSelectAsync("专业");
            ViewBag.List_Key7 = new SelectList(专业.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            //爱好
            IEnumerable<Config_public_char> 爱好 = await eresumeDAO.Config_public_charSelectAsync("爱好");
            ViewBag.List_Key9 = new SelectList(爱好.ToList(), "attribute_name", "attribute_name").AsEnumerable();

            //特长
            IEnumerable<Config_public_char> 特长 = await eresumeDAO.Config_public_charSelectAsync("特长");
            ViewBag.List_Key8 = new SelectList(特长.ToList(), "attribute_name", "attribute_name").AsEnumerable();

            IEnumerable<Config_public_char> w = await hfileDAO.cccc("职称");
            ViewBag.List_Key10 = new SelectList(w.ToList(), "attribute_name", "attribute_name").AsEnumerable();

            IEnumerable<Salary_standard_details> e = await hfileDAO.SaxcCx();
            ViewBag.List_Key11 = new SelectList(e.ToList(), "standard_name", "standard_name").AsEnumerable();
            return View(); 

        }
        public async Task<ActionResult> FUHe_UPDATE(Human_file e)
        {
            int se = await hfileDAO.FuHe_UPDATE(e);
            if (se == 1)
            {
           
                return Content("<script>alert('复核成功！');location.href='/Hfile/Index'</script>");
            }
            else
            {
                return Content("0");
            }
        }
        public async Task<ActionResult> Index2LyCx(FenYe<Engage_resume> fy)
        {
            fy = await hfileDAO.ErSelect(fy);
            return Json(fy, JsonRequestBehavior.AllowGet);
        }
    }
}