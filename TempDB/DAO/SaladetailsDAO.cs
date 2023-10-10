using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SaladetailsDAO
    {

        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        /// <summary>
        ///进行查询具体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Salary_standard_details>> ChaYi(string id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conStr))
            {
                string sql = $"SELECT * FROM [dbo].[salary_standard_details] WHERE standard_id = '{id}'";
                return await sqlConnection.QueryAsync<Salary_standard_details>(sql);
            }
        }

    }
}
