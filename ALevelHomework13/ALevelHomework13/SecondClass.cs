using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework13
{
    internal class SecondClass
    {
        public delegate bool DelegatesResult(int number);

        public DelegatesResult Result { get; set; }

        public List<bool> ListResult { get; set; } = new List<bool>();

        public DelegatesResult Calc(FirstClass.MainDelegate multiplyDelegate, int x, int y)
        {
            int result = new FirstClass().Multiply(x, y);
            multiplyDelegate?.Invoke(result % x == 0);

            ListResult.Add(result % x == 0);

            Result = (number) => result % number == 0;
            return Result;
        }
    }
}
