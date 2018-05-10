using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DecoratorPatternProject
{
    public class SignatureDecorator : FileDecorator
    {
        FileWriteComponent fileWriteComponent;
        private string data;

        public SignatureDecorator(FileWriteComponent fileWriteComponent, string data = "") : base(fileWriteComponent, data)
        {
            this.fileWriteComponent = fileWriteComponent;
            this.data = data;
        }
        public override void Write()
        {
            fileWriteComponent.Write();
            StreamWriter stream = new StreamWriter(fileLoc, true);
            stream.WriteLine($"\r\nName: {data} | Date: {DateTime.Now}");
            stream.Close();
        }
    }
}
