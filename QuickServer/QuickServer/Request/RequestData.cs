using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    public class RequestData
    {
        public int MethodIndex
        {
            get
            {
                return new List<string>(InputTypes.Methods).IndexOf(Method);
            }

            set
            {
                Method = InputTypes.Methods[value];
            }
        }

        public string Method { get; set; } = "ANY";

        string url = "";
        public string SubURL
        {
            get
            {
                return url;
            }

            set
            {
                string newValue = value;
                if (newValue.Length > 0 && newValue[0] != '/')
                    newValue = "/" + newValue;
                url = newValue;
            }
        }

        public bool HasRequestMethod(string method)
        {
            return (method.ToLower() == Method.ToLower()) || Method.ToLower() == "any";
        }

        public bool HasSubUrl(string url)
        {
            return (SubURL.ToLower() == url.ToLower()) || SubURL.ToLower() == "";
        }

        public bool Matches(RequestIdentifier identifier)
        {
            Console.WriteLine(identifier.GetMethod() + " " + Method + " " + identifier.GetUrl() + " " + SubURL);
            return HasRequestMethod(identifier.GetMethod()) && HasSubUrl(identifier.GetUrl());
        }

    }
}
