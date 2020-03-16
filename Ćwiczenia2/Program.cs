using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Text.Json;
using System.Security.Principal;

namespace Ćwiczenia2
{
    class Program
    {
        // Główna metoda programu
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            using (var stream = new StreamReader(File.OpenRead("dane.csv")))
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

            Uczelnia uczelnia = new Uczelnia();
            uczelnia.AddStudents(students);

            uczelnia.WriteToXmlFile("result");
        }
    }
}
