using Application.IService;
using Application.ViewsModel;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using OA.Core.Constants;
using OA.Domain.Constants;

namespace eStore.Controllers
{
    public abstract class BaseController<TController, TEntity, TCreateVModel, TUpdateVModel, TGetByIdVModel, TGetAllVModel> : ControllerBase
        where TController : ControllerBase
        where TEntity : BaseEntity
    {
        private readonly IBaseService<TEntity, TCreateVModel, TUpdateVModel, TGetByIdVModel, TGetAllVModel> _service;
        private readonly ILogger _logger;
        protected static string _nameController;
        private IEUserService userService;
        private ILogger<UserController> logger;

        protected BaseController(IBaseService<TEntity, TCreateVModel, TUpdateVModel, TGetByIdVModel, TGetAllVModel> service, ILogger<TController> logger)
        {
            _service = service;
            _logger = logger;
            _nameController = GetControllerName(typeof(TController).Name);
        }

        private string GetControllerName(string input)
        {
            return input.Substring(0, input.Length - 10).ToLower();
        }
        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return new ObjectResult(result);
        }
        [HttpGet]
        public virtual async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return new BadRequestObjectResult(string.Format(MsgConstants.Error404Messages.FieldIsInvalid, "Id"));
            }
            var response = await _service.GetById(id);
            var result = new ObjectResult(response);
            if (!response.Success)
            {
                _logger.LogWarning(CommonConstants.LoggingEvents.GetItem, MsgConstants.ErrorMessages.ErrorGetById, _nameController);
            }
            return result;
        }
        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] TCreateVModel model)
        {
            ObjectResult result;
            if (!ModelState.IsValid)
            {
                result = new BadRequestObjectResult(ModelState);
            }
            else
            {
                var response = await _service.Create(model);
                result = new ObjectResult(response);
                if (!response.Success)
                {
                    _logger.LogWarning(CommonConstants.LoggingEvents.CreateItem, MsgConstants.ErrorMessages.ErrorCreate, _nameController);
                }
            }
            return result;
        }
        [HttpPut]
        public virtual async Task<IActionResult> Update([FromBody] TUpdateVModel model)
        {
            ObjectResult result;
            if (!ModelState.IsValid || ((dynamic)model).Id <= 0)
            {
                result = new BadRequestObjectResult(ModelState);
            }
            else
            {
                var response = await _service.Update(model);
                result = new ObjectResult(response);
                if (!response.Success)
                {
                    _logger.LogWarning(CommonConstants.LoggingEvents.UpdateItem, MsgConstants.ErrorMessages.ErrorUpdate, _nameController);
                }
            }
            return result;
        }
        [HttpPut(CommonConstants.Routes.Id)]
        public virtual async Task<IActionResult> ChangeStatus(long id)
        {
            ObjectResult result;
            if (id <= 0)
            {
                return new BadRequestObjectResult(string.Format(MsgConstants.Error404Messages.FieldIsInvalid, "Id"));
            }
            var response = await _service.ChangeStatus(id);
            result = new ObjectResult(response);
            if (!response.Success)
            {
                _logger.LogWarning(CommonConstants.LoggingEvents.UpdateItem, MsgConstants.ErrorMessages.ErrorChangeStatus, _nameController);
            }
            return result;
        }

        [HttpDelete(CommonConstants.Routes.Id)]
        public virtual async Task<IActionResult> Remove(long id)
        {
            if (id <= 0)
            {
                return new BadRequestObjectResult(string.Format(MsgConstants.Error404Messages.FieldIsInvalid, "Id"));
            }
            var response = await _service.Remove(id);
            return new ObjectResult(response);
        }
    }
}
