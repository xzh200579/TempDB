using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class config_major
    {
        public int mak_id { get; set; }
        [DisplayName("职位分类编号")]
        public string major_kind_id { get; set; }
        [DisplayName("职位分类名称")]
        public string major_kind_name { get; set; }
        [DisplayName("职位编号")]
        public string major_id { get; set; }
        [DisplayName("职位名称")]
        public string major_name { get; set; }

        public int test_amount { get; set; }
        
    }
}
