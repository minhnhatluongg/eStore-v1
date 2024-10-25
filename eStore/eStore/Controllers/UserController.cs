using Application.IService;
using Application.ViewsModel;
using eStore.Infrastructure.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;
using OA.Core.Constants;
using OA.Domain.Constants;

namespace eStore.Controllers
{
    //[ApiExplorerSettings(GroupName = CommonConstants.Routes.GroupAdmin)]
    [Route(CommonConstants.Routes.BaseRouteAdmin)]
    public class UserController : BaseController<UserController, EUser, UserCreateVModel, UserUpdateVModel, UserGetByIdVModel, UserGetAllVModel>
    {
        private readonly IEUserService _userService;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserController(IEUserService userService, ILogger<UserController> logger, IHttpContextAccessor contextAccessor)
            : base(userService, logger)
        {
            _userService = userService;
            _logger = logger;
            _contextAccessor = contextAccessor;
        }
    }
}
