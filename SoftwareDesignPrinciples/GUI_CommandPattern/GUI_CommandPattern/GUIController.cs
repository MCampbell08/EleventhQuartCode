using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_CommandPattern
{
    public class GUIController
    {
        List<ICommand> commands = new List<ICommand>();

        public void ExecuteGUICommand(ICommand command)
        {
            commands.Add(command);
            command.Execute();
        }
        public void UndoRecentGUICommand()
        {
            if (commands.Count != 0) {
                ICommand tempCommand = commands.Last();
                tempCommand.Undo();
                commands.RemoveAt(commands.Count - 1);
            }
        }
    }
}
