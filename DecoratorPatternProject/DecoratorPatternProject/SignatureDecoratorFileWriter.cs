using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DecoratorPatternProject
{
    public abstract class SignatureDecoratorFileWriter : PlainFileWriter
    {
        public SignatureDecoratorFileWriter(StreamWriter streamWriter, ) : base(streamWriter)
        {

        }
    }
}
