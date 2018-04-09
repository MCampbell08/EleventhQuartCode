using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPatternProject
{
    public class DecoratorController
    {
        public void Run()
        {
            FileBaseComponent fileBaseComponent = new FileBaseComponent();

            SignatureDecorator signatureDecorator = new SignatureDecorator(new ShiftCharUpDecorator(fileBaseComponent), "Mason");
            signatureDecorator.Write();
        }
    }
}
    