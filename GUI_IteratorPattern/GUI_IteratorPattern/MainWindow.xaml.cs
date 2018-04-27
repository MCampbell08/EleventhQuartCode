using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_IteratorPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Questionnaire questionnaire;
        QuestionSection questionSections;
        QuestionSubSections questionSubSections;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeQuestionModels()
        {
            questionnaire = new Questionnaire() { Sections = new List<QuestionComponent>() };
            questionSections = new QuestionSection(){ SubSections = new List<QuestionComponent>() };
            questionSubSections = new QuestionSubSections(){ Questions = new List<QuestionComponent>() } ;
        }

        private void AddSectionButton_Click(object sender, RoutedEventArgs e)
        {
            if(sectionInput.Text != "")
            {
                var result = questionnaire.Sections.Where(x => (QuestionSection)x.);
            }
        }

        private void AddSubSectionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
