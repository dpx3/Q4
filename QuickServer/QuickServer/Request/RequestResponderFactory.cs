using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class RequestResponderFactory
    {

        public RequestResponder GetResponder(string responderType)
        {
            RequestResponder output;
            switch (responderType.ToLower())
            {
                case "none":
                    output = new NoRequestResponder();
                    break;
                case "string":
                    output = new StringRequestResponder();
                    break;
                case "file":
                    output = new FileRequestResponder();
                    break;
                case "values":
                    output = new ValuesRequestResponder();
                    break;


                case "icon":
                    output = new IconRequestResponder();
                    break;
                default:
                    output = null;
                    break;
            }
            return output;
        }

    }
}
