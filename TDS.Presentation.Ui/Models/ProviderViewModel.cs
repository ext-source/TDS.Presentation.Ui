using System;

namespace TDS.Presentation.Ui.Models
{
    public class ProviderViewModel
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