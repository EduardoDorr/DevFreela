using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Skills.CreateSkill;

internal sealed class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSkillCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = new Skill(request.Description);

        _unitOfWork.Skills.Create(skill);

        await _unitOfWork.SaveChangesAsync();

        return skill.Id;
    }
}