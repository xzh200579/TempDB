using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PermissionsDAO
    {
        string couStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";


        /// <summary>
        /// 用户管理查询
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Users>> ChaSyAsync1()
        {
            using (SqlConnection con = new SqlConnection(couStr))
            {
                string sql = "SELECT u_id,u_name,u_true_name,u_password,r.RolesName FROM [dbo].[users] u INNER JOIN [dbo].[UserRoles] s on s.UserID = u.u_id INNER JOIN [dbo].[Roles] r on r.RolesID = s.RolesID";
                return await con.QueryAsync<Users>(sql);
            }
        }
      

        /// <summary>
        /// 进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> ScAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(couStr))
            {
                string sql1 = $"DELETE FROM [dbo].[UserRoles] WHERE UserID = '{id}'";
                int cg = await con.ExecuteAsync(sql1);
                if (cg == 0)
                {
                    return 0;
                }
                string sql = $"DELETE FROM [dbo].[users] WHERE u_id = '{id}'";
                return await con.ExecuteAsync(sql);
            }
        }
    }
}
