using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDS.DataAccess.EntityModels
{
    [Table("Delivery")]
    public class DeliveryEntity
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
    }
}
