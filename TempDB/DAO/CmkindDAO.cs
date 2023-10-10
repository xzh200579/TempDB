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
    public class CmkindDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        public async Task<IEnumerable<config_major_kind>> MkindSelete() {
            using (SqlConnection sqlConnection = new SqlConnection(conStr)) {
                string sql = "SELECT * FROM config_major_kind";
                return await sqlConnection.QueryAsync<config_major_kind>(sql);
            }
        }
        public async Task<int> MkindDelete(int id) {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
               string sql = $"DELETE  FROM config_major_kind WHERE mfk_id={id} ";
                return await sqlConnection.ExecuteAsync(sql); 
            }
        }

        public async Task<int> MkindInsert(config_major_kind config_Major_Kind)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"insert into [dbo].[config_major_kind]([major_kind_id],[major_kind_name])values((SELECT TOP 1  CASE  WHEN  + 1 < 10 THEN '0' + CAST([major_kind_id] + 1 AS VARCHAR(2)) ELSE CAST([major_kind_id] + 1 AS VARCHAR(2))  END AS FormattedValue FROM [dbo].[config_major_kind] ORDER BY [major_kind_id] DESC),'{config_Major_Kind.major_kind_name}')";
                return await connection.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// 联级查一级
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LevelTwo>> ChaLian()
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = "SELECT * FROM [dbo].[config_major_kind]";
                IEnumerable<config_major_kind> firsts = await sqlConnection.QueryAsync<config_major_kind>(sql);
                List<LevelTwo> jis = new List<LevelTwo>();
                foreach (config_major_kind first in firsts)
                {
                    LevelTwo lian = new LevelTwo()
                    {
                        value = first.major_kind_id,
                        label = first.major_kind_name,
                        children = await ChaLian2(first.major_kind_id)
                    };
                    jis.Add(lian);
                }
                return jis;
            }
        }

        /// <summary>
        /// 进行联查2级
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LevelTwo>> ChaLian2(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM [dbo].[config_major] where major_kind_id = '{id}'  ";
                IEnumerable<config_major> firsts = await sqlConnection.QueryAsync<config_major>(sql);
                List<LevelTwo> jis = new List<LevelTwo>();
                foreach (config_major first in firsts)
                {
                    LevelTwo lian = new LevelTwo()
                    {
                        value = first.major_id,
                        label = first.major_name
                    };
                    jis.Add(lian);
                }
                return jis;
            }
        }


        public async Task<IEnumerable<config_major_kind>> Config_major_kindSelectAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from Config_major_kind";
                return await connection.QueryAsync<config_major_kind>(sql);
            }
        }
    }
}
