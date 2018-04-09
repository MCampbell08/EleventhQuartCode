using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DecoratorPatternProject
{
    public abstract class FileWriteComponent
    {
        protected static string fileLoc = "C:\\EleventhQuartCode\\DecoratorPatternProject\\DecoratorPatternProject\\testFile.txt";
        public abstract void Write();
    }
}
