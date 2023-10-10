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
    public class EresumeDAO
    {

        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        public async Task<IEnumerable<config_major>> MajorSelect()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = "SELECT * FROM config_major";
                return await sqlConnection.QueryAsync<config_major>(sql);
            }
        }
        public async Task<IEnumerable<config_major_kind>> MkindSelete()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = "SELECT * FROM config_major_kind";
                return await sqlConnection.QueryAsync<config_major_kind>(sql);
            }
        }
        public async Task<IEnumerable<Engage_major_release>> EmSelect()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = "SELECT * FROM engage_major_release";
                return await sqlConnection.QueryAsync<Engage_major_release>(sql);
            }
        }
        public async Task<IEnumerable<Engage_resume>> EnSexCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM engage_resume";
                return await sqlConnection.QueryAsync<Engage_resume>(sql);
            }

        }
    
        public async Task<IEnumerable<Config_public_char>> EnGjCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='国籍'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> EnmzCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='民族'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> EnzjxyCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='宗教信仰'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> EnzzmmCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='政治面貌'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> EnxlCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='学历'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> EnxlxCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='学历'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> EnnxCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='教育年限'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> EnzyCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='专业'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> EntcCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='特长'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> EnahCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='爱好'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> Config_public_charSelectAsync(string kind)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"select * from Config_public_char where attribute_kind='{kind}'";

                return await connection.QueryAsync<Config_public_char>(sql);
            }
        }
        //human_major_kind_name，human_major_name，human_name，human_sex，human_postcode，human_telephone，human_homephone，human_mobilephone，human_address，human_postcode，human_nationality，human_birthplace，human_birthday，human_race，human_religion，human_party，human_idcard，human_age，human_college，human_educated_degree，human_educated_years，human_educated_major，demand_salary_standard，regist_time，human_specility，human_hobby，human_history_records，remark
        public async Task<int> EresumeInsert(Engage_resume e)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                               string sql = 
                $@"insert into [dbo].[engage_resume]
                                    ([human_major_kind_id],[human_major_kind_name],
                                        [human_major_id],[human_major_name],[engage_type],
                                        [human_name],[human_sex],[human_email],
                                        [human_telephone],[human_homephone],[human_mobilephone],
                                        [human_address],[human_postcode],
                                        [human_nationality],[human_birthplace],[human_birthday],
                                        [human_race],[human_religion],[human_party],
                                        [human_idcard],[human_age],[human_college],[human_educated_degree],
                                        human_educated_years,human_educated_major,demand_salary_standard,regist_time,
                                        human_specility,human_hobby,human_history_records,remark,human_picture,interview_status,check_status)
                                        values((select major_kind_id from config_major_kind where major_kind_name='{e.Major_kind_name}'),'{e.Major_kind_name}',
                                         (select major_id from config_major where major_name='{e.Major_name}'),'{e.Major_name}',
                                        '{e.engage_type}','{e.human_name}','{e.human_sex}','{e.human_email}','{e.human_telephone}','{e.human_homephone}','{e.human_mobilephone}',
                                        '{e.human_address}','{e.human_postcode}','{e.human_nationality}','{e.human_birthplace}','{e.human_birthday}',
                                        '{e.human_race}','{e.human_religion}','{e.human_party}','{e.human_idcard}','{e.human_age}','{e.human_college}',
                                        '{e.human_educated_degree}','{e.human_educated_years}','{e.human_educated_major}','{e.demand_salary_standard}',
                                        '{e.regist_time}','{e.human_specility}','{e.human_hobby}','{e.human_history_records}','{e.remark}','{e.human_picture}',0,0)";
                return await connection.ExecuteAsync(sql);
                
            }

        }


        //面试管理
        public async Task<FenYe<Engage_resume>> Emselect(FenYe<Engage_resume> fy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fy.PageSize);
                dynamicParameters.Add("@keyName", "res_id");
                dynamicParameters.Add("@tableName", "Engage_resume");
                dynamicParameters.Add("@currentPage", fy.CurrentPage);
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec[dbo].[proc_FenYe] @pageSize, @keyName, @tableName, @currentPage, @rows out";
                fy.List = await sqlConnection.QueryAsync<Engage_resume>(sql, dynamicParameters);
                fy.Rows = dynamicParameters.Get<int>("rows");
                return fy;
            }

        }

        public async Task<Engage_resume> EmgageSelectId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM engage_resume WHERE res_id='{id}'";
                return await sqlConnection.QueryFirstAsync<Engage_resume>(sql);
            }
        }
        public async Task<IEnumerable<Engage_interview>> EigageSelectId()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM engage_interview";
                return await sqlConnection.QueryAsync<Engage_interview>(sql);
            }
        }
        public async Task<FenYe<Engage_resume>> select(FenYe<Engage_resume> fenYe)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@keyName", "res_id");
                dynamicParameters.Add("@tableName", "Engage_resume");
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[proc_FenYe] @pageSize, @keyName, @tableName, @currentPage, @rows out";
                fenYe.List = await con.QueryAsync<Engage_resume>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }
        public async Task<Engage_resume> selectid(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select * from Engage_resume where res_id={id} and interview_status='0'";
                return await con.QueryFirstAsync<Engage_resume>(sql);
            }
        }
        public async Task<Engage_resume> Engage_major_releaseSelectkindidAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"select major_kind_id,major_kind_name,major_id,major_name, engage_type from Engage_major_release where mre_id={id}";
                return await connection.QueryFirstAsync<Engage_resume>(sql);
            }
        }
        public async Task<int> update(Engage_resume e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $@"update [dbo].[engage_resume] 
set [engage_type]='{e.engage_type}',[human_name]='{e.human_name}',[human_sex]='{e.human_sex}',[human_email]='{e.human_email}',
[human_telephone]='{e.human_telephone}',[human_homephone]='{e.human_homephone}',[human_mobilephone]='{e.human_mobilephone}',
[human_address]='{e.human_address}',[human_postcode]='{e.human_postcode}',
[human_nationality]='{e.human_nationality}',[human_birthplace]='{e.human_birthplace}',[human_birthday]='{e.human_birthday}',
[human_race]='{e.human_race}',[human_religion]='{e.human_religion}',[human_party]='{e.human_party}',
[human_idcard]='{e.human_idcard}',[human_age]='{e.human_age}',[human_college]='{e.human_college}',[human_educated_degree]='{e.human_educated_degree}',
[human_educated_years]='{e.human_educated_years}',[human_educated_major]='{e.human_educated_major}',[demand_salary_standard]='{e.demand_salary_standard}',
[human_specility]='{e.human_specility}',[human_hobby]='{e.human_hobby}',[checker]='{e.checker}',[check_time]='{e.check_time}',
[human_history_records]='{e.human_history_records}',[remark]='{e.remark}',[recomandation]='{e.recomandation}',[check_status]='1' where [res_id]='{e.res_id}'";
                return await con.ExecuteAsync(sql);
            }
        }
        public async Task<FenYe<Engage_resume>> tjselect(int pageSize, int currentPage, string human_major_kind_name, string human_major_name, string remark, string begintime, string endtime, int a)
        {
            FenYe<Engage_resume> fenYe = new FenYe<Engage_resume>();
            fenYe.PageSize = pageSize;
            fenYe.CurrentPage = currentPage;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sum = "1=1 AND interview_status=0";
                if (a == 0)
                {
                    sum += "AND check_status=0";
                }
                if (a == 1)
                {
                    sum += "AND check_status=1";
                }
                if (human_major_kind_name != null)
                {
                    sum += $"AND human_major_kind_name like '{human_major_kind_name}'";
                }
                if (human_major_name != null)
                {
                    sum += $"AND human_major_name like '{human_major_name}'";
                }
                if (begintime != null && endtime != null)
                {
                    sum += $"AND regist_time between'{begintime}'and '{endtime}'";
                }
                if (remark != null)
                {
                    sum += $"AND remark like '%{remark}%'";
                }
                DynamicParameters dynamic = new DynamicParameters();
                dynamic.Add("@pageSize", fenYe.PageSize);
                dynamic.Add("@keyName", "res_id");
                dynamic.Add("@tableName", "Engage_resume");
                dynamic.Add("@currentPage", fenYe.CurrentPage);
                dynamic.Add("@where", sum);
                dynamic.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[pFenYe] @pageSize,@keyName,@tableName,@currentPage,@where,@rows out";
                fenYe.List = await con.QueryAsync<Engage_resume>(sql, dynamic);
                fenYe.Rows = dynamic.Get<int>("rows");
                return fenYe;
            }
        }
        public async Task<int> Insert(Engage_interview e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"INSERT INTO engage_interview(interview_amount,image_degree,native_language_degree,foreign_language_degree,response_speed_degree,EQ_degree,IQ_degree,multi_quality_degree,register,registe_time,interview_comment)VALUES('{e.interview_amount}','{e.image_degree}','{e.native_language_degree}','{e.foreign_language_degree}','{e.response_speed_degree}','{e.EQ_degree}','{e.IQ_degree}','{e.multi_quality_degree}','{e.register}','{e.registe_time}','{e.interview_comment}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }
        public async Task<int> MianShiJieGuo(Engage_interview s)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $@"insert into  [dbo].[engage_interview](human_name, interview_amount, human_major_kind_id, human_major_kind_name, human_major_id,
             human_major_name, image_degree, native_language_degree, foreign_language_degree, response_speed_degree, 
             EQ_degree, IQ_degree, multi_quality_degree, register, checker,interview_comment,
              check_status,registe_time,resume_id) 
            values('{s.human_name}','{s.interview_amount}','{s.human_major_kind_id}','{s.human_major_kind_name}','{s.human_major_id}',
                '{s.human_major_name}', '{s.image_degree}', '{s.native_language_degree}', '{s.foreign_language_degree}', '{s.response_speed_degree}',
                 '{s.EQ_degree}', '{s.IQ_degree}', '{s.multi_quality_degree}', '{s.register}', '{s.checker}',{1},
                    '{s.check_status}','{s.registe_time}','{s.resume_id}'
                )"; //,
                return await con.ExecuteAsync(sql);
            }
        }

    }
}
