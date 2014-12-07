using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDS.DataAccess.EntityModels
{
    [Table("Provider")]
    public class ProviderEntity
    {
        public int ProviderEntityId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public DateTime RegisterDate
        {
            get;
            set;
        }

        public int IndividualNumber
        {
            get;
            set;
        }
    }
}
