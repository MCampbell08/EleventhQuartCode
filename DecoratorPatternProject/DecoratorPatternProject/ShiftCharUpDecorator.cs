using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPatternProject
{
    public class ShiftCharUpDecorator : FileDecorator
    {
        FileWriteComponent fileWriteComponent;

        public ShiftCharUpDecorator(FileWriteComponent fileWriteComponent, string data = "") : base(fileWriteComponent, data)
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
