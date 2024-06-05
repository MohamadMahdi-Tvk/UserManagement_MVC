using AutoMapper;
using MediatR;
using MyProject.DataAccess.Entities;
using MyProject.DataAccess.UnitOfWork;
using MyProject.DataAccess.ViewModels.Users.Queries.GetUser;

namespace MyProject.Application.Services.Users.Queries;

public record GetUserByIdQuery(GetUserByIdRequest Query, CancellationToken CancellationToken) : IRequest<GetUserByIdResponse>;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _unitOfWork.UserRepository.GetUserById(request.Query.Id);

            var userMapped = _mapper.Map<User, GetUserByIdResponse>(user);

            return userMapped;
           
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
