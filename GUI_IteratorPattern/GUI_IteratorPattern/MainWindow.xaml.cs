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
        public Questionnaire questionnaire;
        private QuestionSection questionSections;
        private QuestionComponent currentComponent;
        private List<QuestionComponent> sectionHistory;

        public MainWindow()
        {
            InitializeComponent();
            CreateSampleQuestionnaire();

        }
        
        private void CreateSampleQuestionnaire()
        {
            InitializeQuestionModels();
            GenerateSections();
            questionnaire.Sections.Add(questionSections);
            questionnaire.Print(sectionListBox, questionListBox);
        }
        private void GenerateSections()
        {
            questionSections.Items.Add(new QuestionItem("What color is the sky?"));
            questionSections.Items.Add(new QuestionItem("If a tree falls in a forest and no one is around to hear it, does it make a sound?"));
        }
        private void InitializeQuestionModels()
        {
            questionnaire = new Questionnaire() { Sections = new List<QuestionComponent>(), Content = "Questionnaire" };
            questionSections = new QuestionSection("General Knowledge"){ Items = new List<QuestionComponent>() };
            currentComponent = questionnaire;
            sectionHistory = new List<QuestionComponent>();
        }

        private void SectionTextBlock_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sectionListBox.SelectedItem != null) {
                foreach (QuestionComponent component in currentComponent.Items)
                {
                    if (component.Content == sectionListBox.SelectedItem.ToString())
                    {
                        sectionHistory.Add(currentComponent);
                        currentComponent = component;
                    }
                }
                RefreshWindow();
            }
        }

        private void UndoSectionCall_Click(object sender, RoutedEventArgs e)
        {
            if (sectionHistory.Count != 0)
            {
                currentComponent = sectionHistory.Last();
                sectionHistory.Remove(sectionHistory.Last());

                RefreshWindow();
            }
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            if (insertComponentTextBox.Text != "")
            {
                currentComponent.Items.Add(new QuestionItem(insertComponentTextBox.Text));
                RefreshWindow();
            }
        }

        private void AddSectionButton_Click(object sender, RoutedEventArgs e)
        {
            if (insertComponentTextBox.Text != "") {
                currentComponent.Items.Add(new QuestionSection(insertComponentTextBox.Text));
                RefreshWindow();
            }
        }
        
        private void RefreshWindow()
        {
            questionListBox.Items.Clear();
            sectionListBox.Items.Clear();
            currentComponent.Print(sectionListBox, questionListBox);
            sectionLabel.Content = currentComponent.Content.ToString();
        }

        private void TakeAssessmentButton_Click(object sender, RoutedEventArgs e)
        {
            QuizWindow window = new QuizWindow(this);
            window.Show();
        }
    }
}
