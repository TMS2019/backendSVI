
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Infoss.Master.ExchangeRateService.Models;
namespace Infoss.Master.ExchangeRateService.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private string connectionString = string.Empty;

        public PostsRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("SqlConnection");
        }

        public async Task<List<Mposts>> Read(int pageNo, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", 0);
            parameters.Add("@PageNo", pageNo);
            parameters.Add("@PageSize", pageSize);

            using (var connection = new SqlConnection(connectionString))
            {
                IEnumerable<Mposts> country = await connection.QueryAsync<Mposts>("master.SP_Posts_Read", parameters, commandType: CommandType.StoredProcedure);
                return country.ToList();
            }
        }

        public async Task<Mposts> Read(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            parameters.Add("@PageNo", 0);
            parameters.Add("@PageSize", 0);

            using (var connection = new SqlConnection(connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Mposts>("master.SP_Posts_Read", parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public async Task<string> Create(Mposts mpost)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", mpost.RowStatus);
                parameters.Add("@Title", mpost.Title);
                parameters.Add("@Context", mpost.Context);
                parameters.Add("@Category", mpost.Category);
                parameters.Add("@status", mpost.status);
                parameters.Add("@Created_date", mpost.Created_date);
                parameters.Add("@Updated_date", mpost.Updated_date);
                using (var connection = new SqlConnection(connectionString))
                {
                    var affectedRows = await connection.ExecuteAsync("master.SP_Posts_Create", parameters, commandType: CommandType.StoredProcedure);
                    return "Affected Rows: " + affectedRows.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Update(Mposts mpost)
        {
            try
            {

                using (var connection = new SqlConnection(connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@RowStatus", mpost.RowStatus);
                    parameters.Add("@Id", mpost.Id);
                    parameters.Add("@Title", mpost.Title);
                    parameters.Add("@Context", mpost.Context);
                    parameters.Add("@status", mpost.status);
                    parameters.Add("@Category", mpost.Category);
                    parameters.Add("@Created_date", mpost.Created_date);
                    parameters.Add("@Updated_date", mpost.Updated_date);

                    var affectedRows = await connection.ExecuteAsync("master.SP_Posts_Update", parameters, commandType: CommandType.StoredProcedure);
                    return "Affected Rows: " + affectedRows.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);

                    var affectedRows = await connection.ExecuteAsync("master.SP_Posts_Delete", parameters, commandType: CommandType.StoredProcedure);
                    return "Affected Rows: " + affectedRows.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
