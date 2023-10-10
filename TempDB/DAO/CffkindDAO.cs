using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DAO
{
    public class CffkindDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";


        /// <summary>
        /// 一级查询
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Config_file_first_kind>> KindSelectTypeAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from [dbo].[config_file_first_kind]";
                return await connection.QueryAsync<Config_file_first_kind>(sql);
            }
        }
        /// <summary>
        /// 一级删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> TreesDelectAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $@"delete from [dbo].[config_file_first_kind] where ffk_id={id}";
                return await connection.ExecuteAsync(sql);
            }
        }
        /// <summary>
        /// 一级添加
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task<int> TinaAsync(Config_file_first_kind config)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $@"insert into [dbo].[config_file_first_kind] (first_kind_id,first_kind_name,first_kind_salary_id,first_kind_sale_id) values((select max(first_kind_id)+1 from [dbo].[config_file_first_kind]),'{config.first_kind_name}','{config.first_kind_salary_id}','{config.first_kind_sale_id}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// 查询一个具体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Config_file_first_kind> ChaXunAsync(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"Select * FROM [dbo].[config_file_first_kind] Where ffk_id='{id}'";
                return await sqlConnection.QueryFirstAsync<Config_file_first_kind>(sql);
            }
        }

       /// <summary>
       /// 根据一级编号查询
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public async Task<Config_file_first_kind> ChaYiAsyncE(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM [dbo].[config_file_first_kind] WHERE first_kind_id= '{id}'";
                return await sqlConnection.QueryFirstAsync<Config_file_first_kind>(sql);
            }
        }

        /// <summary>
        /// 一级修改
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task<int> XiuGai(Config_file_first_kind config)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"UPDATE [dbo].[config_file_first_kind] SET  first_kind_salary_id='{config.first_kind_salary_id}', first_kind_sale_id='{config.first_kind_sale_id}' WHERE [ffk_id]='{config.ffk_id}'";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }
        /// <summary>
        /// 根据一级查二级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<LevelTwo>> ChaEYAsyncTwo(string id)
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
                        label = fileSecondKind.second_kind_name
                    };
                    jis.Add(ji);
                }
                return jis;
            }
        }

        /// <summary>
        /// 进行级联查一级
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LevelTwo>> ChaLianOne()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = "SELECT * FROM [dbo].[config_file_first_kind]";
                IEnumerable<Config_file_first_kind> firsts = await sqlConnection.QueryAsync<Config_file_first_kind>(sql);
                List<LevelTwo> jis = new List<LevelTwo>();
                foreach (Config_file_first_kind first in firsts)
                {
                    LevelTwo leavl = new LevelTwo()
                    {
                        value = first.first_kind_id,
                        label = first.first_kind_name,
                        children = await ChaEYAsyncTwo(first.first_kind_id)
                    };
                    jis.Add(leavl);
                }
                return jis;
            }
        }

        //public async Task<FenYe<Config_file_first_kind>> KindSelectTypeAsync(FenYe<Config_file_first_kind> fenYe)
        //{
        //    using (SqlConnection sqlConnection = new SqlConnection(conStr))
        //    {
        //        DynamicParameters dynamicParameters = new DynamicParameters();
        //        dynamicParameters.Add("@pageSize", fenYe.PageSize);
        //        dynamicParameters.Add("@keyName", "ffk_id");
        //        dynamicParameters.Add("@tableName", "config_file_first_kind");
        //        dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
        //        dynamicParameters.Add("@row", direction: ParameterDirection.Output, dbType: DbType.Int32);
        //        string sql = "exec [dbo].[procFenYe] @pageSize, @keyName, @tableName, @currentPage, @row out";
        //        fenYe.List = await sqlConnection.QueryAsync<Config_file_first_kind>(sql, dynamicParameters);
        //        fenYe.Rows = dynamicParameters.Get<int>("row");
        //        return fenYe;
        //    }
        //}
    }
}
