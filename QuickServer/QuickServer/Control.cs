using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QuickServe
{
    public class Control : ResponderLister
    {
        public static int requestCounter = 1;

        RequestServer requestServer = new RequestServer();
        public Data data;
        public View view;
        public ServerState state;

        public Grid[] inputTypes;

        public void Handle()
        {
            requestServer.control = this;
            AddNewResponder();
            state = new RunningServerState(this, requestServer);
            requestServer.StartServer();
        }

        public void MakeInputViews(params Grid[] grids)
        {
            inputTypes = grids;
        }

        public void SwitchTo(int index)
        {
            Console.WriteLine("Switching to " + index);
            foreach (Grid inputType in inputTypes)
            {
                inputType.Visibility = System.Windows.Visibility.Collapsed;
            }
            inputTypes[index].Visibility = System.Windows.Visibility.Visible;
        }

        public void SwitchTo(string header)
        {
            foreach (Responder responder in data.Responders)
            {
                if (responder.Name == header)
                {
                    SwitchTo(responder.responderData.ResponderInputType);
                    responder.responderData.AttachToData(data);
                }
            }
        }

        public void AddNewResponder()
        {
            Responder responder = new Responder("String", "Request " + requestCounter++);
            data.Responders.Add(responder);
        }

        public void ChangeResponseType(string newType)
        {
            if (data == null)
                return;

            Console.WriteLine("Announdcessss");
            data.Responder.SwitchType(newType);
            SwitchTo(data.Responder.responderData.ResponderInputType);
            data.Responder.responderData.AttachToData(data);
        }

        public void RemoveResponder(string header)
        {
            foreach (Responder responder in data.Responders.ToArray())
            {
                if (responder.responderData.ResponderName == header)
                {
                    data.Responders.Remove(responder);
                    break;
                }
            }
        }

        public void CreateResponder()
        {

        }

        public void StartServer ()
        {

        }

        public List<Responder> GetResponders()
        {
            return data.Responders.ToList();
        }

        public void BrowseFile()
        {
            Console.WriteLine("Found path " + data.FilePath.String);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                data.FilePath.String = openFileDialog.FileName;
            }
            Console.WriteLine("Set path to " + data.FilePath.String);

        }

        public void AddParameter()
        {
            Console.WriteLine("Added parameter");
            data.Parameters.Add(new Parameter("Name", true, "Boolean"));
        }

        public void RemoveParameter(int index)
        {
            if (index >= 0 & index < data.Parameters.Count)
            data.Parameters.RemoveAt(index);
        }

        public void StopServer()
        {
            requestServer.StopServer();
        }

    }
    public interface View
    {
        void UpdateServerStatus();

        void DispatchServerStatus();
    }
}
