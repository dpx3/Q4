using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    public class StoppedServerState : ServerState
    {
        public StoppedServerState(Control control, RequestServer requestServer) : base(control, requestServer) { }
        public override string Button
        {
            get
            {
                return "Start Server";
            }
        }

        public override bool ButtonEnabled
        {
            get
            {
                return true;
            }
        }

        public override string Status
        {
            get
            {
                return "Stopped";
            }
        }

        public override void ChangeServerState()
        {
            Control.state = new StartingServerState(Control, RequestServer);
            RequestServer.StartServer();
        }
    }
}
