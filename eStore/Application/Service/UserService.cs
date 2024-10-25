using Application.IService;
using Application.ViewsModel;
using AutoMapper;
using Domain.Entities;
using eStore.Infrastructure.Persistence.Entities;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Service
{
    public class UserService : IEUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<ResponseResult> ChangeStatus(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseResult> Create(UserCreateVModel model)
        {
            var responseResult = new ResponseResult();
            try
            {
                // Kiểm tra đầu vào hợp lệ
                if (model == null)
                {
                    responseResult.Success = false;
                    responseResult.Message = "User model cannot be null.";
                    return responseResult;
                }

                var userEntity = _mapper.Map<EUser>(model);
                var createResult = await _userRepository.Create(userEntity);

                if (createResult.Success)
                {
                    responseResult.Success = true;
                    responseResult.Data = createResult.Data; // Bạn có thể muốn trả về ID hoặc thông tin người dùng
                }
                else
                {
                    responseResult.Success = false;
                    responseResult.Message = createResult.Message; // Lý do cụ thể tại sao không tạo được
                }
            }
            catch (Exception ex)
            {
                responseResult.Success = false;
                responseResult.Message = $"An error occurred: {ex.Message}"; // Ghi lại lỗi để theo dõi
            }
            return responseResult;
        }



        public Task<ResponseResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> Update(UserUpdateVModel model)
        {
            throw new NotImplementedException();
        }
    }
}
