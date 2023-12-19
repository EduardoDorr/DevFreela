using MediatR;
using DevFreela.Application.Skills.Models;

namespace DevFreela.Application.Skills.Queries;

public sealed class GetSkillsQuery : IRequest<IEnumerable<SkillViewModel>> { }