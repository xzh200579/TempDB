using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using DAO;
using Model;

namespace TempDB.Controllers
{
    public class EresumeController : Controller
    {
        EresumeDAO eresumeDAO = new EresumeDAO();
        CmajorDAO cmajorDAO = new CmajorDAO();
        CmkindDAO cmkindDAO = new CmkindDAO();
        public async Task<ActionResult> Insert(int id,string name)
        {
            ViewData.Model = await eresumeDAO.Engage_major_releaseSelectkindidAsync(id);

            IEnumerable<config_major_kind> IIII = await eresumeDAO.MkindSelete();
            ViewBag.List_Key4 = new SelectList(IIII.ToList(), "Major_kind_name", "Major_kind_name").AsEnumerable();
            IEnumerable<config_major> major = await cmajorDAO.Config_majorSelectIDAsync(name);
            ViewBag.List_Key5 = new SelectList(major.ToList(), "major_name", "major_name").AsEnumerable();
            IEnumerable<Engage_resume> sex = await eresumeDAO.EnSexCx();
            ViewBag.List_Key6 = new SelectList(sex.ToList(), "human_sex", "human_sex").AsEnumerable();
            IEnumerable<Config_public_char> gj = await eresumeDAO.EnGjCx();
            ViewBag.List_Key7 = new SelectList(gj.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> mz = await eresumeDAO.EnmzCx();
            ViewBag.List_Key8 = new SelectList(mz.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> zjxy = await eresumeDAO.EnzjxyCx();
            ViewBag.List_Key9 = new SelectList(zjxy.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> zzmm = await eresumeDAO.EnzzmmCx();
            ViewBag.List_Key10 = new SelectList(zzmm.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> xl = await eresumeDAO.EnxlCx();
            ViewBag.List_Key11 = new SelectList(xl.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> nx = await eresumeDAO.EnnxCx();
            ViewBag.List_Key12 = new SelectList(nx.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> zy = await eresumeDAO.EnzyCx();
            ViewBag.List_Key13 = new SelectList(zy.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> tc = await eresumeDAO.EntcCx();
            ViewBag.List_Key14 = new SelectList(tc.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<Config_public_char> ah = await eresumeDAO.EnahCx();
            ViewBag.List_Key15 = new SelectList(ah.ToList(), "attribute_name", "attribute_name").AsEnumerable();
            IEnumerable<config_major> majorTwo = await cmajorDAO.Config_majorSelectIDAsyncTT();
            ViewBag.List_Key16 = new SelectList(majorTwo.ToList(), "major_name", "major_name").AsEnumerable();
            await GetDropList1();
            await GetDropList2();
            return View();
        }
        private async Task GetDropList()
        {
            IEnumerable<config_major_kind> ptables = await eresumeDAO.MkindSelete();
            SelectList selectListItems = new SelectList(ptables, "major_kind_name", "major_kind_name");
            ViewBag.s = selectListItems;


        }
        private async Task GetDropList1()
        {
            IEnumerable<config_major> ptables = await eresumeDAO.MajorSelect();
            SelectList selectListItems1 = new SelectList(ptables, "major_name", "major_name");
            ViewBag.s1 = selectListItems1;


        }
        private async Task GetDropList2()
        {
            IEnumerable<Engage_major_release> ptables = await eresumeDAO.EmSelect();
            SelectList selectListItems = new SelectList(ptables, "engage_type", "engage_type");
            ViewBag.s2 = selectListItems;


        }
        public async Task<ActionResult> Insert1(Engage_resume e)
        {

            int result = await eresumeDAO.EresumeInsert(e);
            if (result > 0)
            {
                return Content("<script>alert('新增成功！');location.href='/Eresume/resume_choose'</script>");
            }
            else
            {
                return View(e);
            }

        }

        public async Task<ActionResult> Index()
        {
            return View();
        }
        public async Task<ActionResult> Index2(FenYe<Engage_resume> fy)
        {
            fy = await eresumeDAO.Emselect(fy);
            return Json(fy, JsonRequestBehavior.AllowGet);
        }
            public async Task<ActionResult> Update(int id)
             {
            ViewBag.s = await eresumeDAO.EmgageSelectId(id);
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> InsertDj(Engage_interview e)
        {
            int result = await eresumeDAO.Insert(e);
            if (result >0)
            {
                return Content("<script>alert('提交成功！');location.href='/Eresume/Index'</script>");
            }
            else
            {
                return Content("<script>alert('登记失败！');location.href='/Eresume/Update'</script>");
            }
        }
        public async Task<ActionResult> cxjl(FenYe<Engage_resume> fenYe)
        {
            fenYe = await eresumeDAO.select(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> resume_details(int id)
        {
            Engage_resume se = await eresumeDAO.EmgageSelectId(id);
            ViewBag.s = se.human_picture;
            ViewData.Model = se;
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
            //姓名
            return View();
        }
        [HttpPost] 
        public async Task<ActionResult> resume_details(Engage_resume e)
        {
            int result = await eresumeDAO.update(e);
            if (result==1)
            {
                return Content("<script>alert('复核成功！');location.href='/Eresume/resume_list'</script>");
            }
            else
            {
                return Content("<script>alert('复核失败！');location.href='/Eresume/resume_details?id='" + e.res_id + "</script>");
            }
        }
        public async Task<ActionResult> resume_choose()
        {
            IEnumerable<config_major_kind> major_kind = await cmkindDAO.Config_major_kindSelectAsync();
            ViewBag.List_Key1 = new SelectList(major_kind.ToList(), "major_kind_name", "major_kind_name").AsEnumerable();
            List<config_major> selectlist = new List<config_major>();
            ViewBag.List_Key2 = new SelectList(selectlist, "major_name", "major_name").AsEnumerable();
            return View();
        }
        public async Task<ActionResult> resume_choose1(int PageSize, int CurrentPage, string major_kind_name, string major_name, string remark, string begintime, string endtime, int a)
        {
            FenYe<Engage_resume> fy = await eresumeDAO.tjselect(PageSize, CurrentPage, major_kind_name, major_name, remark, begintime, endtime, a);
            //return Content("<script>location.href='/Resume/resume_list?pageSize=2&&currentPage=1&&major_kind_name=" + e.Major_kind_name + "&&major_name="+e.Major_name + "&&remark="+e.Remark + "&&begintime="+e.begintime+"&&endtime="+e.endtime+"'</script>");
            return Json(fy, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> resume_list(Engage_resume e)
        {
            // ViewData.Model= await erd.tjselect(pageSize, currentPage, major_kind_name, major_name, remark, begintime, endtime);
            ViewData.Model = e;
            return View();
        }
        public async Task<ActionResult> resume_choose2()
        {
            IEnumerable<config_major_kind> major_kind = await cmkindDAO.Config_major_kindSelectAsync();
            ViewBag.List_Key1 = new SelectList(major_kind.ToList(), "major_kind_name", "major_kind_name").AsEnumerable();
            List<config_major> selectlist = new List<config_major>();
            ViewBag.List_Key2 = new SelectList(selectlist, "major_name", "major_name").AsEnumerable();
            return View();
        }
        public ActionResult resume_list2(Engage_resume e)
        {
            ViewData.Model = e;
            return View();
        }
        public async Task<ActionResult> MianShiINSERT(Engage_interview engage)
        {
            int se = await eresumeDAO.MianShiJieGuo(engage);
            if (se > 0)
            {
                return Content("<script>alert('复核成功！');location.href='/Ei/Index'</script>");

            }
            else
            {
                return Content("0");
            }
        }
        public async Task<ActionResult> DengJi(int id)
        {
            ViewBag.s = await eresumeDAO.EmgageSelectId(id);
            return View();
        }
        public ActionResult WSC()
        {
            var file = HttpContext.Request.Files["file"];//获取上传文件对象
                                                         //生成文件名
            string name = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //获取后缀名
            string ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
            //相对路径
            string path = $"~/Uploaders/{DateTime.Now.ToString("yyyy/MM/dd/")}" + name + ext;
            //绝对路径
            string jpath = Server.MapPath(path);
            //创建上传文件对应的文件夹
            (new FileInfo(jpath)).Directory.Create();
            file.SaveAs(jpath);
            string result = path.Substring(path.LastIndexOf("~") + 1);
            return Json(new { path = result });
        }
        public async Task<ActionResult> register(int id, string name)
        {
         
            return View();
        }
    }



    }