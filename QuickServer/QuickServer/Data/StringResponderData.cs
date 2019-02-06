using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    public class StringResponderData : ResponderData
    {

        public MutableString String { get; set; } = new MutableString();

        public StringResponderData()
        {
            ResponderInputType = 1;
        }

        public override void AttachToData(Data data)
        {
            data.String = String;
        }

    }
}
