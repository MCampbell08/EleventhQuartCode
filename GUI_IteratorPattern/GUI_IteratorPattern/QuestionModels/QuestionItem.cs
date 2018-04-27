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
        private string section;
        private string subSection;

        public QuestionItem(string section, string subSection, string question)
        {
            Section = section;
            SubSection = subSection;
            Question = question;
        }

        public string Question { get => question; set => question = value; }
        public string Section { get => section; set => section = value; }
        public string SubSection { get => subSection; set => subSection = value; }

        public override IEnumerator<QuestionComponent> CreateIterator() => new NullIterator<QuestionComponent>();
        public override string ToString()
        {
            return $"Section : {Section} | SubSection : {SubSection} | Question : {Question}";
        }
    }
}
