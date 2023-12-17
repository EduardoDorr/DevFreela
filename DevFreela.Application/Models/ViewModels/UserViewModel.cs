namespace DevFreela.Application.Models.ViewModels;

public class UserViewModel
{
    public int Id { get; }
    public string Name { get; }
    public string Email { get; }
    public bool Active { get; }

    public UserViewModel(int id, string name, string email, bool active)
    {
        Id = id;
        Name = name;
        Email = email;
        Active = active;
    }
}