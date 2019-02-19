using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class DirectoryRequestData : RequestData
    {
        public DirectoryRequestData() { }
        public DirectoryRequestData(RequestData requestData) : base(requestData) { }

        public override bool HasSubUrl(string url)
        {
            Console.WriteLine(url + " starts with " + SubURL);
            return url.ToLower().StartsWith(SubURL.ToLower());
        }

        public string GetLocalUrl(string url)
        {
            return url.Substring(SubURL.Length);
        }

    }
}
