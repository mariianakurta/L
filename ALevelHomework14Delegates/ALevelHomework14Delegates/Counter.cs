using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework14Delegates
{
    public class Counter
    {
        public event EventHandler<MyEventArgs> CalsulationsResult;

        public void Count(int x, int y, MainDelegate totalCount)
        {
            try
            {
                int result = totalCount(x, y);
                CorrectOrException($"Result: {result}");
            }
            catch (Exception exception)
            {
                CorrectOrException($"Exception: {exception.Message}");
            }
        }

        void CorrectOrException(string message)
        {
            CalsulationsResult?.Invoke(this, new MyEventArgs(message));
        }
    }
}
