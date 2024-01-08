﻿using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Projects.CreateComment;

internal sealed class CreateCommentCommandHanlder : IRequestHandler<CreateCommentCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCommentCommandHanlder(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(request.Content, request.ProjectId, request.UserId);

        _unitOfWork.Projects.CreateComment(comment);

        await _unitOfWork.CompleteAsync();

        return Unit.Value;
    }
}