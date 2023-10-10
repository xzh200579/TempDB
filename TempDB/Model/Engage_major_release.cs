using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Engage_major_release
    {
        public int mre_id { get; set; }
        public string first_kind_id { get; set; }
        [DisplayName("I级机构")]
        public string first_kind_name { get; set; }
        public string second_kind_id { get; set; }
        [DisplayName("II级机构")]
        public string second_kind_name { get; set; }
        public string third_kind_id { get; set; }
        [DisplayName("III级机构")]
        public string third_kind_name { get; set; }
        public string major_kind_id { get; set; }
        [DisplayName("职位分类")]
        public string major_kind_name { get; set; }
        public string major_id { get; set; }
        [DisplayName("职位名称")]
        public string major_name { get; set; }
        [DisplayName("招聘人数")]
        public int human_amount { get; set; }
        [DisplayName("招聘类型")]
        public string engage_type { get; set; }
        [DisplayName("截至日期")]
        public DateTime deadline { get; set; }
        [DisplayName("登记人")]
        public string register { get; set; }
        public string changer { get; set; }
        [DisplayName("登记时间")]
        public DateTime regist_time { get; set; }
        public DateTime change_time { get; set; }
        [DisplayName("职位描述")]
        public string major_describe { get; set; }
        [DisplayName("截至时间")]
        public string engage_required { get; set; }

        public string checke { get; set; }
        public string human_major_kind_id { get; set; }
        public string human_major_kind_name { get; set; }
        public string human_major_id { get; set; }
        public string human_major_name { get; set; }
    }
}
