using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DecoratorPatternProject
{
    public abstract class FileWriteComponent
    {
        protected static string fileLoc = ".\\testFile.txt";
        public abstract void Write();
    }
}
