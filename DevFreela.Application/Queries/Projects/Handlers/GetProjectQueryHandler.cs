using System.Text;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using Dapper;
using MediatR;

using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.Projects.Handlers;

internal sealed class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectDetailsViewModel?>
{
    private readonly string _connectionString;

    public GetProjectQueryHandler(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DevFreela");
    }

    public async Task<ProjectDetailsViewModel?> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            var query = new StringBuilder();
            query.AppendLine("SELECT                                            ")
                 .AppendLine("  P.Id, P.Title, P.Description, P.StartedAt,      ")
                 .AppendLine("  P.FinishedAt, P.TotalCost, P.CreatedAt,         ")
                 .AppendLine("  U.Name AS ClientName, F.Name AS FreelancerName  ")
                 .AppendLine("FROM Projects P                                   ")
                 .AppendLine("INNER JOIN Users U                                ")
                 .AppendLine("ON P.ClientId = U.Id                              ")
                 .AppendLine("INNER JOIN Users F                                ")
                 .AppendLine("ON P.FreelancerId = F.Id                          ")
                 .AppendLine("WHERE P.Id = @Id                                  ");

            var project = await sqlConnection.QueryFirstOrDefaultAsync<ProjectDetailsViewModel?>(query.ToString(), new { request.Id });

            return project;
        }
    }
}