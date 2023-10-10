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
    public class SalaStandDAO
    {

        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        /// <summary>
        /// 薪酬标准登记
        /// </summary>
        /// <param name="jin"></param>
        /// <param name="name"></param>
        /// <param name="bh"></param>
        /// <param name="salary"></param>
        /// <returns></returns>
        public async Task<int> Addto(string TotalAmount, string name, string XCnumbering, Salary_standard salary)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@standard_id", salary.standard_id);
                dynamicParameters.Add("@standard_name", salary.standard_name);
                dynamicParameters.Add("@item_ids", XCnumbering);
                dynamicParameters.Add("@item_names", name);
                dynamicParameters.Add("@salaries", TotalAmount);
                dynamicParameters.Add("@designer", salary.designer);
                dynamicParameters.Add("@register", salary.register);
                dynamicParameters.Add("@regist_time", salary.regist_time);
                dynamicParameters.Add("@remark", salary.remark);
                dynamicParameters.Add("@salary_sum", salary.salary_sum);
                return await sqlConnection.ExecuteAsync("xinshiwu", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// 薪酬登记复核显示
        /// </summary>
        /// <param name="fy"></param>
        /// <returns></returns>
        public async Task<FenYe<Salary_standard>> CharSelect(FenYe<Salary_standard> fy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fy.PageSize);
                dynamicParameters.Add("@keyName", "ssd_id");
                dynamicParameters.Add("@tableName", "salary_standard");
                dynamicParameters.Add("@currentPage", fy.CurrentPage);
                dynamicParameters.Add("@where", fy.Condition);
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[procFenYe_1] @pageSize, @keyName, @tableName, @currentPage,@where, @rows out";
                fy.List = await sqlConnection.QueryAsync<Salary_standard>(sql, dynamicParameters);
                fy.Rows = dynamicParameters.Get<int>("rows");
                return fy;
            }
        }

        /// <summary>
        /// 薪酬标准模糊查询
        /// </summary>
        /// <param name="fy"></param>
        /// <returns></returns>
        public async Task<FenYe<Salary_standard>> InquireSelect(int PageSize, int CurrentPage, string Condition)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", PageSize);
                dynamicParameters.Add("@keyName", "ssd_id");
                dynamicParameters.Add("@tabelName", "salary_standard");
                dynamicParameters.Add("@where", Condition);
                dynamicParameters.Add("@currentPage", CurrentPage);
                dynamicParameters.Add("@lie", "*");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[proc_FenyeMo] @pageSize,@keyName,@tabelName,@where,@currentPage,@lie,@rows out";
                IEnumerable<Salary_standard> list = await sqlConnection.QueryAsync<Salary_standard>(sql,dynamicParameters);
                int row = dynamicParameters.Get<int>("rows");
                FenYe<Salary_standard> fc = new FenYe<Salary_standard>();
                fc.List = list;
                fc.Rows = row;
                return fc;
            }
        }

        /// <summary>
        /// 薪酬标准查询(详情)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Salary_standard> Detail(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM [dbo].[salary_standard] WHERE standard_id = '{id}'";
                return await sqlConnection.QueryFirstAsync<Salary_standard>(sql);
            }
        }

        /// <summary>
        /// 进行修改的事务
        /// </summary>
        /// <returns></returns>
        public async Task<int> UpdateRevise(string id, string TotalAmount, Salary_standard salary)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@sdt_ids", id);
                dynamicParameters.Add("@salaries", TotalAmount);
                dynamicParameters.Add("@standard_id", salary.standard_id);
                dynamicParameters.Add("@standard_name", salary.standard_name);
                dynamicParameters.Add("@salary_sum", salary.salary_sum);
                dynamicParameters.Add("@designer", salary.designer);
                dynamicParameters.Add("@checker", salary.checker);
                dynamicParameters.Add("@check_time", salary.check_time);
                dynamicParameters.Add("@check_status", salary.check_status);
                dynamicParameters.Add("@change_status", salary.change_status);
                dynamicParameters.Add("@check_comment", salary.check_comment);
                return await sqlConnection.ExecuteAsync("revise", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// 薪酬标准变更修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Total"></param>
        /// <param name="salary"></param>
        /// <returns></returns>
        public async Task<int> StanChanges(string id, string Total, Salary_standard salary)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@sdt_ids", id);
                dynamicParameters.Add("@salaries", Total);
                dynamicParameters.Add("@standard_id", salary.standard_id);
                dynamicParameters.Add("@standard_name", salary.standard_name);
                dynamicParameters.Add("@salary_sum", salary.salary_sum);
                dynamicParameters.Add("@designer", salary.designer);
                dynamicParameters.Add("@changer", salary.changer);
                dynamicParameters.Add("@change_time ", salary.change_time);
                dynamicParameters.Add("@remark", salary.remark);
                return await sqlConnection.ExecuteAsync("reviseTwo", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Salary_standard>> Cha2()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = "SELECT ssd_id,standard_name FROM [dbo].[salary_standard] WHERE change_status =2";
                return await sqlConnection.QueryAsync<Salary_standard>(sql);
            }
        }

        /// <summary>
        /// 根据id查询总金额
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> Chajin(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT salary_sum FROM [dbo].[salary_standard] WHERE ssd_id = '{id}'";
                return await sqlConnection.QueryFirstAsync<int>(sql);
            }
        }
    }
}
