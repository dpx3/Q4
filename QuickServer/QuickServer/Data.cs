using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    public class Data
    {
        public ObservableCollection<Responder> Responders { get; set; } = new ObservableCollection<Responder>();

        public ObservableCollection<Parameter> Parameters { get; set; } = new ObservableCollection<Parameter>();

        public MutableString FilePath { get; set; }

        public MutableString String { get; set; }
        
        public int Index { get; set; }
        

        public string Method
        {
            get
            {
                if (Responder == null)
                    return null;
                return Responder.requestResponder.requestData.Method;
            }

            set
            {
                Responder.requestResponder.requestData.Method = value;
            }
        }

        public string Url
        {
            get
            {
                if (Responder == null)
                    return null;
                return Responder.requestResponder.requestData.SubURL;
            }

            set
            {
                string newValue = value;
                if (newValue[0] != '/')
                    newValue = "/" + newValue;
                Responder.requestResponder.requestData.SubURL = newValue;
                Console.WriteLine("Set url of " + Responder + " to " + newValue);
            }
        }

        public int Port
        {
            get
            {
                return Address.Instance.Port;
            }

            set
            {
                Address.Instance.Port = value;
            }
        }

        public string IP
        {
            get
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                string output = "";
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        output += ((output == "") ? "" : ",   ") + ip.ToString();
                    }
                }
                if (output == "")
                    return "127.0.0.1";
                else
                    return output;
            }
        }

        public Responder Responder
        {
            get
            {
                if (Responders.Count == 0)
                    return null;
                return Responders[Index];
            }
        }

        public Data()
        {
            Parameters.Add(new Parameter("On/Off", "true", "Boolean"));
            Parameters.Add(new Parameter("Elevation", "100", "String"));
        }
       
    }
}
