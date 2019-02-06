using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickServe
{
    public class RequestServer
    {
        TcpListener listener;
        HttpProcessor requestIdentifier;
        public Control control;

        List<Responder> failsafeHandlers = new List<Responder>();
        List<ServerStatusListener> serverStatusListeners = new List<ServerStatusListener>();

        public RequestServer()
        {
            failsafeHandlers.Add(new Responder("icon", "Quickserve Icon"));
            failsafeHandlers.Add(new Responder("None", "Full failsafe"));
        }

        public void listen()
        {
            listener = new TcpListener(Address.Instance.Port);
            while (true)
            {
                try
                {
                    listener.Start();
                    Thread.Sleep(200);
                    Console.WriteLine("Listening");
                    NotifyServerStarted();
                    TcpClient client = listener.AcceptTcpClient();
                    HttpProcessor processor = new HttpProcessor(client);
                    processor.process();
                    requestIdentifier = processor;
                    Console.WriteLine(requestIdentifier.outputStream == null);
                    Thread thread = new Thread(new ThreadStart(handleRequest));
                    thread.Start();
                    Thread.Sleep(1);
                } catch (SocketException se)
                {
                    Thread.Sleep(300);
                    NotifyServerStopped();
                    Thread.CurrentThread.Abort();
                }
            }
        }

        public void handleRequest()
        {
            bool handled = false;
            Console.WriteLine("Call to handle request.");
            foreach (Responder responder in control.GetResponders())
            {
                if (responder.requestResponder.handleRequest(requestIdentifier))
                {
                    Console.WriteLine("Request handled by " + responder.GetHashCode());
                    handled = true;
                    break;
                }
            }

            if (!handled)
            {
                foreach (Responder responder in failsafeHandlers)
                {
                    if (responder.requestResponder.handleRequest(requestIdentifier))
                    {
                        Console.WriteLine("Request handled by failsafe " + responder.GetHashCode());
                        break;
                    }
                }
            }
        }

        public void StartServer()
        {
            Thread thread = new Thread(new ThreadStart(listen));
            thread.Start();
        }

        public void StopServer()
        {
            Console.WriteLine("Trying to stop server");
            listener.Stop();
        }

        public void NotifyServerStarted()
        {
            Console.WriteLine("Notifying listeners " + serverStatusListeners.Count);
            foreach (ServerStatusListener listener in serverStatusListeners.ToArray())
                listener.ServerStarted();
        }

        public void NotifyServerStopped()
        {
            Console.WriteLine("Notifying listeners " + serverStatusListeners.Count);
            foreach (ServerStatusListener listener in serverStatusListeners.ToArray())
                listener.ServerStopped();
        }

        public void AddServerStatusListener(ServerStatusListener listener)
        {
            serverStatusListeners.Add(listener);
            Console.WriteLine("Added listener, now " + serverStatusListeners.Count);
        }

        public void RemoveServerStatusListener(ServerStatusListener listener)
        {
            serverStatusListeners.Remove(listener);
            Console.WriteLine("Removed listener, now " + serverStatusListeners.Count);
        }

    }

    public interface ServerStatusListener {

        void ServerStarted();
        void ServerStopped();

    }
}
