﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
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
                if(!File.Exists("log.txt"))
                {
                    using(StreamWriter sw = File.CreateText("log.txt"))
                    {
                        sw.WriteLine(ex.Message);
                    }
                }
                else
                {
                    using(StreamWriter sw = File.AppendText("log.txt"))
                    {
                        sw.WriteLine(ex.Message);
                    }
                }
                
            }
        }

        /// <summary>
        /// Funkcja do zapisywania na gałeziąch xmla
        /// odpowiednich wartości. Nie sprawdza czy plik
        /// istnieje oraz root jest odpowiedni
        /// </summary>
        /// <param name="writer">Do jakiego pliku ma być dodany student</param>
        /// <param name="student">Aktualnie dodawane informacje tego studenta</param>
        static void WriteToXmlFile(XmlWriter writer, Student student)
        {
            writer.WriteStartElement("student");
            writer.WriteAttributeString("indexNumber", student.Index);
            writer.WriteElementString("fname", student.Name);
            writer.WriteElementString("lname", student.LName);
            writer.WriteElementString("birthdate", student.DateOfBirth);
            writer.WriteElementString("email", student.Email);
            writer.WriteElementString("mothersName", student.MName);
            writer.WriteElementString("fathersName", student.FName);
            writer.WriteStartElement("studies");
            writer.WriteElementString("name", student.Type);
            writer.WriteElementString("mode", student.Type1);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        /// <summary>
        /// Metoda wczytująca dane z pliku do innego pliku
        /// w podanym formacie. Podczas zapisu wykorzystuje metodę
        /// WriteToXmlFile. Wykonuje switch na rozszerzeniu pliku,
        /// by w jak najlepszy sposób oddawać format tego pliku.
        /// </summary>
        /// <param name="inputFile">Następuje odczyt z tego pliku</param>
        /// <param name="outputFile">Zmienna, gdzie zapisać</param>
        /// <param name="dataType">Format danych w pliku</param>
        /// <exception cref="FileNotFoundException">Jeśli plik do wczytania nie istnieje</exception>
        static void Start(string inputFile = @"data.csv",
            string outputFile = "result", String dataType = "xml")
        {
            List<Student> students = new List<Student>();
            FileInfo file = new FileInfo(inputFile);
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

                switch(dataType)
                {
                    case "xml":
                        outputFile += ("." + dataType);
                        XmlWriterSettings settings = new XmlWriterSettings();
                        settings.Indent = true;
                        XmlWriter writer = XmlWriter.Create(@outputFile, settings);
                        writer.WriteStartDocument();
                        writer.WriteComment("This file is generated by the program");
                        writer.WriteStartElement("uczelnia");
                        writer.WriteAttributeString("createdAt", DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "."));
                        writer.WriteAttributeString("author", "Ryszard Szewczyk");
                        writer.WriteStartElement("studenci");
                        foreach(Student s in students)
                        {
                            WriteToXmlFile(writer, s);
                        }
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();

                        break;
                    case "json":
                        outputFile += ("." + dataType);
                        var jsonString = JsonSerializer.Serialize(students);
                        File.WriteAllText(outputFile, jsonString);
                        break;
                    default:
                        Console.WriteLine("Can't recognize file type");
                        break;
                }
            }
            else
            {
                throw new FileNotFoundException("Can't find specified file");
            }
        }
    }
}
