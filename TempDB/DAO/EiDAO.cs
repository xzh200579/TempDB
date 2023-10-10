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
    public class EiDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        public async Task<FenYe<Engage_interview>> EiSelect(FenYe<Engage_interview>fenYe)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@keyName", "ein_id");
                dynamicParameters.Add("@tableName", "engage_interview");
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[proc_FenYe] @pageSize, @keyName, @tableName, @currentPage, @rows out";
                fenYe.List = await sqlConnection.QueryAsync<Engage_interview>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }
        public async Task<Engage_interview> EiSelect2(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM engage_interview WHERE ein_id={id}";
                return await sqlConnection.QueryFirstAsync<Engage_interview>(sql);
            }
        }
        public async Task<Engage_resume> EnSelect3(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM engage_resume WHERE res_id='{id}'";
                return await sqlConnection.QueryFirstAsync<Engage_resume>(sql);
            }
        }
        public async Task<IEnumerable<Engage_interview>> EmSelect()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = "SELECT * FROM Engage_interview";
                return await sqlConnection.QueryAsync<Engage_interview>(sql);
            }
        }
        public async Task<int> fuhe_UPDATE(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"update engage_resume set [check_status]=1  where [res_id]={id}";
                return await con.ExecuteAsync(sql);
            }
        }
        public async Task<int> MianShi_ZhuangTaiUPDATE(int id, int name)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string d = " ";
                string s = "";
                if (name == 1)
                {
                    s = "建议面试";
                }
                else if (name == 2)
                {
                    s = "建议笔试";
                }
                else if (name == 3)
                {
                    s = "建议录用";
                }
                string sql = $"update engage_interview set interview_status={name},check_commen={s} where ein_id={id} ";
                return await con.ExecuteAsync(sql);
            }
        }
        public async Task<int> GenGaiMianShi(int id, int name)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                if (name == 3)
                {
                    string se = $"update engage_resume set interview_status={name},pass_check_status='1' where res_id={id}";
                    return await con.ExecuteAsync(se);
                }
                string sql = $"update engage_resume set interview_status={name} where res_id={id}";
                return await con.ExecuteAsync(sql);
            }
        }
        public async Task<int> MianShiXG2(Engage_interview s)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"update engage_interview set checker='{s.checker}',check_time='{s.check_time}'where ein_id={s.ein_id}";
                return await con.ExecuteAsync(sql);
            }
        }
        public async Task<int> MianShiXG22(Engage_interview s)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"INSERT INTO engage_interview(checker,check_time)VALUES('{s.checker}','{s.check_time}')";
                return await con.ExecuteAsync(sql);
            }
        }

        public async Task<FenYe<Engage_resume>> ErSelect(FenYe<Engage_resume> fenYe)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@keyName", "res_id");
                dynamicParameters.Add("@tableName", "engage_resume");
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[proc_FenYe] @pageSize, @keyName, @tableName, @currentPage, @rows out";
                fenYe.List = await sqlConnection.QueryAsync<Engage_resume>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }
        public async Task<int> luyou_shenqin(string id, string name)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"update [dbo].[engage_resume] set [pass_checkComment]={name} ,pass_check_status=2 where [res_id]={id} ";
                return await con.ExecuteAsync(sql);
            }
        }
        public async Task<int> luyou_shenqin1(string id, string name)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"update [dbo].[engage_resume] set pass_passComment={name} ,pass_check_status=3 where [res_id]={id} ";
                return await con.ExecuteAsync(sql);
            }
        }
        public async Task<int> mianshisc(int id)
        { 
            using(SqlConnection  con = new SqlConnection(conStr)) 
            {
                string sql = $"DELETE FROM engage_resume WHERE res_id='{id}'";
                return await con.ExecuteAsync(sql);
            }
        }
        public async Task<int> mianshisc1(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"DELETE FROM engage_interview WHERE ein_id='{id}'";
                return await con.ExecuteAsync(sql);
            }
        }
        public async Task<FenYe<Engage_resume>> shenpi(int? currentPage)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                if (currentPage == null)
                {
                    currentPage = 1;
                }
                string sum = "pass_check_status=2";
                DynamicParameters dynamic = new DynamicParameters();
                dynamic.Add("pageSize", 2);//每页显示
                dynamic.Add("columns", "res_id, human_name, engage_type, human_address, human_postcode, human_major_kind_id, human_major_kind_name, human_major_id, human_major_name, human_telephone, human_homephone, human_mobilephone, human_email, human_hobby, human_specility, human_sex, human_religion, human_party, human_nationality, human_race, human_birthday, human_age, human_educated_degree, human_educated_years, human_educated_major, human_college, human_idcard, human_birthplace, demand_salary_standard, human_history_records, remark, recomandation, human_picture, attachment_name, check_status, register, regist_time, checker, check_time, interview_status, total_points, test_amount, test_checker, test_check_time, pass_register, pass_regist_time, pass_checker, pass_check_time, pass_check_status, pass_checkComment, pass_passComment ");
                dynamic.Add("tableName", "engage_resume");
                dynamic.Add("currentPage", currentPage);//当前页
                dynamic.Add("order", "res_id");//排序
                dynamic.Add("where", sum);//条件
                dynamic.Add("totalCount", direction: System.Data.ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec per @tableName,@columns,@order,@pageSize,@currentPage,@where,@totalCount out";
                var sd = con.Query<Engage_resume>(sql, dynamic).ToList();
                int rows = dynamic.Get<int>("totalCount");
                FenYe<Engage_resume> fY = new FenYe<Engage_resume>();
                fY.List = sd;
                fY.Rows = rows;
                fY.CurrentPage=(int)currentPage;
                return fY;
                 }
        }
    }
}
