using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

using DWORD = System.Int32;

namespace Ćwiczenia2
{
    class Uczelnia : IWritable
    {
        private Dictionary<string, int> modeNumber = new Dictionary<string, int>();
        private List<Student> students = new List<Student>();


        /// <summary>
        /// Metoda do dodawania studenta do uczelni
        /// </summary>
        /// <param name="student">Student do dodania</param>
        /// <returns>Zwraca -1 jesli student istnieje, inaczej zwraca 0</returns>
        public DWORD AddStudent(Student student)
        {
            if (this.students.Contains(student))
                return -1;
            else
            {
                AddMode(student.Type + " " + student.Type1);
                this.students.Add(student);
                return 0;
            }
        }

        /// <summary>
        /// Metoda do agregacji listy studentów
        /// </summary>
        /// <param name="students">Lista studentów do dodania</param>
        /// <returns>Jeśli choć jeden student się powtórzył, zwraca -1, jeśli wszyscy studenci się powtórzyli zwraca -2,
        /// jeśli żaden to 0</returns>
        public DWORD AddStudents(List<Student> students)
        {
            int howMany = 0;
            foreach (Student student in students)
            {
                if (this.students.Contains(student))
                    howMany++;
                else
                {
                    AddMode(student.Type);
                    this.students.Add(student);
                }
            }
            if (howMany > 1 && howMany < students.Count)
                return -1;
            else if (howMany.Equals(students.Count))
                return -2;

            return 0;
        }

        /// <summary>
        /// Metoda do agregacji listy studentów
        /// </summary>
        /// <param name="students">Lista studentów do dodania</param>
        /// <returns>Jeśli choć jeden student się powtórzył, zwraca -1, jeśli wszyscy studenci się powtórzyli zwraca -2,
        /// jeśli żaden to 0</returns>
        public DWORD AddStudents(params Student[] students)
        {
            int howMany = 0;
            foreach (Student student in students)
            {
                if (this.students.Contains(student))
                    howMany++;
                else
                {
                    AddMode(student.Type);
                    this.students.Add(student);
                }
            }
            if (howMany > 1 && howMany < students.Count())
                return -1;
            else if (howMany.Equals(students.Count()))
                return -2;

            return 0;
        }

        /// <summary>
        /// Metoda do usuwania studentów z uczelni
        /// </summary>
        /// <param name="student">Student do usunięcia</param>
        /// <returns>Zwraca 0 jeśli student został usunięty, inaczej zwraca -1</returns>
        public DWORD RemoveStudent(Student student)
        {
            if (this.students.Contains(student))
            {
                this.students.Remove(student);
                DecreaseModeNumber(student.Type);
                return 0;
            }
            return -1;
        }

        /// <summary>
        /// Metoda do usuwania studenta z listy na podanym indeksie
        /// </summary>
        /// <param name="index">Indeks w liscie</param>
        /// <returns>Zwraca zero jeśli się udało usunąć studenta, w innym przypadku zwraca -1</returns>
        public DWORD RemoveStudent(int index)
        {
            try
            {
                students.RemoveAt(index);
                return 0;
            }
            catch (IndexOutOfRangeException)
            {
                return -1;
            }
        }

        /// <summary>
        /// Prywatna metoda do dodawania trybów oraz liczby studentów na danym trybie
        /// </summary>
        /// <param name="mode">Tryb do dodania do słownika</param>
        /// <returns>Zwraca 1 jeśli tryb już istnieje oraz zwiększa liczbę studentów na tym trybie,
        /// inaczej zwraca zero - dodaje tryb oraz ustawia liczbę studentów na jeden.</returns>
        private DWORD AddMode(String mode)
        {
            if (this.modeNumber.ContainsKey(mode))
            {
                modeNumber[mode] += 1;
                return 1;
            }
            else
            {
                modeNumber.Add(mode, 1);
                return 0;
            }
        }

        /// <summary>
        /// Metoda do zmiany ilosci studentów na danym trybie
        /// </summary>
        /// <param name="mode">Tryb do zmiany liczby studentów</param>
        /// <returns>Zwraca -1 jesli tryb nie istnieje, zwraca -2 jesli nie ma studentów na danym trybie,
        /// zero jesli istnieje oraz zmiejsza liczbe studentów</returns>
        private DWORD DecreaseModeNumber(String mode)
        {

            if (this.modeNumber.ContainsKey(mode))
            {
                if (modeNumber[mode] == 0)
                    return -2;
                modeNumber[mode] -= 1;
                return 0;
            }
            return -1;
        }

        /// <summary>
        /// Zapisywanie do pliku w formacie xml.
        /// </summary>
        /// <param name="outputFileName">Nazwa pliku, w którym będą zapisane dane</param>
        public void WriteToXmlFile(string outputFileName)
        {
            outputFileName += ".xml";
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(@outputFileName, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("uczelnia");
            writer.WriteAttributeString("createdAt", DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "."));
            writer.WriteAttributeString("author", System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            writer.WriteComment("This file is generated by the program");
            writer.WriteStartElement("studenci");
            foreach (Student student in students)
            {
                WriteToXmlFile(writer, student);
            }
            writer.WriteEndElement();
            writer.WriteStartElement("activeStudies");
            foreach(KeyValuePair<string, int> iter in modeNumber)
            {
                writer.
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
        }

        /// <summary>
        /// Prywatna metoda do formatowania zapisywanego studenta
        /// </summary>
        /// <param name="writer">Xml writer wykorzystywany przy formatowanym zapise do pliku</param>
        /// <param name="student">Student do zapisu</param>
        private void WriteToXmlFile(in XmlWriter writer, in Student student)
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
        /// Zapisywanie do pliku w formacie json.
        /// </summary>
        /// <param name="outputFileName"></param>
        public void WriteToJsonFile(string outputFileName)
        {
            outputFileName += ".json";
            StreamWriter streamWriter = new StreamWriter(@outputFileName);
            JsonWriter writer = new JsonTextWriter(streamWriter);
            writer.Formatting = Newtonsoft.Json.Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("uczelnia");
            writer.WriteStartObject();
            writer.WritePropertyName("createdAt");
            writer.WriteValue(DateTime.Now.ToString("MM/dd/yyyy").Replace("/", "."));
            writer.WritePropertyName("author");
            writer.WriteValue(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            writer.WritePropertyName("studenci");
            writer.WriteStartArray();
            foreach (Student student in students)
            {
                WriteToJsonFile(writer, student);
            }
            writer.WriteEnd();
            writer.WriteEndObject();
            writer.Close();
        }

        /// <summary>
        /// Prywatna metoda do formatowania zapisywanego studenta
        /// </summary>
        /// <param name="writer">Json writer wykorzystywany przy formatowanym zapise do pliku</param>
        /// <param name="student">Student do zapisu</param>
        private void WriteToJsonFile(in JsonWriter writer, in Student student)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("index");
            writer.WriteValue(student.Index);
            writer.WritePropertyName("fname");
            writer.WriteValue(student.Name);
            writer.WritePropertyName("lname");
            writer.WriteValue(student.LName);
            writer.WritePropertyName("birthdate");
            writer.WriteValue(student.DateOfBirth);
            writer.WritePropertyName("email");
            writer.WriteValue(student.Email);
            writer.WritePropertyName("mothersName");
            writer.WriteValue(student.MName);
            writer.WritePropertyName("fathersName");
            writer.WriteValue(student.FName);
            writer.WritePropertyName("studies");
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteValue(student.Type);
            writer.WritePropertyName("mode");
            writer.WriteValue(student.Type1);
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}