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

        [Required]
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

        [Required]
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

        public int DeliveryId
        {
            get;
            set;
        }

        public int Cost
        {
            get;
            set;
        }

        public bool IsExists
        {
            get;
            set;
        }

        public ProviderViewModel Provider
        {
            get;
            set;
        }
    }
}