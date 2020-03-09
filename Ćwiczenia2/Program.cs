using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text.Json;

namespace Ćwiczenia2
{
    class Program
    {
        // Główna metoda programu
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

        /// <summary>
        /// Metoda wczytująca dane z pliku do innego pliku
        /// w podanym formacie
        /// </summary>
        /// <param name="inputFile">Następuje odczyt z tego pliku</param>
        /// <param name="outputFile">Zmienna, gdzie zapisać</param>
        /// <param name="dataType">Format danych w pliku</param>
        static void Start(string inputFile = @"data.csv",
            string outputFile = "result", String dataType = "xml")
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

                FileStream writer = null;
                switch(dataType)
                {
                    case "xml":
                        outputFile += ("." + dataType);
                        writer = new FileStream(outputFile, FileMode.Create);
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                            new XmlRootAttribute("uczelnia"));
                        serializer.Serialize(writer, students);
                        break;
                    case "json":
                        outputFile += ("." + "json");
                        var jsonString = JsonSerializer.Serialize(students);
                        File.WriteAllText(outputFile, jsonString);
                        break;
                    default:
                        Console.WriteLine("Can't recognize file type");
                        break;
                }

                /*FileStream writer = new FileStream(outputFile, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                    new XmlRootAttribute("uczelnia"));*/

                //serializer.Serialize(writer, students);
            }
            else
            {
                throw new FileNotFoundException("Can't find specified file");
            }
        }
    }
}
