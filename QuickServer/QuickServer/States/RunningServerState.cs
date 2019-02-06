using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{ 
    public class RunningServerState : ServerState
    {
        public RunningServerState(Control control, RequestServer requestServer) : base(control, requestServer) { }
        public override string Button
        {
            get
            {
                return "Stop Server";
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
                return "Running";
            }
        }

        public override void ChangeServerState()
        {
            Control.state = new StoppingServerState(Control, RequestServer);
            RequestServer.StopServer();
        }
    }
}
