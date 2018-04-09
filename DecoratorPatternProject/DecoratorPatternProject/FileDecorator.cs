using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DecoratorPatternProject
{
    public abstract class FileDecorator : FileWriteComponent
    {
        private FileWriteComponent fileWriteComponent;
        private string data;
        protected FileDecorator(FileWriteComponent fileWriteComponent, string data = "")
        {
            this.data = data;
            this.fileWriteComponent = fileWriteComponent;
        }
        public override void Write()
        {
            if (this.GetType() == typeof(SignatureDecorator))
                AddSignature();
            else if (this.GetType() == typeof(ShiftCharUpDecorator))
                ModifyUp();
            else if (this.GetType() == typeof(ShiftCharDownDecorator))
                ModifyDown();
        }
        private void AddSignature()
        {
            StreamWriter stream = new StreamWriter(fileLoc, true);
            stream.WriteLine($"\r\nName: {data} | Date: {DateTime.Now}");
            stream.Close();
        }
        private void ModifyUp()
        {
            StringBuilder stringBuilder = new StringBuilder();
            char tempChar = ' ';
            string[] lines = File.ReadAllLines(fileLoc);
            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    tempChar = c;
                    if (tempChar == 'z')
                        tempChar = 'a';
                    else if (tempChar == 'Z')
                        tempChar = 'A';
                    else
                        tempChar++;
                    stringBuilder.Append(tempChar);
                }
            }

            StreamWriter stream = new StreamWriter(fileLoc, true);
            stream.Write(stringBuilder.ToString());
            stream.Close();
        }
        private void ModifyDown()
        {
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
