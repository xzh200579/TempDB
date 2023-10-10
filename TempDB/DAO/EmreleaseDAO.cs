using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dapper;
using Model;

namespace DAO
{
    public class EmreleaseDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        public async Task<IEnumerable<Engage_major_release>> EmSelect()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = "SELECT * FROM engage_major_release";
                return await sqlConnection.QueryAsync<Engage_major_release>(sql);
            }
        }

         public async Task<int> EmInsert(Engage_major_release engage_Major_Release) {
            using (SqlConnection sqlConnection=new SqlConnection(conStr)) {
                string sql = $"INSERT INTO engage_major_release(first_kind_name,second_kind_name,third_kind_name,engage_type,major_kind_name,major_name,human_amount,deadline,register,regist_time,major_describe,engage_required)VALUES('{engage_Major_Release.first_kind_name}','{engage_Major_Release.second_kind_name}','{engage_Major_Release.third_kind_name}','{engage_Major_Release.engage_type}','{engage_Major_Release.major_kind_name}','{engage_Major_Release.major_name}','{engage_Major_Release.human_amount}','{engage_Major_Release.deadline}','{engage_Major_Release.register}','{engage_Major_Release.regist_time}','{engage_Major_Release.major_describe}','{engage_Major_Release.engage_required}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }
        public async Task<IEnumerable<config_major>> MajorSelect()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = "SELECT * FROM config_major";
                return await sqlConnection.QueryAsync<config_major>(sql);
            }
        }
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
        public async Task<IEnumerable<Config_file_third_kind>> EmSelect5(string name,string name1)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_file_third_kind where first_kind_name='{name}'And second_kind_name='{name1}'";
                return await sqlConnection.QueryAsync<Config_file_third_kind>(sql);
            }
        }
        public async Task<IEnumerable<Config_file_third_kind>> Em1()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_file_third_kind ";
                return await sqlConnection.QueryAsync<Config_file_third_kind>(sql);
            }
        }


        //职位发布变更分页查询
        public async Task<FenYe<Engage_major_release>> EngageSelect(FenYe<Engage_major_release> fy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fy.PageSize);
                dynamicParameters.Add("@keyName", "mre_id");
                dynamicParameters.Add("@tableName", "engage_major_release");
                dynamicParameters.Add("@currentPage", fy.CurrentPage);
                dynamicParameters.Add("@where", fy.Condition);
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[procFenYe_1] @pageSize, @keyName, @tableName, @currentPage,@where, @rows out";
                fy.List = await sqlConnection.QueryAsync<Engage_major_release>(sql, dynamicParameters);
                fy.Rows = dynamicParameters.Get<int>("rows");
                return fy;
            }
        }

        //职位发布变更删除
        public async Task<int> EngageDelete(int id)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"DELETE FROM engage_major_release WHERE mre_id= '{id}'";
                return await connection.ExecuteAsync(sql);
            }
        }
        //职位发布变更Id查询
        public async Task<Engage_major_release> EngageSelectId(int id) {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM engage_major_release WHERE mre_id='{id}'";
                return await sqlConnection.QueryFirstAsync<Engage_major_release>(sql);
           }
        }
        public async Task<int> Engage_major_releaseUpdateAsync(Engage_major_release e)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $@" update [engage_major_release] set 
[first_kind_id]=(select [first_kind_id] from[dbo].[config_file_first_kind] where [first_kind_name]='{e.first_kind_name}'),[first_kind_name]='{e.first_kind_name}',
[second_kind_id]=(select [second_kind_id] from [dbo].[config_file_second_kind] where [second_kind_name]='{e.second_kind_name}'),[second_kind_name]='{e.second_kind_name}',
[third_kind_id]=(select [third_kind_id] from [dbo].[config_file_third_kind] where [third_kind_name]='{e.third_kind_name}'),[third_kind_name]='{e.third_kind_name}',
[major_kind_id]=(select [major_kind_id] from [dbo].[config_major_kind] where [major_kind_name]='{e.major_kind_name}'),[major_kind_name]='{e.major_kind_name}',
[major_id]=(select [major_id] from [dbo].[config_major] where [major_name]='{e.major_name}'),[major_name]='{e.major_name}',
[human_amount]='{e.human_amount}',[engage_type]='{e.engage_type}',[deadline]='{e.deadline}',[changer]='{e.changer}',[change_time]='{e.change_time}',[major_describe]='{e.major_describe}',[engage_required]='{e.engage_required}',checke=1 where mre_id='{e.mre_id}'";
                return await connection.ExecuteAsync(sql);

            }
        }
    }
}
