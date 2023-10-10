using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RolesDAO
    {


        string couStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";


        /// <summary>
        /// 修改用户信息显示下拉框
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Roles>> downbox()
        {
            using (SqlConnection con = new SqlConnection(couStr))
            {
                string sql = "SELECT * FROM [dbo].[Roles]";
                return await con.QueryAsync<Roles>(sql);
            }
        }

        /// <summary>
        /// 显示角色管理
        /// </summary>
        /// <param name="fy"></param>
        /// <returns></returns>
        public async Task<FenYe<Roles>> CharSelect(FenYe<Roles> fy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(couStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fy.PageSize);
                dynamicParameters.Add("@keyName", "RolesID");
                dynamicParameters.Add("@tableName", "Roles");
                dynamicParameters.Add("@currentPage", fy.CurrentPage);
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[procFenYe] @pageSize, @keyName, @tableName, @currentPage, @rows out";
                fy.List = await sqlConnection.QueryAsync<Roles>(sql, dynamicParameters);
                fy.Rows = dynamicParameters.Get<int>("rows");
                return fy;
            }
        }

        /// <summary>
        /// 进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> ScAsync(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(couStr))
            {
                string sql = $"DELETE FROM [dbo].[Roles] WHERE RolesID = '{id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }
        /// <summary>
        /// 进行角色的添加
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task<int> Tian(Roles roles)
        {
            using (SqlConnection sqlConnection = new SqlConnection(couStr))
            {
                string sql = $"INSERT INTO  [dbo].[Roles](RolesName, RolesInstruction, RolesIf) VALUES ('{roles.RolesName}','{roles.RolesInstruction}','{roles.RolesIf}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }
    }
}
