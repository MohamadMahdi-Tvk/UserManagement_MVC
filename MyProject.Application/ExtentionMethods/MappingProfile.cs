using AutoMapper;
using MyProject.DataAccess.Entities;
using MyProject.DataAccess.ViewModels.Users.Commands.CreateUser;
using MyProject.DataAccess.ViewModels.Users.Queries.GetUser;
using MyProject.DataAccess.ViewModels.Users.Queries.GetUsers;

namespace MyProject.Application.ExtentionMethods;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetUsersRequest, User>().ReverseMap();
        CreateMap<GetUsersResponse, User>().ReverseMap();

        CreateMap<CreateUserRequest,User>().ReverseMap();

        CreateMap<GetUserByIdRequest,User>().ReverseMap();
        CreateMap<GetUserByIdResponse,User>().ReverseMap();


    }

}
