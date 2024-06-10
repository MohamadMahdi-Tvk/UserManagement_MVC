using AutoMapper;
using MediatR;
using MyProject.DataAccess.Entities;
using MyProject.DataAccess.UnitOfWork;
using MyProject.DataAccess.ViewModels.Roles.Queries.GetRoles;

namespace MyProject.Application.Services.Roles.Queries;

public record GetRolesQuery(CancellationToken CancellationToken) : IRequest<List<GetRolesResponse>>;

public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<GetRolesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<GetRolesResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var roles = await _unitOfWork.RoleRepository.GetRoles();

            var rolesMapped =  _mapper.Map<List<Role>, List<GetRolesResponse>>(roles);

            return rolesMapped;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
