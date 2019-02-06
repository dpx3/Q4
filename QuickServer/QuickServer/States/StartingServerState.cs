using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class StartingServerState : ServerState, ServerStatusListener
    {
        public StartingServerState(Control control, RequestServer requestServer) : base(control, requestServer)
        {
            requestServer.AddServerStatusListener(this);
        }

        public override string Button
        {
            get
            {
                return "Starting Server";
            }
        }

        public override bool ButtonEnabled
        {
            get
            {
                return false;
            }
        }

        public override string Status
        {
            get
            {
                return "Starting...";
            }
        }

        public override void ChangeServerState()
        {
            
        }

        public void ServerStarted()
        {
            Control.state = new RunningServerState(Control, RequestServer);
            RequestServer.RemoveServerStatusListener(this);
            Control.view.DispatchServerStatus();
        }

        public void ServerStopped()
        {

        }
    }
}
