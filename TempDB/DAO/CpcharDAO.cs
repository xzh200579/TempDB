using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Model;

namespace DAO
{
    public class CpcharDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";
        public async Task<FenYe<Config_public_char>> CharSelect(FenYe<Config_public_char> fy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fy.PageSize);
                dynamicParameters.Add("@keyName", "pbc_id");
                dynamicParameters.Add("@tableName", "config_public_char");
                dynamicParameters.Add("@currentPage", fy.CurrentPage);
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[procFenYe] @pageSize, @keyName, @tableName, @currentPage, @rows out";
                fy.List = await sqlConnection.QueryAsync<Config_public_char>(sql, dynamicParameters);
                fy.Rows = dynamicParameters.Get<int>("rows");
                return fy;
            }
        }

        public async Task<int> CharInsert(Config_public_char config_Public_Char)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"INSERT INTO [dbo].[config_public_char](attribute_kind,attribute_name)VALUES('{config_Public_Char.attribute_kind}','{config_Public_Char.attribute_name}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        public async Task<int> CharDelete(int id)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"DELETE FROM config_public_char WHERE pbc_id= '{id}'";
                return await connection.ExecuteAsync(sql);
            }
        }

        public async Task<IEnumerable<Config_public_char>> CharSelect1()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = "SELECT * FROM [dbo].[config_public_char] WHERE [attribute_kind]='职称'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }
        }

        /// <summary>
        /// 薪酬设置查询
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Config_public_char>> XCSZ()
        {
            using (SqlConnection sqlConnection =new SqlConnection(conStr))
            {
                string sql = $"Select * from [dbo].[config_public_char] Where attribute_kind='薪酬设置'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }
        }

        /// <summary>
        /// 薪酬设置删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> XCDelectAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $@"delete from [dbo].[config_public_char] where [pbc_id]='{id}'";
                return await connection.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// 薪酬设置增加
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task<int> XCTinaAsync(Config_public_char config)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $@"Insert into [dbo].[config_public_char] ([attribute_kind],[attribute_name]) values('薪酬设置','{config.attribute_name}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

    }
}
