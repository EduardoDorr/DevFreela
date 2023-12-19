using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using Dapper;
using MediatR;

using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.Skills.Handlers;

internal sealed class GetSkillsQueryHandler : IRequestHandler<GetSkillsQuery, IEnumerable<SkillViewModel>>
{
    private readonly string _connectionString;

    public GetSkillsQueryHandler(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DevFreela");
    }

    public async Task<IEnumerable<SkillViewModel>> Handle(GetSkillsQuery request, CancellationToken cancellationToken)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            var query = "SELECT Id, Description FROM Skills";

            var skills = await sqlConnection.QueryAsync<SkillViewModel>(query);

            return skills;
        }
    }
}