using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class DirectoryRequestResponder : RequestResponder
    {
        public DirectoryRequestResponder()
        {
            requestData = new DirectoryRequestData();
        }

        protected override void handleGETRequest(HttpProcessor p)
        {
            string url = ((DirectoryResponderData)responderData).DirectoryPath.String + ((DirectoryRequestData)requestData).GetLocalUrl(p.GetUrl());
            Console.WriteLine("Directory server returning " + url);
            if (File.Exists(url)) {
                Stream fs = File.Open(url, FileMode.Open, FileAccess.Read);
                string mimetype;
                if (!url.Contains('.'))
                    mimetype = InputTypes.GetMimeType(null);
                else
                    mimetype = InputTypes.GetMimeType(url.Substring(url.IndexOf('.')));
                p.writeSuccess(mimetype);
                fs.CopyTo(p.outputStream.BaseStream);
                fs.Close();
                p.outputStream.BaseStream.Flush();
            } else if (url.EndsWith("favicon.ico"))
            {
                Stream fs = File.Open("q.ico", FileMode.Open, FileAccess.Read);
                p.writeSuccess("image/x-icon");
                fs.CopyTo(p.outputStream.BaseStream);
                fs.Close();
                p.outputStream.BaseStream.Flush();
            } else
            {
                p.writeSuccess();
                Console.WriteLine("Sent 404");
                p.outputStream.Write("Nooo");
            }
            p.outputStream.Flush();
            p.outputStream = null;

        }

        protected override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            handleGETRequest(p);
        }

        public override void SetRequestData(RequestData newRequestData)
        {
            requestData = new DirectoryRequestData(newRequestData);
        }
    }
}
