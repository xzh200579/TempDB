using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LevelTwo
    {
        public string value { get; set; }
        public string label { get; set; }

        public IEnumerable<LevelTwo> children { get; set; }
    }
}
