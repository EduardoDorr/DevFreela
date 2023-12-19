using MediatR;

using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.Skills;

public sealed class GetSkillsQuery : IRequest<IEnumerable<SkillViewModel>> { }