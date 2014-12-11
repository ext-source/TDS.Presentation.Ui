using System;
using System.Collections.Generic;

namespace TDS.Presentation.Ui.Models
{
    public class DeliveryViewModel
    {
        public int DeliveryEntityId
        {
            get;
            set;
        }

        public int ProductEntityId
        {
            get;
            set;
        }

        public int ProviderEntityId
        {
            get;
            set;
        }

        public DateTime UpdateDate
        {
            get;
            set;
        }

        public int Count
        {
            get;
            set;
        }

        public int Cost
        {
            get;
            set;
        }

        public ICollection<ProductViewModel> Products
        {
            get;
            set;
        }

        public ICollection<ProviderViewModel> Providers
        {
            get;
            set;
        }

        public ProductViewModel CurrentProduct
        {
            get;
            set;
        }

        public ProviderViewModel CurrentProvider
        {
            get;
            set;
        }
    }
}