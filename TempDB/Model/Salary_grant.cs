using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 薪酬发放登记表
    /// </summary>
    public class Salary_grant
    {
        public string sgr_id { get; set; }
        public string salary_grant_id { get; set; }
        public string first_kind_id { get; set; }
        public string first_kind_name { get; set; }
        public string second_kind_id { get; set; }
        public string second_kind_name { get; set; }
        public string third_kind_id { get; set; }
        public string third_kind_name { get; set; }
        public string human_amount { get; set; }
        public double salary_standard_sum { get; set; }
        public double salary_paid_sum { get; set; }
        public string register { get; set; }
        public DateTime regist_time { get; set; }
        public string checker { get; set; }
        public DateTime check_time { get; set; }
        public string check_status { get; set; }
        public string salary_standard_id { get; set; }
    }
}
