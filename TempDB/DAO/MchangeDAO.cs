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
    public class MchangeDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        /// <summary>
        /// 调动审核显示
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public async Task<FenYe<Major_change>> MoFenTwo(int PageSize, int CurrentPage, string Condition)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", PageSize);
                dynamicParameters.Add("@keyName", "mch_id");
                dynamicParameters.Add("@tabelName", "major_change");
                dynamicParameters.Add("@where", Condition);
                dynamicParameters.Add("@currentPage", CurrentPage);
                dynamicParameters.Add("@lie", "*");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec  [dbo].[proc_FenyeMo] @pageSize,@keyName,@tabelName,@where,@currentPage,@lie,@rows out";
                IEnumerable<Major_change> list = await sqlConnection.QueryAsync<Major_change>(sql, dynamicParameters);
                int row = dynamicParameters.Get<int>("rows");
                FenYe<Major_change> fc = new FenYe<Major_change>();
                fc.List = list;
                fc.Rows = row;
                return fc;
            }
        }

        /// <summary>
        /// 进行查询具体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Major_change> Yg(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM [dbo].[major_change] WHERE check_status = 0 AND human_id = '{id}'";
                return await sqlConnection.QueryFirstAsync<Major_change>(sql);
            }
        }

        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="change"></param>
        /// <returns></returns>
        public async Task<int> Xiu(Major_change change)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"UPDATE [dbo].[major_change] SET new_first_kind_id = '{change.new_first_kind_id}',new_first_kind_name = '{change.new_first_kind_name}',new_second_kind_id = '{change.new_second_kind_id}', new_second_kind_name='{change.new_second_kind_name}',new_major_kind_id='{change.new_major_kind_id}',new_third_kind_id='{change.new_third_kind_id}',new_third_kind_name='{change.new_third_kind_name}',new_major_kind_name='{change.new_major_kind_id}',new_major_id='{change.new_major_id}',new_major_name='{change.new_major_name}',new_salary_standard_id='{change.new_salary_standard_id}',new_salary_standard_name='{change.new_salary_standard_name}',new_salary_sum='{change.new_salary_sum}',check_reason = '{change.check_reason}',check_status=1,checker='{change.checker}',check_time='{change.check_time}' WHERE mch_id = '{change.mch_id}'";

                int c = await sqlConnection.ExecuteAsync(sql);
                if (c == 0)
                {
                    return 0;
                }
                string sql1 = $"UPDATE [dbo].[human_file]  SET status = 2 ,first_kind_id = '{change.new_first_kind_id}',first_kind_name = '{change.new_first_kind_name}',second_kind_id = '{change.new_second_kind_id}',second_kind_name = '{change.new_second_kind_name}',third_kind_id = '{change.new_third_kind_id}',third_kind_name='{change.new_third_kind_name}' where human_id = '{change.human_id}'";
                return await sqlConnection.ExecuteAsync(sql1);
            }
        }
        /// <summary>
        /// 审核不通过
        /// </summary>
        /// <param name="change"></param>
        /// <returns></returns>
        public async Task<int> Xiu1(Major_change change)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"UPDATE [dbo].[major_change] SET check_status =2 where mch_id = '{change.mch_id}'";

                int c = await sqlConnection.ExecuteAsync(sql);
                if (c == 0)
                {
                    return 0;
                }
                string sql1 = $"UPDATE [dbo].[human_file]  SET status = 0 where human_id = '{change.human_id}'";
                return await sqlConnection.ExecuteAsync(sql1);
            }
        }
      
        /// <summary>
        /// 根据条件调动查询
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public async Task<FenYe<Major_change>> changesAsync(int PageSize, int CurrentPage, string Condition)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", PageSize);
                dynamicParameters.Add("@keyName", "mch_id");
                dynamicParameters.Add("@tabelName", "major_change");
                dynamicParameters.Add("@where", Condition);
                dynamicParameters.Add("@currentPage", CurrentPage);
                dynamicParameters.Add("@lie", "*");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec  [dbo].[proc_FenyeMo] @pageSize,@keyName,@tabelName,@where,@currentPage,@lie,@rows out";
                IEnumerable<Major_change> list = await sqlConnection.QueryAsync<Major_change>(sql, dynamicParameters);
                int row = dynamicParameters.Get<int>("rows");
                FenYe<Major_change> fc = new FenYe<Major_change>();
                fc.List = list;
                fc.Rows = row;
                return fc;
            }
        }


        public async Task<Major_change> changesAsync1(string tiao)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = "SELECT * FROM [dbo].[major_change] where mch_id = " + tiao;
                return await sqlConnection.QueryFirstAsync<Major_change>(sql);
            }
        }
    }
}
