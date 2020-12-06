using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClassLibrary
{
    public class FilePrinter:IPrinter
    {
        string fileName;
        public FilePrinter(string fileName)
        {
            this.fileName = fileName+".txt";
        }

        public void Print(string write)
        {
            
            using(StreamWriter streamWriter=new StreamWriter(fileName))
            {
                streamWriter.WriteLine(write);
            }
        }
    }
}
