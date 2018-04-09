using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPatternProject
{
    public class ShiftCharDownDecorator : FileDecorator
    {
        FileWriteComponent fileWriteComponent;
        public ShiftCharDownDecorator(FileWriteComponent fileWriteComponent, string data = "") : base(fileWriteComponent, data)
        {
            this.fileWriteComponent = fileWriteComponent;
        }
        public override void Write()
        {
            fileWriteComponent.Write();
            base.Write();
        }
    }
}
