using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_IteratorPattern
{
    public class QuestionSection : QuestionComponent
    {
        private List<QuestionComponent> items = new List<QuestionComponent>();
        private string content;

        public QuestionSection(string content)
        {
            Content = content;
        }

        public override string Content { get => content; set => content = value; }
        
        public override List<QuestionComponent> Items { get => items; set => items = value; }

        public override IEnumerator<QuestionComponent> CreateIterator()
        {
            return Items.GetEnumerator();
        }

        public override string ToString()
        {
            return $"{Content}";
        }
    }
}
