using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dapper;
using System.Data.SqlClient;

namespace DAO
{
    public class CfsecondkDAO
    {

        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        /// <summary>
        /// 二级查询
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Config_file_second_kind>> TwoKindSelectTypeAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from [dbo].[config_file_second_kind]";
                return await connection.QueryAsync<Config_file_second_kind>(sql);
            }
        }

        public async Task<Config_file_second_kind> ChaYgAsync(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM [dbo].[config_file_second_kind] WHERE second_kind_id = '{id}'";
                return await sqlConnection.QueryFirstAsync<Config_file_second_kind>(sql);
            }
        }

        /// <summary>
        /// 查询一级机构名称
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Config_file_first_kind>> XSTypeAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select [first_kind_id],[first_kind_name] from [dbo].[config_file_first_kind]";
                return await connection.QueryAsync<Config_file_first_kind>(sql);
            }
        }

        /// <summary>
        /// 二级删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> TwoCDelectAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $@"delete from [dbo].[config_file_second_kind] where fsk_id={id}";
                return await connection.ExecuteAsync(sql);
            }
        }

        /// <summary>
        ///二级添加
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task<int> TinaTwoAsync(Config_file_second_kind config)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $@"insert into [dbo].[config_file_second_kind] (first_kind_name,second_kind_id,second_kind_name,second_salary_id,second_sale_id) values('{config.first_kind_name}',(select max(second_kind_id)+1 from [dbo].[config_file_second_kind]),'{config.second_kind_name}','{config.second_salary_id}','{config.second_sale_id}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// 查询一个具体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Config_file_second_kind> ChaXunTwoAsync(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"Select * FROM [dbo].[config_file_second_kind] Where fsk_id='{id}'";
                return await sqlConnection.QueryFirstAsync<Config_file_second_kind>(sql);
            }
        }

        /// <summary>
        /// 二级修改
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task<int> XiuGaiTwo(Config_file_second_kind config)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"UPDATE [dbo].[Config_file_second_kind] SET  second_salary_id='{config.second_salary_id}', second_sale_id='{config.second_sale_id}' WHERE [fsk_id]='{config.fsk_id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }


        /// <summary>
        /// 联级查询(查一级)
        /// </summary>
        /// <returns></returns>

        public async Task<IEnumerable<LevelTwo>> ChaLian1()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = "SELECT * FROM [dbo].[config_file_first_kind]";
                IEnumerable<Config_file_first_kind> firsts = await sqlConnection.QueryAsync<Config_file_first_kind>(sql);
                List<LevelTwo> jis = new List<LevelTwo>();
                foreach (Config_file_first_kind first in firsts)
                {
                    LevelTwo lian = new LevelTwo()
                    {
                        value = first.first_kind_id,
                        label = first.first_kind_name,
                        children = await ChaEYAsync1(first.first_kind_id)
                    };
                    jis.Add(lian);
                }
                return jis;
            }
        }

        /// <summary>
        /// 联级查询(查二级)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<IEnumerable<LevelTwo>> ChaEYAsync1(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT second_kind_id,second_kind_name FROM [dbo].[config_file_second_kind] WHERE first_kind_id = '{id}'";
                IEnumerable<Config_file_second_kind> f = await sqlConnection.QueryAsync<Config_file_second_kind>(sql);
                List<LevelTwo> jis = new List<LevelTwo>();
                foreach (Config_file_second_kind fileSecondKind in f)
                {
                    LevelTwo ji = new LevelTwo()
                    {
                        value = fileSecondKind.second_kind_id,
                        label = fileSecondKind.second_kind_name,
                        children = await ChaSanAsync(fileSecondKind.second_kind_id)
                    };
                    jis.Add(ji);
                }
                return jis;
            }
        }

        /// <summary>
        /// 联级查询(查三级)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<LevelTwo>> ChaSanAsync(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT third_kind_id,third_kind_name FROM [dbo].[config_file_third_kind] WHERE second_kind_id = '{id}'";
                IEnumerable<Config_file_third_kind> f = await sqlConnection.QueryAsync<Config_file_third_kind>(sql);
                List<LevelTwo> jis = new List<LevelTwo>();
                foreach (Config_file_third_kind fileSecondKind in f)
                {
                    LevelTwo ji = new LevelTwo()
                    {
                        value = fileSecondKind.third_kind_id,
                        label = fileSecondKind.third_kind_name,
                    };
                    jis.Add(ji);
                }
                return jis;
            }
        }
    }
}
