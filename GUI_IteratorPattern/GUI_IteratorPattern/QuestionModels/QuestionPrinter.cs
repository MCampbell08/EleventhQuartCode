using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_IteratorPattern
{
    public class QuestionPrinter
    {
        public void PrintQuestionItems(Questionnaire questionnaire)
        {
            questionnaire.Print();
        }
    }
}
