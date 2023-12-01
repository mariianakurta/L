using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework14LINQ
{
    public class MyEventArgs : EventArgs
    {
        public string EventData { get; set; }

        public MyEventArgs(string data)
        {
            EventData = data;
        }
    }
}
