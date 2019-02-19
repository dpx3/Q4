using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class DirectoryResponderData : ResponderData
    {
        public MutableString DirectoryPath { get; set; } = new MutableString();
        public DirectoryResponderData()
        {
            ResponderInputType = 4;
        }

        public DirectoryResponderData(ResponderData responderData) : base(responderData)
        {
            ResponderInputType = 4;
        }

        public override void AttachToData(Data data)
        {
            data.DirectoryPath = DirectoryPath;
        }
    }
}
