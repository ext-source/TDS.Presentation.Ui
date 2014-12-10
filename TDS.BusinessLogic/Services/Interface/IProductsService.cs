using System.Collections.Generic;

namespace TDS.Business.Services.Interface
{
    public interface IProductsService<TObject> : IBaseService<TObject>
        where TObject : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        ICollection<TObject> Search(string content);
    }
}