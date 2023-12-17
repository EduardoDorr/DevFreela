namespace DevFreela.Application.Models.ViewModels;

public class SkillViewModel
{
    public int Id { get; }
    public string Description { get; }

    public SkillViewModel(int id, string description)
    {
        Id = id;
        Description = description;
    }
}