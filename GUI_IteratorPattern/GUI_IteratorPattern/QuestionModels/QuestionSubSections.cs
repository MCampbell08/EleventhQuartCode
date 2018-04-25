using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_IteratorPattern
{
    public class QuestionSubSections : QuestionComponent
    {
        private List<QuestionComponent> questions = new List<QuestionComponent>();

        public List<QuestionComponent> Questions { get => questions; set => questions = value; }

        public override IEnumerator<QuestionComponent> CreateIterator()
        {
            return questions.GetEnumerator();
        }
    }
}
