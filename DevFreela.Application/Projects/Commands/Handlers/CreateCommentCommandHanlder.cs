using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Infrastructure.Persistence.Data;
using DevFreela.Application.Projects.Commands;

namespace DevFreela.Application.Projects.Commands.Handlers;

internal sealed class CreateCommentCommandHanlder : IRequestHandler<CreateCommentCommand, Unit>
{
    private readonly DevFreelaDbContext _context;

    public CreateCommentCommandHanlder(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(request.Content, request.ProjectId, request.UserId);

        _context.ProjectComments.Add(comment);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}