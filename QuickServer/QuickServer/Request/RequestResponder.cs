using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickServe
{
    public abstract class RequestResponder
    {
        public RequestData requestData = new RequestData();
        public ResponderData responderData;
        

        public bool handleRequest(HttpProcessor processor)
        {
            bool handled = requestData.Matches(processor);
            if (!handled)
                return false;

            if (requestData.HasRequestMethod("GET"))
            {
                handleGETRequest(processor);
            } else if (requestData.HasRequestMethod("POST"))
            {
                handlePOSTRequest(processor, processor.postStream);
            }
            processor.socket.Close();
            return true;
        }

        protected abstract void handleGETRequest(HttpProcessor p);
        protected abstract void handlePOSTRequest(HttpProcessor p, StreamReader inputData);
    }
}
