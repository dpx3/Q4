using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class FileRequestResponder : RequestResponder
    {

        protected override void handleGETRequest(HttpProcessor p)
        {
            string url = ((FileResponderData)responderData).FilePath.String;
            Stream fs = File.Open(url, FileMode.Open);
            string mimetype;
            if (!url.Contains('.'))
                mimetype = InputTypes.GetMimeType(null);
            else
                mimetype = InputTypes.GetMimeType(url.Substring(url.IndexOf('.')));
            p.writeSuccess(mimetype);
            fs.CopyTo(p.outputStream.BaseStream);
            fs.Close();
            p.outputStream.BaseStream.Flush();
            p.outputStream.Flush();
            p.outputStream = null;
        }

        protected override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            handleGETRequest(p);
        }
    }
}
