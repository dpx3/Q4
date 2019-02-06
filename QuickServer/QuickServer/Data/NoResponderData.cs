using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class NoResponderData : ResponderData
    {
        public NoResponderData()
        {
            ResponderInputType = 0;
        }

        public override void AttachToData(Data data)
        {

        }
    }
}
