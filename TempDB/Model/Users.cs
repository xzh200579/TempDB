using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class Users
    {
        public int u_id { get; set; }

        public string u_name { get; set; }

        public string u_true_name { get; set; }

        public string u_password { get; set; }
        public string RolesID { get; set; }
        public string RolesName { get; set; }
        public string RolesInstruction { get; set; }
        public string RolesIf { get; set; }

        public string UserRolesID { get; set; }
        public string UserID { get; set; }
    }
}
