using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDS.DataAccess.EntityModels
{
    [Table("Purchase")]
    public class PurchaseEntity
    {
        public int PurchaseEntityId
        {
            get;
            set;
        }

        public virtual ICollection<DeliveryEntity> Deliveries
        {
            get;
            set;
        }

        public DateTime CreationDate
        {
            get;
            set;
        }

        public string AdditionalInfo
        {
            get;
            set;
        }

        public int Total
        {
            get;
            set;
        }

        public virtual PaymentEntity Payment
        {
            get;
            set;
        }
    }
}
