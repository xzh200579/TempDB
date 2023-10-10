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
    public class SalarygrantDAO
    {

        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";
        /// <summary>
        /// 筛选
        /// </summary>
        /// <param name="tiao"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Human_file>> SXuanAsync(string tiao)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT salary_standard_id,human_name,human_id, huf_id , [first_kind_id],[first_kind_name],[second_kind_id],[second_kind_name],[third_kind_id],[third_kind_name], sum([demand_salaray_sum]) as [demand_salaray_sum],sum(salary_sum) as salary_sum,sum([paid_salary_sum]) as [paid_salary_sum], sum(case when {tiao} then 1 else 0 end) as human_amount FROM [dbo].[human_file] where {tiao} GROUP BY huf_id, [first_kind_name],[second_kind_name],[third_kind_name],[first_kind_id],[second_kind_id],[third_kind_id],salary_standard_id,human_name,human_id";
                return await sqlConnection.QueryAsync<Human_file>(sql);
            }
        }

        /// <summary>
        /// 薪酬管理登记
        /// </summary>
        /// <param name="sd"></param>
        /// <param name="djr"></param>
        /// <param name="time"></param>
        /// <param name="grants"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> FindAsync(List<Salary_grant_details> sd, string djr, string time, List<Salary_grant> grants, string id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                double sum = 0;
                double sum1 = 0;
                int r = 0;
                Random random = new Random();
                string result = "";
                for (int i = 0; i < 13; i++)
                {
                    result += random.Next(0, 10).ToString(); // 生成0到9之间的随机数并拼接
                }
                foreach (var item in sd)
                {
                    r++;
                    sum += item.salary_paid_sum;
                    sum1 += item.salary_standard_sum;
                    string sql = $@"INSERT INTO [dbo].[salary_grant_details]( [salary_grant_id], [human_id], [human_name], [bouns_sum], [sale_sum], [deduct_sum], [salary_standard_sum], [salary_paid_sum]) VALUES('{result}','{item.human_id}','{item.human_name}','{item.bouns_sum}','{item.sale_sum}','{item.deduct_sum}','{item.salary_standard_sum}','{item.salary_paid_sum}')";
                    int dore = await con.ExecuteAsync(sql);
                    if (dore == 0)
                    {
                        return 0;
                    }
                }
                string sql2 = $@"INSERT INTO [dbo].[salary_grant](salary_grant_id, salary_standard_id, first_kind_id, first_kind_name, second_kind_id, second_kind_name, third_kind_id, third_kind_name, human_amount, salary_standard_sum, salary_paid_sum, register, regist_time, check_status) VALUES ('{result}','{sd[0].salary_grant_id}','{grants[0].first_kind_id}','{grants[0].first_kind_name}','{grants[0].second_kind_id}','{grants[0].second_kind_name}','{grants[0].third_kind_id}','{grants[0].third_kind_name}','{r}','{sum}','{sum1}','{djr}','{time}','0')";
                int c = await con.ExecuteAsync(sql2);
                if (c == 0)
                {
                    return 0;
                }
                string sql3 = $"UPDATE [dbo].[human_file] SET check_status = 4 WHERE huf_id  = '{id}'";
                return await con.ExecuteAsync(sql3);
            }
        }

        /// <summary>
        /// 薪酬发放登记复核显示
        /// </summary>
        /// <param name="fy"></param>
        /// <returns></returns>
        public async Task<FenYe<Salary_grant>> CharXCSelect(FenYe<Salary_grant> fy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fy.PageSize);
                dynamicParameters.Add("@keyName", "sgr_id");
                dynamicParameters.Add("@tableName", "salary_grant");
                dynamicParameters.Add("@currentPage", fy.CurrentPage);
                dynamicParameters.Add("@where", fy.Condition);
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[procFenYe_1] @pageSize, @keyName, @tableName, @currentPage,@where, @rows out";
                fy.List = await sqlConnection.QueryAsync<Salary_grant>(sql, dynamicParameters);
                fy.Rows = dynamicParameters.Get<int>("rows");
                return fy;
            }
        }

        public async Task<int> FuAsync(List<Salary_grant_details> sd, string djr, string time, string jin, List<Human_file> files)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                double sum = 0;
                foreach (var item in sd)
                {
                    sum += item.salary_paid_sum;
                    string sql = $@"UPDATE salary_grant_details SET bouns_sum = '{item.bouns_sum}',sale_sum = '{item.sale_sum}',deduct_sum = '{item.deduct_sum}',  salary_standard_sum= '{item.salary_standard_sum}'  WHERE salary_grant_id = '{item.salary_grant_id}'";
                    int dore = await con.ExecuteAsync(sql);
                    if (dore == 0)
                    {
                        return 0;
                    }
                }
                string sql2 = $@"UPDATE [dbo].[salary_grant] SET [checker]='{djr}', [check_time]='{time}',check_status='2',[salary_paid_sum] = '{jin}' where  salary_grant_id='{sd[0].salary_grant_id}'";
                int c = await con.ExecuteAsync(sql2);
                if (c == 0) { return 0; }
                int cg = 0;
                foreach (var item in files)
                {
                    string sql3 = $"UPDATE [dbo].[human_file] SET paid_salary_sum = '{sum}' , check_status = 5 WHERE huf_id = '{item.huf_id}'";
                    cg = await con.ExecuteAsync(sql3);
                }
                return cg;
            }
        }

        /// <summary>
        /// 发放模糊查询
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public async Task<FenYe<Salary_grant>> InquireSelectFF(int PageSize, int CurrentPage, string Condition)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", PageSize);
                dynamicParameters.Add("@keyName", "sgr_id");
                dynamicParameters.Add("@tabelName", "salary_grant");
                dynamicParameters.Add("@where", Condition);
                dynamicParameters.Add("@currentPage", CurrentPage);
                dynamicParameters.Add("@lie", "*");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec  [dbo].[proc_FenyeMo] @pageSize,@keyName,@tabelName,@where,@currentPage,@lie,@rows out";
                IEnumerable<Salary_grant> list = await sqlConnection.QueryAsync<Salary_grant>(sql, dynamicParameters);
                int row = dynamicParameters.Get<int>("rows");
                FenYe<Salary_grant> fc = new FenYe<Salary_grant>();
                fc.List = list;
                fc.Rows = row;
                return fc;
            }
        }


        public async Task<IEnumerable<Salary_grant_details>> ChaAsync(string id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM [dbo].[salary_grant_details] WHERE salary_grant_id = '{id}'";
                return await con.QueryAsync<Salary_grant_details>(sql);
            }
        }
        public async Task<IEnumerable<Salary_standard_details>> FaCha(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM [dbo].[salary_standard_details] WHERE standard_id = '{id}'";
                return await sqlConnection.QueryAsync<Salary_standard_details>(sql);
            }
        }

        public async Task<Salary_grant> ChaYi(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM [dbo].[salary_grant] WHERE salary_grant_id = '{id}'";
                return await sqlConnection.QueryFirstAsync<Salary_grant>(sql);
            }
        }
    }
}
