using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using Ninject;

using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Implementation
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly UserManager<UserProfileEntity> userManager;  

        public AccountService(IKernel kernel) : base(kernel)
        {
            userManager = new UserManager<UserProfileEntity>(
                new UserStore<UserProfileEntity>(UnitOfWork.ContextAdapter.Context));
        }

        public UserManager<UserProfileEntity> UserManager
        {
            get
            {
                return userManager;
            }
        }
    }
}