using System;
using System.Xml.Serialization;

namespace Ćwiczenia2
{
    /// <summary>
    /// Klasa student
    /// </summary>
    [Serializable]
    public class Student
    {
        /// <summary>
        /// Metoda do przypisawania polom klasy Student
        /// wartości z parametru studentInfo.
        /// Jeśli jakaś wartość jest pusta, odpowiadającemu
        /// polu przypisywane jest zero.
        /// </summary>
        /// <param name="studentInfo">Tablica z informacjami o studencie</param>
        public void Add(string[] studentInfo)
        {
            this.Name = studentInfo[0] is null ? "0" : studentInfo[0];
            this.LName = studentInfo[1] is null ? "0" : studentInfo[1];
            this.Type = studentInfo[2] is null ? "0" : studentInfo[2];
            this.Type1 = studentInfo[3] is null ? "0" : studentInfo[3];
            this.Index = studentInfo[4] is null ? "0" : studentInfo[4];
            this.DateOfBirth = studentInfo[5] is null ? "0" : studentInfo[5];
            this.Email = studentInfo[6] is null ? "0" : studentInfo[6];
            this.MName = studentInfo[7] is null ? "0" : studentInfo[7];
            this.FName = studentInfo[8] is null ? "0" : studentInfo[8];
        }

        // Imie studenta
        [XmlElement("StudentsName")]
        public string Name { get; set; }

        // Nazwisko studenta
        [XmlElement("StudentsLastName")]
        public string LName { get; set; }


        // Typ studiów - informatyka, sztuka nowych mediów
        [XmlElement("StudentsTypeOfStudies")]
        public string Type { get; set; }

        // Typ studiów - dzienne, zaoczne
        [XmlElement("StudentsWhenStudies")]
        public string Type1 { get; set; }

        // Index studenta
        [XmlElement("StudentsIndex")]
        public string Index { get; set; }

        // Data urodzin
        [XmlElement("StudentsDateOfBirth")]
        public string DateOfBirth { get; set; }

        // Email studenta
        [XmlElement("StudentsEmail")]
        public string Email { get; set; }

        // Imie matki studenta
        [XmlElement("StudentsMothersName")]
        public string MName { get; set; }

        // Imie ojca studenta
        [XmlElement("StudentsFathersName")]
        public string FName { get; set; }
    }
}
