using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDS.DataAccess.EntityModels
{
    [Table("Client")]
    public class ClientEntity
    {
        public int ClientEntityId
        {
            get;
            set;
        }

        public int Rating
        {
            get;
            set;
        }

        public virtual CartEntity Cart
        {
            get;
            set;
        }

        public virtual ICollection<PurchaseEntity> Purchases
        {
            get;
            set;
        }
    }
}
