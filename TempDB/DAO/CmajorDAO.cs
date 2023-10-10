using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Model;

namespace DAO
{
    public class CmajorDAO
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
        
        public async Task<int> MojorInsert(config_major config_Major)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr)) {
                //string sun = "";
                //sun = config_Major.major_kind_id;
                //string ss = config_Major.major_kind_name;
                //config_Major.major_kind_name = sun;
                //config_Major.major_kind_id = ss;
                string sql = $"INSERT INTO [dbo].[config_major](major_kind_id,major_kind_name,major_id,major_name)VALUES('{config_Major.major_kind_id}','{config_Major.major_kind_name}','{config_Major.major_id}','{config_Major.major_name}')";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        public async Task<int> MojorDelete(int id) {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"DELETE FROM config_major WHERE mak_id={id}";
                return await sqlConnection.ExecuteAsync(sql);
            }
        }

        public async Task<IEnumerable<config_major>> XXX(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM config_major WHERE major_kind_name='{name}'";
                return await sqlConnection.QueryAsync<config_major>(sql);
            }
        }
        public async Task<IEnumerable<config_major>> Config_majorSelectIDAsync(string name)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"select major_name from Config_major where major_kind_name='{name}'";
                return await connection.QueryAsync<config_major>(sql);
            }
        }
        public async Task<IEnumerable<config_major>> Config_majorSelectIDAsyncTT()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"select major_name from Config_major";
                return await connection.QueryAsync<config_major>(sql);
            }
        }
        public async Task<IEnumerable<config_major_kind>> Config_major_kindSelectAsync111()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from Config_major_kind";
                return await connection.QueryAsync<config_major_kind>(sql);
            }
        }
        public async Task<int> Config_majorInsertAsync111(config_major c)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"insert into Config_major(major_kind_id,major_kind_name,major_id,major_name)values((select major_kind_id from config_major_kind where Major_kind_name='{c.major_kind_id}'),'{c.major_kind_id}','{c.major_id}','{c.major_name}')";
                return await connection.ExecuteAsync(sql);
            }
        }
    }
}
