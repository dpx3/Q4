using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QuickServe
{
    public class ParameterNameTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextBoxTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Parameter parameter = item as Parameter;
            return TextBoxTemplate;
        }
    }
}
