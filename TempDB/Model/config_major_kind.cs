﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class config_major_kind
    {
        public int mfk_id { get; set; }
        [DisplayName("职位分类编号")]
        public string major_kind_id { get; set; }
        [DisplayName("职位分类名称")]
        public string major_kind_name { get; set; }

    }
}
