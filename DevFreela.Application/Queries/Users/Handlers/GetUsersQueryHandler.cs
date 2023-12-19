using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using Dapper;
using MediatR;

using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.Users.Handlers;

internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserViewModel>>
{
    private readonly string _connectionString;

    public GetUsersQueryHandler(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DevFreela");
    }

    public async Task<IEnumerable<UserViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            var query = "SELECT Id, Name, Email, Active FROM Users";

            var users = await sqlConnection.QueryAsync<UserViewModel>(query);

            return users;
        }
    }
}