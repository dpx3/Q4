using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class StringRequestResponder : RequestResponder
    {

        protected override void handleGETRequest(HttpProcessor p)
        {
            p.writeSuccess();
            Console.WriteLine("Sent " + ((StringResponderData)responderData).String.String);
            p.outputStream.Write(((StringResponderData)responderData).String.String);
            p.outputStream.Flush();
            p.outputStream = null;
        }

        protected override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            handleGETRequest(p);
        }
        
    }
}
