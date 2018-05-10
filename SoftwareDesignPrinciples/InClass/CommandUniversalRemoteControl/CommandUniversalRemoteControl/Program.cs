using System;

namespace CommandUniversalRemoteControl
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteControl remoteControl = new RemoteControl();
            remoteControl.SetLabel(0, "TV");
            //remoteControl.ProgramButton(0, 0, () => new TVPowerOnCommand().Execute())
        }
    }
}
 