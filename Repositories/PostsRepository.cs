
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

<<<<<<< HEAD
        public async Task<List<MArticle>> Read(int pageNo, int pageSize)
=======
        public async Task<List<MPosts>> Read(int pageNo, int pageSize)
>>>>>>> 839a904f3d8485ea1399bcdb298c0bab7c708da8
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", 0);
            parameters.Add("@PageNo", pageNo);
            parameters.Add("@PageSize", pageSize);

            using (var connection = new SqlConnection(connectionString))
            {
<<<<<<< HEAD
                IEnumerable<MArticle> country = await connection.QueryAsync<MArticle>("master.SP_Posts_Read", parameters, commandType: CommandType.StoredProcedure);
=======
                IEnumerable<MPosts> country = await connection.QueryAsync<MPosts>("master.SP_Posts_Read", parameters, commandType: CommandType.StoredProcedure);
>>>>>>> 839a904f3d8485ea1399bcdb298c0bab7c708da8
                return country.ToList();
            }
        }

<<<<<<< HEAD
        public async Task<MArticle> Read(int id)
=======
        public async Task<MPosts> Read(int id)
>>>>>>> 839a904f3d8485ea1399bcdb298c0bab7c708da8
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            parameters.Add("@PageNo", 0);
            parameters.Add("@PageSize", 0);

            using (var connection = new SqlConnection(connectionString))
            {
<<<<<<< HEAD
                return await connection.QueryFirstOrDefaultAsync<MArticle>("master.SP_Posts_Read", parameters, commandType: CommandType.StoredProcedure);
=======
                return await connection.QueryFirstOrDefaultAsync<MPosts>("master.SP_Posts_Read", parameters, commandType: CommandType.StoredProcedure);
>>>>>>> 839a904f3d8485ea1399bcdb298c0bab7c708da8
            }
        }


<<<<<<< HEAD
        public async Task<string> Create(MArticle mpost)
=======
        public async Task<string> Create(MPosts mpost)
>>>>>>> 839a904f3d8485ea1399bcdb298c0bab7c708da8
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", mpost.RowStatus);
                parameters.Add("@Title", mpost.title);
                parameters.Add("@Context", mpost.context);
                parameters.Add("@Category", mpost.category);
                parameters.Add("@status", mpost.status);
                parameters.Add("@Created_date", mpost.Created_date);
                parameters.Add("@Updated_date", mpost.updated_date);
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

<<<<<<< HEAD
        public async Task<string> Update(MArticle mpost)
=======
        public async Task<string> Update(MPosts mpost)
>>>>>>> 839a904f3d8485ea1399bcdb298c0bab7c708da8
        {
            try
            {

                using (var connection = new SqlConnection(connectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@RowStatus", mpost.RowStatus);
                    parameters.Add("@Id", mpost.Id);
                    parameters.Add("@Title", mpost.title);
                    parameters.Add("@Context", mpost.context);
                    parameters.Add("@status", mpost.status);
                    parameters.Add("@Category", mpost.category);
                    parameters.Add("@Created_date", mpost.Created_date);
                    parameters.Add("@Updated_date", mpost.updated_date);

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
