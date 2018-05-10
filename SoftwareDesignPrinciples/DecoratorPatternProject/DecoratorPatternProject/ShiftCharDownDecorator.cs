using System;
using System.Collections.Generic;
using System.IO;
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
            StringBuilder stringBuilder = new StringBuilder();
            char tempChar = ' ';
            string[] lines = File.ReadAllLines(fileLoc);
            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    tempChar = c;
                    if (tempChar == 'a')
                        tempChar = 'z';
                    else if (tempChar == 'A')
                        tempChar = 'Z';
                    else
                        tempChar--;
                    stringBuilder.Append(tempChar);
                }
            }

            StreamWriter stream = new StreamWriter(fileLoc, true);
            stream.Write(stringBuilder.ToString());
            stream.Close();
        }
    }
}
