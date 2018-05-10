using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_IteratorPattern
{
    public class Questionnaire : QuestionComponent
    {
        private List<QuestionComponent> sections = new List<QuestionComponent>();
        private string content = "";

        public List<QuestionComponent> Sections { get => sections; set => sections = value; }
        public override string Content { get => content; set => content = value; }
        public override List<QuestionComponent> Items { get => sections; set => sections = value; }

        public override IEnumerator<QuestionComponent> CreateIterator()
        {
            return Sections.GetEnumerator();
        }

        public override string ToString()
        {
            return $"{Content}";
        }
    }
}
