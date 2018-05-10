using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DecoratorPatternProject
{
    public class ConverterDecorator : FileDecorator
    {
        FileWriteComponent fileWriteComponent;
        public ConverterDecorator(FileWriteComponent fileWriteComponent, string data = "") : base(fileWriteComponent, data)
        {
            this.fileWriteComponent = fileWriteComponent;
        }
        public override void Write()
        {
            fileWriteComponent.Write();
            string[] lines = File.ReadAllLines(fileLoc);

            if (IsDos(lines))
                DosToUnix(lines);
            else
                UnixToDos(lines);
        }
        private bool IsDos(string[] lines)
        {
            using (FileStream fileStream = File.OpenRead(fileLoc))
            {
                char character = ' ', prevChar = ' ';

                for(; ; )
                {
                    int b;
                    if ((b = fileStream.ReadByte()) == -1) break;

                    character = (char)b;


                    if (prevChar == '\r' && character == '\n')
                        return true;
                    else if (character == '\n')
                        break;
                    prevChar = character;
                }
                return false;
            }
        }
        private void UnixToDos(string[] lines)
        {
            string text = File.ReadAllText(fileLoc);
            text = text.Replace("\n", "\r\n");
            File.WriteAllText(fileLoc, text);
        }
        private void DosToUnix(string[] lines)
        {
            string text = File.ReadAllText(fileLoc);
            text = text.Replace("\r\n", "\n");
            File.WriteAllText(fileLoc, text);
        }
    }
}
