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
    public class HfileDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";
        public async Task<IEnumerable<Config_file_first_kind>> EmSelect1()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = "SELECT * FROM config_file_first_kind";
                return await sqlConnection.QueryAsync<Config_file_first_kind>(sql);
            }
        }
        public async Task<IEnumerable<Config_file_second_kind>> EmSelect4(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_file_second_kind WHERE first_kind_name='{name}'";
                return await sqlConnection.QueryAsync<Config_file_second_kind>(sql);
            }
        }
        public async Task<IEnumerable<Config_file_third_kind>> EmSelect5(string name, string name1)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_file_third_kind where first_kind_name='{name}'And second_kind_name='{name1}'";
                return await sqlConnection.QueryAsync<Config_file_third_kind>(sql);
            }
        }
        public async Task<IEnumerable<Config_file_second_kind>> HfSelect(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_file_second_kind WHERE first_kind_name='{name}'";
                return await sqlConnection.QueryAsync<Config_file_second_kind>(sql);
            }
        }
        public async Task<IEnumerable<Config_public_char>> Hfzc()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='职称'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Human_file>> HfSexCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM human_file";
                return await sqlConnection.QueryAsync<Human_file>(sql);
            }

        }
        public async Task<Human_file> HfSexCxId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM human_file WHERE huf_id ={id}";
                return await sqlConnection.QueryFirstAsync<Human_file>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> HfGjCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='国籍'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> HfmzCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='民族'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> HfzjxyCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='宗教信仰'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> HfzzmmCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='政治面貌'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> HfxlCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='学历'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> HfnxCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='教育年限'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> HfzyCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='专业'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Human_file>> HfxcCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM human_file";
                return await sqlConnection.QueryAsync<Human_file>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> HftcCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='特长'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<IEnumerable<Config_public_char>> HfahCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_public_char WHERE attribute_kind='爱好'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
            }

        }
        public async Task<int> HfInsert(Human_file h)
        {
           
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                Random random = new Random();
                string result = "bt";
                for (int i = 0; i < 18; i++)
                {
                    result += random.Next(0, 10).ToString(); // 生成0到9之间的随机数并拼接
                }
                string sql = $@"INSERT INTO human_file(human_id,[first_kind_id],first_kind_name,[second_kind_id],second_kind_name,third_kind_id,third_kind_name,human_major_kind_name,hunma_major_name,human_pro_designation,human_name,human_sex,human_email,human_telephone,human_qq,human_mobilephone,human_address,human_postcode,human_nationality,human_birthplace,human_birthday,human_race,human_religion,human_party,human_id_card,human_society_security_id,human_age,human_educated_degree,human_educated_years,human_educated_major,salary_standard_name,human_bank,human_account,checker,regist_time,human_speciality,human_hobby,human_histroy_records,human_family_membership,remark,human_picture)
                VALUES('{result}',(select [first_kind_id] from [dbo].[config_file_third_kind] where [first_kind_name]='{h.first_kind_name}'),'{h.first_kind_name}',(select [first_kind_id] from [dbo].[config_file_third_kind] where [second_kind_name]='{h.second_kind_name}'),'{h.second_kind_name}',(select third_kind_id from [dbo].[config_file_third_kind] where third_kind_name='{h.third_kind_name}'),'{h.third_kind_name}','{h.human_major_kind_name}','{h.hunma_major_name}','{h.human_pro_designation}','{h.human_name}','{h.human_sex}','{h.human_email}','{h.human_telephone}','{h.human_qq}','{h.human_mobilephone}','{h.human_address}','{h.human_postcode}','{h.human_nationality}','{h.human_birthplace}','{h.human_birthday}','{h.human_race}','{h.human_religion}','{h.human_party}','{h.human_id_card}','{h.human_society_security_id}','{h.human_age}','{h.human_educated_degree}','{h.human_educated_years}','{h.human_educated_major}','{h.salary_standard_name}','{h.human_bank}','{h.human_account}','{h.checker}','{h.regist_time}','{h.human_speciality}','{h.human_hobby}','{h.human_histroy_records}','{h.human_family_membership}','{h.remark}','{h.human_picture}')";
                return await connection.ExecuteAsync(sql);
            }
        }
        public async Task<IEnumerable<Human_file>> Human_Filescx() {
            using (SqlConnection sqlConnection = new SqlConnection(conStr)) {
                string sql = "SELECT*FROM human_file WHERE ";
                return await sqlConnection.QueryAsync<Human_file>(sql); 
              }
        }

        public async Task<FenYe<Human_file>> HfSelect(FenYe<Human_file> fenYe)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@keyName", "huf_id");
                dynamicParameters.Add("@tableName", "human_file");
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@where", fenYe.Condition);
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[procFenYe_1] @pageSize, @keyName, @tableName, @currentPage,@where, @rows out";
                fenYe.List = await sqlConnection.QueryAsync<Human_file>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }
        public async Task<IEnumerable<Config_file_second_kind>> EmSelect11(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_file_second_kind WHERE first_kind_name='{name}'";
                return await sqlConnection.QueryAsync<Config_file_second_kind>(sql);
            }
        }
        public async Task<IEnumerable<Config_file_third_kind>> EmSelect12(string name, string name1)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_file_third_kind where first_kind_name='{name}'And second_kind_name='{name1}'";
                return await sqlConnection.QueryAsync<Config_file_third_kind>(sql);
            }
        }
        public async Task<Human_file> HfSelect2(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM human_file WHERE huf_id={id}";
                return await sqlConnection.QueryFirstAsync<Human_file>(sql);
            }
        }
        public async Task<IEnumerable<Human_file>> Human_Filescxpj()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = " SELECT COUNT(*)as [human_id] FROM[dbo].[human_file]";
                return await sqlConnection.QueryAsync<Human_file>(sql);
            }
        }
        public async Task<int> FuHe_UPDATE(Human_file e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $@"update [dbo].[human_file] set [human_pro_designation]='{e.human_pro_designation}',[human_name]='{e.human_name}',[human_sex]='{e.human_sex}',[human_email]='{e.human_email}',[human_telephone]='{e.human_telephone}',
[human_qq]='{e.human_qq}',[human_mobilephone]='{e.human_mobilephone}',[human_address]='{e.human_address}',[human_postcode]='{e.human_postcode}',[human_nationality]='{e.human_nationality}',[human_birthplace]='{e.human_birthplace}',[human_birthday]='{e.human_birthday}',
[human_race]='{e.human_race}',[human_religion]='{e.human_religion}',[human_party]='{e.human_party}',[human_id_card]='{e.human_id_card}',[human_society_security_id]='{e.human_society_security_id}',[human_age]='{e.human_age}',
[human_educated_degree]='{e.human_educated_degree}',[human_educated_years]='{e.human_educated_years}',[human_educated_major]='{e.human_educated_major}',
[salary_standard_id]=(select standard_id from [dbo].[salary_standard] where [standard_name]='{e.salary_standard_name}'),
[salary_standard_name]='{e.salary_standard_name}',[salary_sum]=(select salary_sum from [dbo].[salary_standard] where [standard_name]='{e.salary_standard_name}'),
[human_bank]='{e.human_bank}',[human_account]='{e.human_account}',[checker]='{e.checker}',[check_time]='{e.check_time}',[human_speciality]='{e.human_speciality}',[human_hobby]='{e.human_hobby}',[human_histroy_records]='{e.human_histroy_records}',[human_family_membership]='{e.human_family_membership}',[remark]='{e.remark}',checker_status=1
 where[huf_id]='{e.huf_id}'";
                return await con.ExecuteAsync(sql);
            }

        }

        public async Task<IEnumerable<Config_public_char>> cccc(string kind)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $" SELECT*FROM Config_public_char WHERE attribute_kind='{kind}'";
                return await sqlConnection.QueryAsync<Config_public_char>(sql);
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

        public async Task<Engage_resume> HrSelect2(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM engage_resume WHERE res_id={id}";
                return await sqlConnection.QueryFirstAsync<Engage_resume>(sql);
            }
        }
        public async Task<IEnumerable<Salary_standard_details>> SaxcCx()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM salary_standard_details";
                return await sqlConnection.QueryAsync<Salary_standard_details>(sql);
            }

        }
    }

}
