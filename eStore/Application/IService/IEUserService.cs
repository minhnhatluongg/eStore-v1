using Application.ViewsModel;
using Domain.Entities;
using eStore.Infrastructure.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IEUserService : IBaseService<EUser, UserCreateVModel, UserUpdateVModel, UserGetByIdVModel, UserGetAllVModel>
    {
        Task<ResponseResult> GetAll();
        Task<ResponseResult> GetById(string id);
        Task<ResponseResult> Create(UserCreateVModel model);
        Task<ResponseResult> Update(UserUpdateVModel model);
        Task<ResponseResult> ChangeStatus(long id);
        Task<ResponseResult> Remove(long id);
    }
}
