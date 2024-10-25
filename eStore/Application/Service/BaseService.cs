using Application.Helpers;
using Application.ViewsModel;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Repository;
using OA.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class BaseService<TEntity, TCreateVModel, TUpdateVModel, TGetByIdVModel, TGetAllVModel>
        where TEntity : BaseEntity
        where TGetByIdVModel : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public virtual async Task<ResponseResult> GetAll()
        {
            var result = new ResponseResult();
            try
            {
                var entities = await _repository.GetAll();
                result.Data = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TGetAllVModel>>((IEnumerable<TEntity>)entities);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = Utilities.MakeExceptionMessage(ex);
                result.Success = false;
            }
            return result;
        }


        public virtual async Task<ResponseResult> GetById(long id)
        {
            var result = new ResponseResult();
            try
            {
                var entity = await _repository.GetById(id);
                if (entity != null)
                {
                    GetByIdEntry(entity);
                    result.Data = _mapper.Map<TEntity, TGetByIdVModel>(entity);
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.Message = MsgConstants.WarningMessages.NotFoundData;
                };
            }
            catch (Exception ex)
            {
                var message = Utilities.MakeExceptionMessage(ex);
                result.Message = message;
                result.Success = false;
            }
            return result;
        }
        public virtual async Task<ResponseResult> Create(TCreateVModel model)
        {
            var result = new ResponseResult();
            try
            {
                var entityCreated = _mapper.Map<TCreateVModel, TEntity>(model);
                result = await _repository.Create(entityCreated);
                result.Data = _mapper.Map<TEntity, TGetByIdVModel>(result.Data);
            }
            catch (Exception ex)
            {
                var message = Utilities.MakeExceptionMessage(ex);
                result.Message = message;
                result.Success = false;
            }
            return result;
        }
        public virtual async Task<ResponseResult> Update(TUpdateVModel model)
        {
            var result = new ResponseResult();
            try
            {
                var entity = await _repository.GetById(((dynamic)model).Id);
                if (entity != null)
                {
                    entity = _mapper.Map(model, entity);
                    result = await _repository.Update(entity);
                }
                else
                {
                    result.Success = false;
                    result.Message = MsgConstants.WarningMessages.NotFoundData;
                }
            }
            catch (Exception ex)
            {
                var message = Utilities.MakeExceptionMessage(ex);
                result.Message = message;
                result.Success = false;
            }
            return result;
        }
        public virtual async Task<ResponseResult> UpdateMany(IEnumerable<TUpdateVModel> models)
        {
            var result = new ResponseResult();
            try
            {
                foreach (var model in models)
                {
                    var entity = await _repository.GetById(((dynamic)model).Id);
                    entity = _mapper.Map(model, entity);
                    result = await _repository.Update(entity);
                }
            }
            catch (Exception ex)
            {
                var message = Utilities.MakeExceptionMessage(ex);
                result.Message = message;
                result.Success = false;
            }
            return result;
        }
        public virtual async Task<ResponseResult> ChangeStatus(long id)
        {
            var result = new ResponseResult();
            try
            {
                var items = await _repository.GetById(id);
                if (items != null)
                {
                    result = await _repository.Update(items);
                }
                else
                {
                    result.Success = false;
                    result.Message = MsgConstants.WarningMessages.NotFoundData;
                }
            }
            catch (Exception ex)
            {
                var message = Utilities.MakeExceptionMessage(ex);
                result.Message = message;
                result.Success = false;
            }
            return result;
        }

        public virtual async Task<ResponseResult> Remove(long id)
        {
            var result = new ResponseResult();
            try
            {
                TEntity entity = await _repository.GetById(id);
                if (entity != null)
                {
                    result = await _repository.Remove(entity.Id);
                }
                else
                {
                    result.Success = false;
                    result.Message = MsgConstants.WarningMessages.NotFoundData;
                }
            }
            catch (Exception ex)
            {
                var message = Utilities.MakeExceptionMessage(ex);
                result.Message = message;
                result.Success = false;
            }
            return result;
        }
        public virtual void GetAllEntry(TEntity entity)
        {
            //_repository.EntryReference(entity, x => x.LanguageId);
            // override this function in child class if needed
        }
        public virtual void GetByIdEntry(TEntity entity)
        {
            //_repository.EntryReference(entity, x => x.LanguageId);
            // override this function in child class if needed
        }
    }
}
