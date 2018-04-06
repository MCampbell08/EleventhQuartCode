using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DecoratorPatternProject
{
    public class PlainFileWriter : IBasicFileWriter
    {
        private StreamWriter _streamWriter;
        public PlainFileWriter(StreamWriter streamWriter)
        {
            _streamWriter = streamWriter;
        }
        public void Dispose()
        {
            SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
            handle.Dispose();
        }

        public void Write(string data)
        {
            _streamWriter.WriteLine(data);
        }
    }
}
