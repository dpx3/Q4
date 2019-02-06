using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe
{
    class Address
    {

        static Address address;

        public static Address Instance
        {
            get
            {
                if (address == null)
                    address = new Address();
                return address;
            }

            set
            {
                address = value;
            }
        }

        public int Port { get; set; } = 80;

    }
}
