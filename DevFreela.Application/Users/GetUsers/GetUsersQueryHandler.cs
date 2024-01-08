using MediatR;

using DevFreela.Domain.Repositories;
using DevFreela.Application.Users.Shared;

namespace DevFreela.Application.Users.GetUsers;

internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserViewModel>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();

        var usersViewModel =
            users.Select(u => new UserViewModel(u.Id, u.Name, u.Email, u.Active))
                    .ToList();

        return usersViewModel;
    }
}