using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Models.InputModels;

namespace DevFreela.Application.Services.Interfaces;

public interface IUserService
{
    List<UserViewModel> GetAll(int skip = 0, int take = 50);
    UserViewModel? GetById(int id);
    int Create(CreateUserInputModel inputModel);
    void Update(UpdateUserInputModel inputModel);
    void Deactivate(int id);
    void AddSkill(int userId, int skillId);
    void RemoveSkill(int userId, int skillId);
    void Activate(int id);
}