using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HumanFileDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        /// <summary>
        /// 根据条件查询调动
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public async Task<FenYe<Human_file>> MoFen(int PageSize, int CurrentPage, string Condition)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", PageSize);
                dynamicParameters.Add("@keyName", "huf_id");
                dynamicParameters.Add("@tabelName", "human_file");
                dynamicParameters.Add("@where", Condition);
                dynamicParameters.Add("@currentPage", CurrentPage);
                dynamicParameters.Add("@lie", "*");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec  [dbo].[proc_FenyeMo] @pageSize,@keyName,@tabelName,@where,@currentPage,@lie,@rows out";
                IEnumerable<Human_file> list = await sqlConnection.QueryAsync<Human_file>(sql, dynamicParameters);
                int row = dynamicParameters.Get<int>("rows");
                FenYe<Human_file> fc = new FenYe<Human_file>();
                fc.List = list;
                fc.Rows = row;
                return fc;
            }
        }
        /// <summary>
        /// 根据id查询所有
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Human_file> ChaYiAsync(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM [dbo].[human_file] WHERE huf_id = '{id}'";
                return await sqlConnection.QueryFirstAsync<Human_file>(sql);
            }
        }

        /// <summary>
        /// 进行调动的添加
        /// </summary>
        /// <param name="change"></param>
        /// <returns></returns>
        public async Task<int> Tian(Major_change change)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql1 = $"UPDATE [dbo].[human_file]  SET status = 1 where human_id= '{change.human_id}'";
                int c = await sqlConnection.ExecuteAsync(sql1);
                if (c == 0)
                {
                    return 0;
                }
                string sql = $"INSERT INTO [dbo].[major_change](first_kind_id, first_kind_name, second_kind_id, second_kind_name, third_kind_id, third_kind_name, major_kind_id, major_kind_name, major_id, major_name, new_first_kind_id, new_first_kind_name, new_second_kind_id, new_second_kind_name, new_third_kind_id, new_third_kind_name, new_major_kind_id, new_major_kind_name, new_major_id, new_major_name, human_id, human_name, salary_standard_id, salary_standard_name, salary_sum, new_salary_standard_id, new_salary_standard_name, new_salary_sum, change_reason, check_status, register, regist_time) VALUES ('{change.first_kind_id}','{change.first_kind_name}' , '{change.second_kind_id}', '{change.second_kind_name}', '{change.third_kind_id}','{change.third_kind_name}' ,'{change.major_kind_id}' ,'{change.major_kind_name}' ,'{change.major_id}' ,'{change.major_name}' , '{change.new_first_kind_id}','{change.new_first_kind_name}' ,'{change.new_second_kind_id}' , '{change.new_second_kind_name}','{change.new_third_kind_id}' , '{change.new_third_kind_name}','{change.new_major_kind_id}' , '{change.new_major_kind_name}', '{change.new_major_id}', '{change.new_major_name}', '{change.human_id}', '{change.human_name}', '{change.salary_standard_id}', '{change.salary_standard_name}', '{change.salary_sum}', '{change.new_salary_standard_id}','{change.new_salary_standard_name}' ,'{change.new_salary_sum}' ,'{change.change_reason}' , '{change.check_status}', '{change.register}', '{change.regist_time}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// 查询具体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Human_file> ChaYiAsync1(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM [dbo].[human_file] WHERE human_id = '{id}'";
                return await sqlConnection.QueryFirstAsync<Human_file>(sql);
            }
        }
    }
}
