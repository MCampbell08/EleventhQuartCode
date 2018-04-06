using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPatternProject
{
    public interface IBasicFileWriter : IDisposable
    {
        void Write(string data);
    }
}
