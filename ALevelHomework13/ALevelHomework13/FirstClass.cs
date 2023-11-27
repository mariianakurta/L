using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework13
{
    internal class FirstClass
    {
        public delegate void MainDelegate(bool result);

        public MainDelegate Show { get; set; }

        public int Multiply(int x, int y)
        {
            return x * y;
        }
    }
}
