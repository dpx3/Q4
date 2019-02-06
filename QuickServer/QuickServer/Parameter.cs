using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    public class Parameter
    {
        public string Name { get; set; }
        public bool BooleanValue { get; set; }
        public string StringValue { get; set; }
        public double NumberValue { get; set; }
        public string Type { get; set; }

        public string TextValue
        {
            get
            {
                if (Type == "Number")
                    return NumberValue.ToString();
                else
                    return StringValue;
            }

            set
            {
                if (Type == "Number")
                {
                    double number;
                    double.TryParse(value, out number);
                    NumberValue = number;
                } else
                {
                    StringValue = value;
                }
            }
        }

        public Parameter(string name, string value, string type)
        {
            Name = name;
            StringValue = value;
            Type = type;
        }

        public Parameter(string name, bool value, string type)
        {
            Name = name;
            BooleanValue = value;
            Type = type;
        }

        public Parameter(string name, double value, string type)
        {
            Name = name;
            NumberValue = value;
            Type = type;
        }

        public string GetJsonValue()
        {
            switch (Type)
            {
                case "String":
                    return "\"" + StringValue.Replace("\"", "\\\"") + "\"";
                case "Number":
                    return NumberValue.ToString();
                case "Boolean":
                    return BooleanValue.ToString();
                default:
                    return "";

            }
        }

    }
}
