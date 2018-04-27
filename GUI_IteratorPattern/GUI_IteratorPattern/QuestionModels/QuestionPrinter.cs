using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI_IteratorPattern
{
    public class QuestionPrinter
    {
        public void PrintQuestionItems(Questionnaire questionnaire, TextBlock textBlock )
        {
            questionnaire.Print(textBlock);
        }
    }
}
