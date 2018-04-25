using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_IteratorPattern
{
    public interface IMyIterator<T>
    {
        bool MoveNext();
        T Current { get; set; }
    }
}
