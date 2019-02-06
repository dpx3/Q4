using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QuickServe
{
    public class ParameterValueTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CheckBoxTemplate { get; set; }
        public DataTemplate TextBoxTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Parameter parameter = item as Parameter;
            Console.WriteLine("Parameter looking for type " + parameter.Type);
            switch (parameter.Type.ToLower())
            {
                case "string":
                    return TextBoxTemplate;
                case "boolean":
                    return CheckBoxTemplate;
                case "number":
                    return TextBoxTemplate;
                default:
                    return TextBoxTemplate;
            }
        }
    }
}
