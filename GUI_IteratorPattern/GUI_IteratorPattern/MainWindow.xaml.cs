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
        private Questionnaire questionnaire;
        private QuestionSection questionSections;
        private QuestionSubSections questionSubSections;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void CreateSampleQuestionnaire()
        {
            InitializeQuestionModels();
            GenerateSubSections();
            GenerateSections();
            questionnaire.Sections.Add(questionSections);

        }
        private void GenerateSections()
        {
            questionSubSections.Questions.Add(new QuestionItem( "General Knowledge", "Outside", "What color is the sky?"));
            questionSubSections.Questions.Add(new QuestionItem( "General Knowledge", "Deep Thought", "If a tree falls in a forest and no one is around to hear it, does it make a sound?"));
        }
        private void GenerateSubSections()
        {
            questionSections.SubSections.Add(questionSubSections);
        }

        private void InitializeQuestionModels()
        {
            questionnaire = new Questionnaire() { Sections = new List<QuestionComponent>() };
            questionSections = new QuestionSection(){ SubSections = new List<QuestionComponent>() };
            questionSubSections = new QuestionSubSections(){ Questions = new List<QuestionComponent>() } ;
        }
        private void AddSectionButton_Click(object sender, RoutedEventArgs e)
        {
            if (sectionInput.Text != "")
            {

            }
        }

        private void AddSubSectionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DisplaySampleButton_Click(object sender, RoutedEventArgs e)
        {
            CreateSampleQuestionnaire();
            popUpWindow.IsOpen = true;
            new QuestionPrinter().PrintQuestionItems(questionnaire, textBlockInDisplay);
        }

        private void ButtonInDisplay_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
