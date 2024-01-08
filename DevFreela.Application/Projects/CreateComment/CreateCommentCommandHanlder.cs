using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Projects.CreateComment;

internal sealed class CreateCommentCommandHanlder : IRequestHandler<CreateCommentCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public CreateCommentCommandHanlder(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(request.Content, request.ProjectId, request.UserId);

        _projectRepository.CreateComment(comment);

        await _projectRepository.SaveChangesAsync();

        return Unit.Value;
    }
}