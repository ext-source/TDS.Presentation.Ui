using System;
using System.Data.Entity;

namespace TDS.DataAccess.Implementation
{
    public class ContextAdapter<TObject> : IContextAdapter<TObject>
        where TObject : DbContext
    {
        private readonly TObject context;

        public ContextAdapter(TObject context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.context = context;
        }

        public TObject Context
        {
            get
            {
                return context;
            }
        }
    }
}