namespace TDS.Business.Services.Interface
{
    public interface IProductsService<TObject> : IBaseService<TObject>
        where TObject : class
    {
    }
}