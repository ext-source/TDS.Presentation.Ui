using System;
using System.Collections.Generic;

namespace TDS.Presentation.Ui.Models
{
    public class ProductViewModel
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

        public DateTime CreateDate
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

        public virtual ICollection<CategoryViewModel> Categories
        {
            get;
            set;
        }
    }
}