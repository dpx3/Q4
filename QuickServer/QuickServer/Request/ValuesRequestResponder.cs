using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace QuickServe
{
    class ValuesRequestResponder : RequestResponder
    {
        string Parse(List<Parameter> parameters)
        {
            string json = "{";
            foreach (Parameter parameter in parameters)
            {
                json += " \"" + parameter.Name + "\" : " + parameter.GetJsonValue() + ",";
            }
            if (json[json.Length - 1] == ',')
                json = json.Substring(0, json.Length - 1);
            json += " }";
            return json;
        }

        protected override void handleGETRequest(HttpProcessor p)
        {
            p.writeSuccess();
            p.outputStream.Write(Parse(((ValuesResponderData)responderData).Parameters.ToList()));
            p.outputStream.Flush();
        }

        protected override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            handleGETRequest(p);
        }
    }
}
