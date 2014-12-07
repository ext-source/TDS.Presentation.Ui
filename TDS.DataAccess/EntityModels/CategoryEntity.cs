using System.ComponentModel.DataAnnotations.Schema;

namespace TDS.DataAccess.EntityModels
{
    [Table("Category")]
    public class CategoryEntity
    {
        public int CategoryEntityId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}