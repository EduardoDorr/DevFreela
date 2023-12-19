using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using Dapper;

using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;
using DevFreela.Infrastructure.Persistence.Data;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DevFreelaDbContext _context;
    private readonly string _connectionString;

    public UserRepository(DevFreelaDbContext context, IConfiguration configuration)
    {
        _context = context;
        _connectionString = configuration.GetConnectionString("DevFreela");
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            var query = "SELECT * FROM Users";

            var users = await sqlConnection.QueryAsync<User>(query);

            return users;
        }
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            var query = "SELECT TOP 1 * FROM Users WHERE Id = @Id";

            var user = await sqlConnection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });

            return user;
        }
    }
}