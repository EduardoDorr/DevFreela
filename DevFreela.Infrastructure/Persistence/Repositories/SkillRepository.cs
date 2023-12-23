using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using Dapper;

using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;
using DevFreela.Infrastructure.Persistence.Data;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly DevFreelaDbContext _context;
    private readonly string _connectionString;

    public SkillRepository(DevFreelaDbContext context, IConfiguration configuration)
    {
        _context = context;
        _connectionString = configuration.GetConnectionString("DevFreela");
    }

    public async Task<IEnumerable<Skill>> GetAllAsync()
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            var query = "SELECT * FROM Skills";

            var skills = await sqlConnection.QueryAsync<Skill>(query);

            return skills;
        }
    }

    public async Task<Skill?> GetByIdAsync(int id)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            var query = "SELECT TOP 1 * FROM Skills WHERE Id = @Id";

            var skill = await sqlConnection.QueryFirstOrDefaultAsync<Skill>(query, new { Id = id });

            return skill;
        }
    }

    public void Create(Skill skill)
    {
        _context.Skills.Add(skill);
    }

    public void Update(Skill skill)
    {
        _context.Skills.Update(skill);
    }

    public void Delete(Skill skill)
    {
        _context.Skills.Remove(skill);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}