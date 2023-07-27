using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using $safeprojectname$.Models;
using $safeprojectname$.Models.DTO;

namespace $safeprojectname$.Repositories
{
    /// <summary>
    /// Repository digunakan untuk mengambil data
    /// dari database yang akan dipassing ke
    /// controller
    /// </summary>
    public class Repository : IRepository
    {
        private readonly IDbConnection Connection;

        public Repository()
        {
            // Get ConnectionString From Web.Config
            Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        }

        public async Task<IEnumerable<Model>> ExampleTaskAsync(Dto dto)
        {
            var param = new DynamicParameters();
            param.Add("@Parameter1", dto.Parameter1);
            param.Add("@Parameter2", dto.Parameter2);

            var result = await Connection.QueryAsync<Model>("dbo.Nama_Stored_Procedures", param, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<IEnumerable<Model>> ExamplePaginatedTaskAsync(PaginatedDto dto)
        {
            var param = new DynamicParameters();
            param.Add("@Parameter1", dto.Parameter1);
            param.Add("@Parameter2", dto.Parameter2);
            param.Add("@Page", dto.Page);
            param.Add("@Size", dto.Size);

            var result = await Connection.QueryAsync<Model>("dbo.Nama_Paginated_Stored_Procedures", param, commandType: CommandType.StoredProcedure);
            return result;
        }



    }
}