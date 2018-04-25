using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_IteratorPattern.IteratorModels
{
    public class ListIterator<T> : IMyIterator<T>
    {
        private List<T> list;
        private int index = 0;

        public ListIterator(List<T> list)
        {
            this.list = list;
        }

        public T Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (index < list.Count)
            {
                Current = list.ElementAt(index++);
            }
            return false;
        }
    }
}
