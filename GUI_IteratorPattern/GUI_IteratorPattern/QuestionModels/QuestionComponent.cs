using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_IteratorPattern
{
    public abstract class QuestionComponent
    {
        public void Print()
        {
            IEnumerator<QuestionComponent> enumerator = CreateIterator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Print();
            }
        }
        public abstract IEnumerator<QuestionComponent> CreateIterator();
    }
}
