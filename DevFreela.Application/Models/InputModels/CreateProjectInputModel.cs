namespace DevFreela.Application.Models.InputModels;

public class CreateProjectInputModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ClientId { get; set; }
    public int FreelancerId { get; set; }
    public decimal TotalCost { get; set; }
}