using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IBaseService<TEntity, TCreateVModel, TUpdateVModel, TGetByIdVModel, TGetAllVModel> where TEntity : BaseEntity
    {
        Task<ResponseResult> GetAll();
        Task<ResponseResult> GetById(int id);
        Task<ResponseResult> Create(TCreateVModel model);
        Task<ResponseResult> Update(TUpdateVModel model);
        Task<ResponseResult> ChangeStatus(long id);
        Task<ResponseResult> Remove(long id);
    }
}
