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
using System.Windows.Shapes;

namespace GUI_IteratorPattern
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        private MainWindow mainWindow;
        public QuizWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            PrintQuiz(mainWindow.questionnaire.Items);
            Button button = new Button() { Height = 50, Width = 100, Margin = new Thickness(100, 10, 10, 10), Content = "Submit" };
            answerPanel.Children.Add(button);
        }
        public void PrintQuiz(List<QuestionComponent> list)
        {
            foreach (QuestionComponent questionComponent in list)
            {
                if (questionComponent is QuestionSection)
                {
                    TextBlock textBlock1 = new TextBlock() { Height = 50, Width = 150, Text = questionComponent.Content, Margin = new Thickness(10, 10, 100, 10), TextWrapping = TextWrapping.Wrap, FontWeight = FontWeights.Bold, FontSize = 18 };
                    TextBlock textBlock2 = new TextBlock() { Height = 50, Width = 150, Margin = new Thickness(10, 10, 10, 10) };
                    questionPanel.Children.Add(textBlock1);
                    answerPanel.Children.Add(textBlock2);

                    PrintQuiz(questionComponent.Items);
                }
                else if (questionComponent is QuestionItem)
                {
                    TextBlock textBlock = new TextBlock() { Height = 50, Width = 150, Text = questionComponent.Content, Margin = new Thickness(10, 10, 100, 10), TextWrapping = TextWrapping.Wrap, FontStyle = FontStyles.Italic };
                    TextBox textBox = new TextBox() { Height = 50, Width = 150, Margin = new Thickness(10, 10, 10, 10) };
                    questionPanel.Children.Add(textBlock);
                    answerPanel.Children.Add(textBox);
                }
            }
        }
    }
}
