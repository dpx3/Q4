using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuickServe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, View
    {
        public Control control = new Control();
        public Data data = new Data();
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = data;
            control.data = data;
            control.Handle();
            BuildWindow();
            control.SwitchTo(data.Responders[0].Name);
            AttachData();
            control.view = this;
        }

        public void BuildWindow()
        {
            control.MakeInputViews(NoInputType, StringInputType, FileInputType, ParameterInputType);
        }

        public void AttachData()
        {
            urlInput.DataContext = data.Responder.requestResponder.requestData;
            methodInput.DataContext = data.Responder.requestResponder.requestData;
            stringInput.DataContext = data.String;
            responseTypeInput.DataContext = data.Responder.responderData;
            filePath.DataContext = data.FilePath;
            ParameterList.DataContext = null;
            ParameterList.DataContext = data;
            serverStatus.DataContext = control.state;
            serverButton.DataContext = control.state;
        }

        private void addResponderClick(object sender, RoutedEventArgs e)
        {
            control.AddNewResponder();
            tabControl.SelectedIndex = control.data.Responders.Count - 1;
        }

        private void changeResponse(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
                return;

            control.ChangeResponseType(((ComboBoxItem)e.AddedItems[0]).Content.ToString());

            if (e.RemovedItems.Count > 0 && ((ComboBoxItem)e.AddedItems[0]).Content != ((ComboBoxItem)e.RemovedItems[0]).Content)
            {
                AttachData();
            }
        }

        private void changeTab(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
                return;

            if (data.String != null)
               Console.WriteLine("String of " + data.String.GetHashCode() + " with value " + data.String.String);

            Console.WriteLine("Responder was " + data.Responder.GetHashCode());
            control.SwitchTo(((Responder)e.AddedItems[0]).Name);
            AttachData();
        }

        private void changeMethod(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
                return;
        }

        private void schangeServerStatus(object sender, RoutedEventArgs e)
        {

            control.state.ChangeServerState();
            UpdateServerStatus();

        }

        public delegate void UpdateServer();

        public void UpdateServerStatus()
        {
            serverStatus.DataContext = null;
            serverStatus.DataContext = control.state;
            serverButton.DataContext = null;
            serverButton.DataContext = control.state;
        }
        
        public void DispatchServerStatus()
        {
            Dispatcher.Invoke(new UpdateServer(UpdateServerStatus));
        }

        private void browseFile(object sender, RoutedEventArgs e)
        {
            control.BrowseFile();
            filePath.DataContext = null;
            filePath.DataContext = data.FilePath;
        }

        private void addParameter(object sender, RoutedEventArgs e)
        {
            control.AddParameter();
            ParameterList.DataContext = null;
            ParameterList.DataContext = data;
        }

        private void removeParameter(object sender, RoutedEventArgs e)
        {
            control.RemoveParameter(ParameterList.SelectedIndex);
        }

        private void changeType(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0 && ((ComboBoxItem)e.AddedItems[0]).Content != ((ComboBoxItem)e.RemovedItems[0]).Content)
            {
                ParameterList.DataContext = null;
                ParameterList.DataContext = data;
            }
        }

        private void closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            control.StopServer();
        }
    }


}
