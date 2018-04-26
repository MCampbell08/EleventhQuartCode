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

        public List<QuestionComponent> Sections { get => sections; set => sections = value; }

        public override IEnumerator<QuestionComponent> CreateIterator()
        {
            return Sections.GetEnumerator();
        }
    }
}
