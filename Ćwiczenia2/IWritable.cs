using System;
using System.IO;

namespace Ćwiczenia2
{
    interface IWritable
    {
        void WriteToXmlFile(string outputFileName);
        void WriteToJsonFile(string outputFileName);
    }
}
