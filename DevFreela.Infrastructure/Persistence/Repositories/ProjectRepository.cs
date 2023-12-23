using System.Text;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using Dapper;

using DevFreela.Domain.Dtos;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;
using DevFreela.Infrastructure.Persistence.Data;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DevFreelaDbContext _context;
    private readonly string _connectionString;

    public ProjectRepository(DevFreelaDbContext context, IConfiguration configuration)
    {
        _context = context;
        _connectionString = configuration.GetConnectionString("DevFreela");
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            var query = "SELECT * FROM Projects";

            var projects = await sqlConnection.QueryAsync<Project>(query);

            return projects;
        }
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            var query = "SELECT * FROM Projects WHERE Id = @Id";

            var project = await sqlConnection.QueryFirstOrDefaultAsync<Project>(query, new { id });

            return project;
        }
    }

    public async Task<ProjectDetailsDto?> GetByIdWithDetailsAsync(int id)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            var query = new StringBuilder();
            query.AppendLine("SELECT TOP 1                                      ")
                 .AppendLine("  P.Id, P.Title, P.Description, P.StartedAt,      ")
                 .AppendLine("  P.FinishedAt, P.TotalCost, P.CreatedAt,         ")
                 .AppendLine("  U.Name AS ClientName, F.Name AS FreelancerName  ")
                 .AppendLine("FROM Projects P                                   ")
                 .AppendLine("INNER JOIN Users U                                ")
                 .AppendLine("ON P.ClientId = U.Id                              ")
                 .AppendLine("INNER JOIN Users F                                ")
                 .AppendLine("ON P.FreelancerId = F.Id                          ")
                 .AppendLine("WHERE P.Id = @Id                                  ");

            var project = await sqlConnection.QueryFirstOrDefaultAsync<ProjectDetailsDto?>(query.ToString(), new { Id = id });

            return project;
        }
    }

    public void Create(Project project)
    {
        _context.Projects.Add(project);
    }

    public void Update(Project project)
    {
        _context.Projects.Update(project);
    }

    public void Delete(Project project)
    {
        _context.Projects.Remove(project);
    }

    public void CreateComment(ProjectComment comment)
    {
        _context.ProjectComments.Add(comment);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}