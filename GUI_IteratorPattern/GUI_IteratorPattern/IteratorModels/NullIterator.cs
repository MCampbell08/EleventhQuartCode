using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_IteratorPattern
{
    public class NullIterator<T> : IEnumerator<T>
    {
        public T Current => default(T);

        object IEnumerator.Current => null;

        public void Dispose()
        {
            //Do nothing cause null
        }

        public bool MoveNext()
        {
            return false;
        }

        public void Reset()
        {
            //Do nothing cause null
        }
    }
}
