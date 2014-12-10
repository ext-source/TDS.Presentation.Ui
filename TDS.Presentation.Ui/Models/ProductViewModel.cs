using System;
using System.ComponentModel.DataAnnotations;

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

        public virtual CategoryViewModel Categories
        {
            get;
            set;
        }

        [Required]
        public int CategoryId
        {
            get;
            set;
        }
    }
}