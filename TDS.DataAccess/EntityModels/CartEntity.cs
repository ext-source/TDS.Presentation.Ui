using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDS.DataAccess.EntityModels
{
    [Table("Cart")]
    public class CartEntity
    {
        public int CartEntityId
        {
            get;
            set;
        }

        public string UserIdentity
        {
            get;
            set;
        }

        public virtual ICollection<DeliveryEntity> Deliveries
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