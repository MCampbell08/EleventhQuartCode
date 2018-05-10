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
        public void Print(ListBox sectionBox, ListBox questionBox)
        {
            IEnumerator<QuestionComponent> enumerator = CreateIterator();
            while (enumerator.MoveNext())
            {
                if(enumerator.Current is QuestionItem)
                    questionBox.Items.Add(enumerator.Current.ToString());
                else if (enumerator.Current is QuestionSection)
                    sectionBox.Items.Add(enumerator.Current.ToString());
            }
        }
        public abstract string Content { get; set; }
        public abstract IEnumerator<QuestionComponent> CreateIterator();
        public abstract override string ToString();
        public abstract List<QuestionComponent> Items { get; set; }
    }
}
