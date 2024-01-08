﻿using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Users.AddSkillToUser;

internal sealed class AddSkillToUserCommandHandler : IRequestHandler<AddSkillToUserCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddSkillToUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AddSkillToUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(request.UserId);

        if (user is null)
            return Unit.Value;

        var skill = await _unitOfWork.Skills.GetByIdAsync(request.SkillId);

        if (skill is null)
            return Unit.Value;

        user.AddSkill(new UserSkill(request.UserId, request.SkillId));

        _unitOfWork.Users.Update(user);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}