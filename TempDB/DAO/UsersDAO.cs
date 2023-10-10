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
    public class UsersDAO
    {
        //连接字符串
        string conStr ="Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<Users> ChaXunUserAsync(string name,string password)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $@"SELECT * FROM [dbo].[users] Where u_name='{name}' AND u_password='{password}'";
                return await sqlConnection.QueryFirstAsync<Users>(sql);
            }
        }
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Users>> ChaSyAsync()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = "SELECT * FROM [dbo].[users]";
                return await con.QueryAsync<Users>(sql);
            }
        }

        /// <summary>
        /// 修改用户显示详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Users> ChaZwMo(string id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = "SELECT u_id,u_name,u_true_name,u_password,r.RolesID FROM [dbo].[users] u INNER JOIN [dbo].[UserRoles] s on s.UserID = u.u_id INNER JOIN [dbo].[Roles] r on r.RolesID = s.RolesID  where u_id =  " + id;
                return await con.QueryFirstAsync<Users>(sql);
            }
        }

        /// <summary>
        /// 进行修改
        /// </summary>
        /// <param name="zh"></param>
        /// <param name="mi"></param>
        /// <param name="name"></param>
        /// <param name="zw"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> XiuAsync(string zh, string mi, string name, int zw, int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"UPDATE [dbo].[users] SET u_name = '{name}',u_true_name = '{zh}',u_password = '{mi}' where u_id = '{id}'";
                int cg = await con.ExecuteAsync(sql);
                if (cg == 0)
                {
                    return 0;
                }
                string sql1 = $"UPDATE [dbo].[UserRoles] SET RolesID = '{zw}' where UserID = '{id}'";
                return await con.ExecuteAsync(sql1);
            }
        }

        /// <summary>
        /// 进行添加
        /// </summary>
        /// <param name="zh"></param>
        /// <param name="mi"></param>
        /// <param name="name"></param>
        /// <param name="zw"></param>
        /// <returns></returns>
        public async Task<int> TianAsync(string zh, string mi, string name, int zw)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"INSERT INTO [dbo].[users](u_name, u_true_name, u_password) VALUES ('{name}','{zh}','{mi}')";
                int cg = await con.ExecuteAsync(sql);
                if (cg == 0)
                {
                    return 0;
                }
                string sql1 = "SELECT MAX(u_id) FROM [dbo].[users]";
                int cg1 = await con.QueryFirstAsync<int>(sql1);
                string sql2 = $"INSERT INTO [dbo].[UserRoles](UserID, RolesID) VALUES ('{cg1}','{zw}')";
                return await con.ExecuteAsync(sql2);
            }
        }

        public async Task<int> Ji(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"SELECT COUNT(*) FROM [dbo].[UserRoles] WHERE RolesID = {id}";
                return await con.QueryFirstAsync<int>(sql);
            }
        }
    }
}
