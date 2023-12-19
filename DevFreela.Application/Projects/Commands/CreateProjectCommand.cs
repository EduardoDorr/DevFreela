﻿using MediatR;

namespace DevFreela.Application.Projects.Commands;

public sealed class CreateProjectCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ClientId { get; set; }
    public int FreelancerId { get; set; }
    public decimal TotalCost { get; set; }
}