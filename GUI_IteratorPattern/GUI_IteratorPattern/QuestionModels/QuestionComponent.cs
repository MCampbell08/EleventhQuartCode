using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI_IteratorPattern
{
    public abstract class QuestionComponent
    {
        public void Print(TextBlock textBlock)
        {
            IEnumerator<QuestionComponent> enumerator = CreateIterator();
            while (enumerator.MoveNext())
            {
                if(enumerator.Current is QuestionItem)
                    textBlock.Text += enumerator.Current.ToString() + "\n";
                enumerator.Current.Print(textBlock);
            }
        }
        public abstract IEnumerator<QuestionComponent> CreateIterator();
    }
}
