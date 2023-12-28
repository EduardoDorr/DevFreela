namespace DevFreela.Application.Projects.Models;


public record ProjectDetailsViewModel(int Id, string Title, string Description, DateTime? StartedAt, DateTime? FinishedAt,
                                      decimal TotalCost, DateTime CreatedAt, string ClientName, string FreelancerName);