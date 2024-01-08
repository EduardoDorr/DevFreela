using MediatR;
using DevFreela.Domain.Repositories;
using DevFreela.Application.Users.Shared;

namespace DevFreela.Application.Users.GetUser;

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