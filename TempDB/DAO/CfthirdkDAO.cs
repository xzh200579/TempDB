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
    public class CfthirdkDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        /// <summary>
        /// 三级查询
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Config_file_third_kind>> ThreeSelectTypeAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "Select * FROM [dbo].[config_file_third_kind]";
                return await connection.QueryAsync<Config_file_third_kind>(sql);
            }
        }

        /// <summary>
        /// 三级删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> ThreeDelectAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $@"delete from [dbo].[config_file_third_kind] where ftk_id={id}";
                return await connection.ExecuteAsync(sql);
            }
        }


        /// <summary>
        /// 三级查询一个具体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Config_file_third_kind> ChaXunThreeAsync(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"Select * FROM [dbo].[config_file_third_kind] Where [ftk_id] ='{id}'";
                return await sqlConnection.QueryFirstAsync<Config_file_third_kind>(sql);
            }
        }

        /// <summary>
        /// 三级修改
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task<int> XiuGaiThree(Config_file_third_kind config)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"UPDATE [dbo].[config_file_third_kind] SET [third_kind_sale_id]='{config.third_kind_sale_id}',[third_kind_is_retail]='{config.third_kind_is_retail}' WHERE [ftk_id]='{config.ftk_id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }
        /// <summary>
        /// 三级添加
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task<int> TinaThreeAsync(Config_file_third_kind config)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                CffkindDAO kindDAO = new CffkindDAO();
                CfsecondkDAO file = new CfsecondkDAO();

                //进行查询一级名称
                Config_file_first_kind first = await kindDAO.ChaYiAsyncE(config.first_kind_id);
                //查询二级名称
                Config_file_second_kind fil = await file.ChaYgAsync(config.second_kind_id);

                string sql = $@"Insert into [dbo].[config_file_third_kind]([first_kind_name],first_kind_id,[second_kind_name],[second_kind_id],[third_kind_id],[third_kind_name],[third_kind_sale_id],[third_kind_is_retail]) values('{first.first_kind_name}','{config.first_kind_id}','{fil.second_kind_name}','{config.second_kind_id}',(select max([third_kind_id])+1 from [dbo].[config_file_third_kind]),'{config.third_kind_name}','{config.third_kind_sale_id}','{config.third_kind_is_retail}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }
    }
}
