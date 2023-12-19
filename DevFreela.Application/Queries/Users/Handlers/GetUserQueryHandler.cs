using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using Dapper;
using MediatR;

using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.Users.Handlers;

internal sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel?>
{
    private readonly string _connectionString;

    public GetUserQueryHandler(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DevFreela");
    }

    public async Task<UserViewModel?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            var query = "SELECT Id, Name, Email, Active FROM Users WHERE Id = @Id";

            var user = await sqlConnection.QueryFirstOrDefaultAsync<UserViewModel>(query, new { request.Id });

            return user;
        }
    }
}