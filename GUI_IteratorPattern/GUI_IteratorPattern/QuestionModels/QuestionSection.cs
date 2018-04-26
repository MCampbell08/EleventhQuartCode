using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_IteratorPattern
{
    public class QuestionSection : QuestionComponent
    {
        private List<QuestionComponent> subSections = new List<QuestionComponent>();

        public List<QuestionComponent> SubSections { get => subSections; set => subSections = value; }

        public override IEnumerator<QuestionComponent> CreateIterator()
        {
            return SubSections.GetEnumerator();
        }
    }
}
