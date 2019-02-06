using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class FileResponderData : ResponderData
    {
        public MutableString FilePath { get; set; } = new MutableString();

        public FileResponderData()
        {
            ResponderInputType = 2;
        }

        public override void AttachToData(Data data)
        {
            data.FilePath = FilePath;
        }
    }
}
