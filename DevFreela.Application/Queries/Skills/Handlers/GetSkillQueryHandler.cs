using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using Dapper;
using MediatR;

using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.Skills.Handlers;

internal sealed class GetSkillQueryHandler : IRequestHandler<GetSkillQuery, SkillViewModel?>
{
    private readonly string _connectionString;

    public GetSkillQueryHandler(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DevFreela");
    }

    public async Task<SkillViewModel?> Handle(GetSkillQuery request, CancellationToken cancellationToken)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            var query = "SELECT TOP 1 Id, Description FROM Skills WHERE Id = @Id";

            var skill = await sqlConnection.QueryFirstOrDefaultAsync<SkillViewModel>(query, new { request.Id });

            return skill;
        }
    }
}
