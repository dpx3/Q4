using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class StoppingServerState : ServerState, ServerStatusListener
    {
        public StoppingServerState(Control control, RequestServer requestServer) : base(control, requestServer)
        {
            requestServer.AddServerStatusListener(this);
            
        }
        public override string Button
        {
            get
            {
                return "Stopping Server";
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
                return "Stopping...";
            }
        }

        public override void ChangeServerState()
        {
            
        }

        public void ServerStarted()
        {

        }

        public void ServerStopped()
        {
            Console.WriteLine("Received server stopped.");
            Control.state = new StoppedServerState(Control, RequestServer);
            RequestServer.RemoveServerStatusListener(this);
            Control.view.DispatchServerStatus();
        }
    }
}
