using Microsoft.AspNet.Identity;

using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Interface
{
    public interface IAccountService
    {
        UserManager<UserProfileEntity> UserManager
        {
            get;
        }
    }
}