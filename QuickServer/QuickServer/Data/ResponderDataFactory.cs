using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class ResponderDataFactory
    {
        
        NoResponderData noResponderData;
        StringResponderData stringResponderData;
        FileResponderData fileResponderData;
        ValuesResponderData valuesResponderData;

        public ResponderData GetResponderData(string inputType)
        {
            ResponderData output;
            switch (inputType.ToLower())
            {
                case "none":
                    if (noResponderData == null)
                        noResponderData = new NoResponderData();
                    output = noResponderData;
                    break;
                case "string":
                    if (stringResponderData == null)
                        stringResponderData = new StringResponderData();
                    output = stringResponderData;
                    break;
                case "file":
                    if (fileResponderData == null)
                        fileResponderData = new FileResponderData();
                    output = fileResponderData;
                    break;
                case "values":
                    if (valuesResponderData == null)
                        valuesResponderData = new ValuesResponderData();
                    output = valuesResponderData;
                    break;
                default:
                    output = new NoResponderData();
                    break;
            }
            return output;
        }

    }
}
