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
    public class SalaDetailsController : Controller
    {
        SaladetailsDAO Saladetails = new SaladetailsDAO();

        // GET: SalaDetails
        public ActionResult Index()
        {
            return View();
        }
       
        /// <summary>
        /// 进行查询金额
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> FuX(string id)
        {
            IEnumerable<Salary_standard_details> enumer = await Saladetails.ChaYi(id);
            return Json(enumer, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 薪酬标准登记变更具体金额
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> ChangeMoney(string id)
        {
            IEnumerable<Salary_standard_details> ie = await Saladetails.ChaYi(id);
            return Json(ie, JsonRequestBehavior.AllowGet);
        }
    }
}