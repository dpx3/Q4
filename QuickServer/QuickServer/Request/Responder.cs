using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    public class Responder
    {

        public RequestResponder requestResponder;
        public ResponderData responderData;

        ResponderDataFactory responderDataFactory = new ResponderDataFactory();
        RequestResponderFactory requestResponderFactory = new RequestResponderFactory();

        public string Name
        {
            get
            {
                return responderData.ResponderName;
            }
            set
            {
                responderData.ResponderName = value;
            }
        } 

        public Responder(string newType, string name)
        {
            requestResponder = requestResponderFactory.GetResponder(newType);
            responderData = responderDataFactory.GetResponderData(newType);
            requestResponder.responderData = responderData;
            responderData.ResponderName = name;
        }

        public void SwitchType(string newType)
        {
            RequestData requestData = requestResponder.requestData;
            requestResponder = requestResponderFactory.GetResponder(newType);
            responderData = responderDataFactory.GetResponderData(newType);
            requestResponder.responderData = responderData;
            requestResponder.requestData = requestData;

        }

    }
}
