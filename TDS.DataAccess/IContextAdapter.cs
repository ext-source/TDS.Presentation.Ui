namespace TDS.DataAccess
{
    public interface IContextAdapter<out TObject>
    {
        TObject Context
        {
            get;
        } 
    }
}