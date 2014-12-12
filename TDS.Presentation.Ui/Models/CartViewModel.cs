using System;

namespace TDS.Presentation.Ui.Models
{
    public class CartViewModel
    {
        public int CartEntityId
        {
            get;
            set;
        }

        public string ProductsName
        {
            get;
            set;
        }

        public int Cost
        {
            get;
            set;
        }

        public string DeliveryName
        {
            get;
            set;
        }

        public int Total
        {
            get;
            set;
        }

        public int Count
        {
            get;
            set;
        }

        public DateTime UpdateDate
        {
            get;
            set;
        }
    }
}