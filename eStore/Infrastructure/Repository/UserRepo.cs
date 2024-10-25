using eStore.Infrastructure.Persistence.Context;
using eStore.Infrastructure.Persistence.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepo : BaseRepository<EUser>, IUserRepository
    {
        public UserRepo(ApplicationDbContext dbContext, IHttpContextAccessor contextAccessor) : base(dbContext, contextAccessor)
        {
        }
    }
}
