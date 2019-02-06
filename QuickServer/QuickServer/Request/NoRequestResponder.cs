using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class NoRequestResponder : RequestResponder
    {

        protected override void handleGETRequest(HttpProcessor p)
        {
            p.writeSuccess();
            p.outputStream.Flush();
        }

        protected override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            handleGETRequest(p);
        }
    }
}
