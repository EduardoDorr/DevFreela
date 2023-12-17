using DevFreela.Domain.Entities;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Models.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DevFreela.Application.Services.Implementations;

public class SkillService : ISkillService
{
    private readonly DevFreelaDbContext _context;
    private readonly string _connectionString;

    public SkillService(DevFreelaDbContext context, IConfiguration configuration)
    {
        _context = context;
        _connectionString = configuration.GetConnectionString("DevFreela");
    }

    public List<SkillViewModel> GetAll(int skip = 0, int take = 50)
    {
        //var skills = _context.Skills.Skip(skip).Take(take).ToList();

        //var viewModels = skills.Select(s => new SkillViewModel(s.Description))
        //                       .ToList();

        //return viewModels;

        using(var sqlConnection = new SqlConnection(_connectionString))
        {
            var query = "SELECT Id, Description FROM Skills";

            return sqlConnection.Query<SkillViewModel>(query).ToList();
        }
    }

    public SkillViewModel? GetById(int id)
    {
        var skill = _context.Skills.FirstOrDefault(s => s.Id == id);

        if (skill is null)
            return null;

        var viewModel = new SkillViewModel(skill.Id, skill.Description);

        return viewModel;
    }

    public int Create(CreateSkillInputModel inputModel)
    {
        var skill = new Skill(inputModel.Description);

        _context.Skills.Add(skill);
        _context.SaveChanges();

        return skill.Id;
    }    

    public void Update(UpdateSkillInputModel inputModel)
    {
        var skillToUpdate = _context.Skills.FirstOrDefault(s => s.Id == inputModel.Id);

        if (skillToUpdate is null)
            return;

        skillToUpdate.Update(inputModel.Description);

        _context.Skills.Update(skillToUpdate);
        _context.SaveChanges();
    }
}