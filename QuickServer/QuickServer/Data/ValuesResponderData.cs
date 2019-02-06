using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class ValuesResponderData : ResponderData
    {
        public ObservableCollection<Parameter> Parameters { get; set; } = new ObservableCollection<Parameter>();

        public ValuesResponderData()
        {
            ResponderInputType = 3;
        }
        
        public override void AttachToData(Data data)
        {
            data.Parameters = Parameters;
        }
    }
}
