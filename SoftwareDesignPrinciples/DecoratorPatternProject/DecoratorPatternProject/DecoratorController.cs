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
            /*
             Q: What happens in the written file when you wrap decorator 1 in decorator 2? What about decorator 2 in 1?
            
             A: As you can see below, I am wrapping the SignatureDecorator around a new instance of the "ShiftCharUpDecorator" - which changes each character in the text file a character up.
             What happens as the new instance object that is being wrapped around is passed through the SignatureDecorator constructor which gives it the preceding call of it's "Write()" method.
             So the ShiftCharUpDecorator's write method is called first and then the SignatureDecorator's "Write()" method will then be called.
             
             If we were to wrap the opposite way, the SignatureDecorator's "Write()" method will be called first and then the ShiftCharUpDecorator's "Write()" method will follow. 
             Of course this would just shift all the characters in the signature up a character but essentially that would happen.
             */


            SignatureDecorator signatureDecorator = new SignatureDecorator(new ShiftCharUpDecorator(fileBaseComponent), "Mason");
            signatureDecorator.Write();

            ConverterDecorator converterDecorator = new ConverterDecorator(fileBaseComponent);
            converterDecorator.Write();
        }
    }
}
    