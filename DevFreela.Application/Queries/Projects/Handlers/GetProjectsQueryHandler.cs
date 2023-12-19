using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using Dapper;
using MediatR;

using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.Projects.Handlers;

internal sealed class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, IEnumerable<ProjectViewModel>>
{
    private readonly string _connectionString;

    public GetProjectsQueryHandler(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DevFreela");
    }

    public async Task<IEnumerable<ProjectViewModel>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            var query = "SELECT Id, Title, Description, CreatedAt FROM Projects";

            var projects = await sqlConnection.QueryAsync<ProjectViewModel>(query);

            return projects;
        }
    }
}