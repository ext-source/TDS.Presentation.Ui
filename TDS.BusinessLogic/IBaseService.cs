using System.Collections.Generic;

namespace TDS.Business
{
    public interface IBaseService<TObject>
        where TObject : class 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ICollection<TObject> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TObject GetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectToUpdate"></param>
        void Update(TObject objectToUpdate);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        TObject Create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectToCreate"></param>
        /// <returns></returns>
        TObject Create(TObject objectToCreate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectToDelete"></param>
        void Delete(TObject objectToDelete);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}