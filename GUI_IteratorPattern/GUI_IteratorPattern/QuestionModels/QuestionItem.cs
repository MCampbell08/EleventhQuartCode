using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_IteratorPattern
{
    public class QuestionItem : QuestionComponent
    {
        private string content;
        private List<QuestionComponent> items;

        public QuestionItem(string content)
        {
            Content = content;
        }

        public override string Content { get => content; set => content = value; }
        public override List<QuestionComponent> Items { get => null; set => items = value; }

        public override IEnumerator<QuestionComponent> CreateIterator() => new NullIterator<QuestionComponent>();
        
        public override string ToString()
        {
            return $"{Content}";
        }
    }
}
