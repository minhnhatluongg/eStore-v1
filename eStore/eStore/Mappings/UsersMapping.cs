using Application.ViewsModel;
using AutoMapper;
using eStore.Infrastructure.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class UsersMapping : Profile
    {
        public UsersMapping() 
        {
            CreateMap<UserCreateVModel, EUser>();
            CreateMap<UserUpdateVModel, EUser>();
            CreateMap<EUser, UserGetAllVModel>();
            CreateMap<EUser, UserGetByIdVModel>();
        }
    }
}
