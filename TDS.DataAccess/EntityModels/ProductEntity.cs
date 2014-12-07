using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDS.DataAccess.EntityModels
{
    [Table("Product")]
    public class ProductEntity
    {
        public int ProductEntityId
        {
            get; 
            set;
        }

        public string Name
        {
            get; 
            set;
        }

        public DateTime UpdateDate
        {
            get;
            set;
        }

        public string ProductInfo
        {
            get;
            set;
        }

        public virtual ICollection<CategoryEntity> Categories
        {
            get;
            set;
        }
    }
}