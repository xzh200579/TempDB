using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Config_public_char
    {

        public int pbc_id { get; set; }
        [DisplayName("属性种族")]
        public string attribute_kind { get; set; }
        [DisplayName("属性名称")]
        public string attribute_name { get; set; }
    }
}
