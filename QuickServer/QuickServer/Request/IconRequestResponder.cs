using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class IconRequestResponder : RequestResponder
    {
        public IconRequestResponder()
        {
            requestData.Method = "GET";
            requestData.SubURL = "/favicon.ico";
        }

        protected override void handleGETRequest(HttpProcessor p)
        {
            Stream fs = File.Open("q.ico", FileMode.Open);
            p.writeSuccess("image/x-icon");
            fs.CopyTo(p.outputStream.BaseStream);
            p.outputStream.BaseStream.Flush();
        }

        protected override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {

        }
    }
}
