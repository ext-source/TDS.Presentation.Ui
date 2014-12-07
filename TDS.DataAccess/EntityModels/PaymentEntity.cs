using System.ComponentModel.DataAnnotations.Schema;

namespace TDS.DataAccess.EntityModels
{
    [Table("Payment")]
    public class PaymentEntity
    {
        public int PaymentEntityId
        {
            get;
            set;
        }

        public int PaymentNumber
        {
            get;
            set;
        }

        public string PaymentSystemName
        {
            get;
            set;
        }

        public int ClientEntityId
        {
            get;
            set;
        }
    }
}
