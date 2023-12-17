namespace DevFreela.Application.Models.InputModels;

public class CreateUserInputModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
}