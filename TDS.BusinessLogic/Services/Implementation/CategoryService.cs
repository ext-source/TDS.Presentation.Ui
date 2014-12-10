using Ninject;

using TDS.Business.Services.Interface;
using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Implementation
{
    public class CategoryService : BaseService<CategoryEntity>, ICategoryService<CategoryEntity>
    {
        public CategoryService(IKernel kernel) 
            : base(kernel)
        {
        }
    }
}