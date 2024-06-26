﻿using AutoMapper;
using MyProject.DataAccess.Entities;
using MyProject.DataAccess.ViewModels.Roles.Queries.GetRoles;
using MyProject.DataAccess.ViewModels.Users.Commands.CreateUser;
using MyProject.DataAccess.ViewModels.Users.Commands.DeleteUser;
using MyProject.DataAccess.ViewModels.Users.Commands.UpdateUser;
using MyProject.DataAccess.ViewModels.Users.Queries.GetUser;
using MyProject.DataAccess.ViewModels.Users.Queries.GetUsers;

namespace MyProject.Application.ExtentionMethods;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region User
        CreateMap<GetUsersRequest, User>().ReverseMap();
        CreateMap<GetUsersResponse, User>().ReverseMap();

        CreateMap<CreateUserRequest,User>().ReverseMap();

        CreateMap<GetUserByIdRequest,User>().ReverseMap();
        CreateMap<GetUserByIdResponse,User>().ReverseMap();

        CreateMap<UpdateUserRequest, User>().ReverseMap();

        CreateMap<DeleteUserRequest,User>().ReverseMap();
        #endregion

        #region Role

        CreateMap<GetRolesResponse, Role>().ReverseMap();

        #endregion

    }

}
