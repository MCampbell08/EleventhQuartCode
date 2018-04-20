using System;
using System.Collections.Generic;
using System.Text;

namespace CommandUniversalRemoteControl
{
    public class TVPowerOnCommand : ICommand
    {
        private TV tvDriver;
        public TVPowerOnCommand(TV tvDriver)
        {
            this.SetTVDriver(tvDriver);
        }

        public void Execute()
        {
            tvDriver.PowerOn();
        }

        public TV GetTVDriver()
        {
            return tvDriver;
        }
        public void SetTVDriver(TV tvDriver)
        {
            if (tvDriver == null)
                throw new ArgumentException("Cannot be null");
            else
                this.tvDriver = tvDriver;
        }
    }
}
