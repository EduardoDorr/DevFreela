using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Models.InputModels;

namespace DevFreela.Application.Services.Interfaces;

public interface ISkillService
{
    List<SkillViewModel> GetAll(int skip = 0, int take  = 50);
    SkillViewModel? GetById(int id);
    int Create(CreateSkillInputModel inputModel);
    void Update(UpdateSkillInputModel inputModel);
}