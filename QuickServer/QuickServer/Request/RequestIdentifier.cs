using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    public interface RequestIdentifier
    {

        string GetUrl();
        string GetMethod();
        Hashtable GetHeaders();
        StreamReader GetPostValues();

    }
}
