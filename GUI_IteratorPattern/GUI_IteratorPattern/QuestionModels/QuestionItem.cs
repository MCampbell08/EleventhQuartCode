using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_IteratorPattern
{
    public class QuestionItem : QuestionComponent
    {
        private string question;

        public QuestionItem(string question)
        {
            Question = question;
        }

        public string Question { get => question; set => question = value; }

        public override IEnumerator<QuestionComponent> CreateIterator() => new NullIterator<QuestionComponent>();
        public override string ToString()
        {
            return $"Question : {question}";
        }
    }
}
