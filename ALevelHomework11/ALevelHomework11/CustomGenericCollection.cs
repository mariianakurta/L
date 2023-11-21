using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework11
{
    class CustomGenericCollection<carParts> : IEnumerable<carParts>
    {
        private carParts[] details;
        private Dictionary<int, carParts> defaultValues = new Dictionary<int, carParts>();

        public CustomGenericCollection(int size)
        {
            details = new carParts[size];
        }

        public int Count()
        {
            return details.Length;
        }

        public void Add(carParts item, int index)
        {
            if (index >= 0 && index < details.Length)
            {
                details[index] = item;
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
        }

        public void Sort()
        {
            Array.Sort(details);
            Console.WriteLine();
            Console.WriteLine("Custom generic collection was sorted.");
        }

        public void SetDefaultAt(int index, carParts defaultValue)
        {
            if (index >= 0 && index < details.Length)
            {
                defaultValues[index] = defaultValue;
                details[index] = defaultValue;
                Console.WriteLine();
                Console.WriteLine($"It is a default value: {index}.");
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
        }

        public IEnumerator<carParts> GetEnumerator()
        {
            return ((IEnumerable<carParts>)details).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
