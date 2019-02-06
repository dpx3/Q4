using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    public abstract class ResponderData
    {

        public int ResponderInputType { get; protected set; }

        public string ResponderName { get; set; }

        public abstract void AttachToData(Data data);

    }
}
