using MediatR;
using DevFreela.Domain.Repositories;
using DevFreela.Application.Users.Queries;
using DevFreela.Application.Users.Models;

namespace DevFreela.Application.Users.Queries.Handlers;

internal sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel?>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserViewModel?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
            return null;

        var userViewModel =
            new UserViewModel(user.Id, user.Name, user.Email, user.Active);

        return userViewModel;
    }
}