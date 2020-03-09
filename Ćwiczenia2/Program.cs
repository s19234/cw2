using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Ćwiczenia2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Start("dane.csv");
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Start(string inputFile = @"..\data.csv",
            string outputFile = "result.xml", String dataType = "xml")
        {
            List<Student> students = new List<Student>();
            FileInfo file = new FileInfo(inputFile);

            Console.WriteLine(file.FullName);
            if (file.Exists)
            {
                using (var stream = new StreamReader(File.OpenRead(inputFile)))
                {
                    string line = null;
                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] studentInfo = line.Split(",");
                        if (studentInfo.Length < 9)
                            continue;
                        Student student = new Student();
                        student.Add(studentInfo);

                        students.Add(student);
                    }
                }

                FileStream writer = new FileStream(outputFile, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                    new XmlRootAttribute("uczelnia"));

                serializer.Serialize(writer, students);
            }
            else
            {
                throw new FileNotFoundException("Can't find specified file");
            }
        }
    }
}
