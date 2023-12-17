using DevFreela.Domain.Entities;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Models.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence.Data;

namespace DevFreela.Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly DevFreelaDbContext _context;

    public UserService(DevFreelaDbContext context)
    {
        _context = context;
    }

    public List<UserViewModel> GetAll(int skip = 0, int take = 50)
    {
        var users = _context.Users.Skip(skip).Take(take).ToList();

        var viewModels = users.Select(u => new UserViewModel(u.Id, u.Name, u.Email, u.Active))
                              .ToList();

        return viewModels;
    }

    public UserViewModel? GetById(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        if (user is null)
            return null;

        var viewModel = new UserViewModel(user.Id, user.Name, user.Email, user.Active);

        return viewModel;
    }    

    public int Create(CreateUserInputModel inputModel)
    {
        var user = new User(inputModel.Name, inputModel.Email, inputModel.BirthDate);

        _context.Users.Add(user);
        _context.SaveChanges();

        return user.Id;
    }

    public void Update(UpdateUserInputModel inputModel)
    {
        var userToUpdate = _context.Users.FirstOrDefault(x => x.Id == inputModel.Id);

        if (userToUpdate is null)
            return;

        userToUpdate.Update(inputModel.Name, inputModel.Email, inputModel.BirthDate, inputModel.Active);

        _context.Users.Update(userToUpdate);
        _context.SaveChanges();
    }

    public void Activate(int id)
    {
        var userToActivate = _context.Users.FirstOrDefault(x => x.Id == id);

        if (userToActivate is null)
            return;

        userToActivate.Activate();

        _context.Users.Update(userToActivate);
        _context.SaveChanges();
    }

    public void Deactivate(int id)
    {
        var userToDeactivate = _context.Users.FirstOrDefault(x => x.Id == id);

        if (userToDeactivate is null)
            return;

        userToDeactivate.Deactivate();

        _context.Users.Update(userToDeactivate);
        _context.SaveChanges();
    }

    public void AddSkill(int userId, int skillId)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == userId);

        if (user is null)
            return;

        var skill = _context.Skills.FirstOrDefault(x => x.Id == skillId);

        if (skill is null)
            return;

        user.AddSkill(new UserSkill(userId, skillId));

        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void RemoveSkill(int userId, int skillId)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == userId);

        if (user is null)
            return;

        var skill = _context.Skills.FirstOrDefault(x => x.Id == skillId);

        if (skill is null)
            return;

        user.RemoveSkill(new UserSkill(userId, skillId));

        _context.Users.Update(user);
        _context.SaveChanges();
    }
}