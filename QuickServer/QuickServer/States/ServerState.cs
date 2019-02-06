using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    public abstract class ServerState
    {
        public ServerState(Control control, RequestServer requestServer)
        {
            Control = control;
            RequestServer = requestServer;
        }

        public Control Control { get; set; }

        public RequestServer RequestServer { get; set; }

        public abstract string Status { get; }

        public abstract string Button { get; }

        public abstract bool ButtonEnabled { get; }

        public abstract void ChangeServerState();

    }
}
