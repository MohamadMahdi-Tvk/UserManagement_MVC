using AutoMapper;
using MediatR;
using MyProject.DataAccess.Entities;
using MyProject.DataAccess.UnitOfWork;
using MyProject.DataAccess.ViewModels.Users.Queries.GetUsers;

namespace MyProject.Application.Services.Users.Queries;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<GetUsersResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetUsersResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var usersList = await _unitOfWork.UserRepository.GetUsers();


            var usersMapped = _mapper.Map<IEnumerable<User>, IEnumerable<GetUsersResponse>>(usersList);

            return usersMapped;

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

