using MediatR;
using DevFreela.Application.Skills.Shared;

namespace DevFreela.Application.Skills.GetSkills;

public sealed class GetSkillsQuery : IRequest<IEnumerable<SkillViewModel>> { }