using System;
using System.Collections.Generic;
using System.Text;

namespace CommandUniversalRemoteControl
{
    public class RemoteControl
    {
        public const int COUNT_ROWS = 8;
        public const int COUNT_COLS = 2;

        private ICommand[,] Buttons = new ICommand[COUNT_ROWS, COUNT_COLS];
        private string[] Labels = new string[COUNT_ROWS];

        public RemoteControl()
        {
            for (int i = 0; i < COUNT_ROWS; i++)
                Labels[i] = "";
        }
        public void ProgramButton(int row, int column, ICommand command)
        {
            Buttons[row, column] = command;
        }
        public void PressButton(int row, int column)
        {
            Buttons[row, column].Execute();
        }
        public void ResetAll()
        {
            for (int i = 0; i < COUNT_ROWS; i++)
                for (int j = 0; j < COUNT_COLS; j++)
                    Buttons[i, j] = null;
        }
        public string ReadLabel(int row)
        {
            return Labels[row];
        }
        public void SetLabel(int row, string text)
        {
            Labels[row] = text;
        }
    }
}
