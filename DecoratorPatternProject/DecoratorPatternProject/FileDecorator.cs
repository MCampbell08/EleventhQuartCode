using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DecoratorPatternProject
{
    public abstract class FileDecorator : FileWriteComponent
    {
        protected FileDecorator(FileWriteComponent fileWriteComponent, string data = "")
        {
        }
        public override void Write()
        {
        }
    }
}
