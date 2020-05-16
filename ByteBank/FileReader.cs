using System;
using System.IO;

namespace ByteBank
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1063:Implement IDisposable Correctly", Justification = "<Pendente>")]
    public class FileReader : IDisposable
    {
        public string File { get; }

        public FileReader(string file)
        {
            File = file;
            Console.WriteLine("Opening file: " + file);
        }

        public string ReadNextLine()
        {
            Console.WriteLine("Reading line...");
            throw new IOException();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1063:Implement IDisposable Correctly", Justification = "<Pendente>")]
        public void Dispose()
        {
            Console.WriteLine("Closing file.");
        }
    }
}
