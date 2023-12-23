namespace DevFreela.Domain.Dtos;

public record ProjectDetailsDto(int Id, string Title, string Description, DateTime? StartedAt, DateTime? FinishedAt,
                                decimal TotalCost, DateTime CreatedAt, string ClientName, string FreelancerName);