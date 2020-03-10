using System;
using System.Text.RegularExpressions;

namespace Ćwiczenia2
{
    /// <summary>
    /// Klasa student
    /// </summary>
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
            this.Index = studentInfo[4] is null ? "0" : "s" + studentInfo[4];
            this.DateOfBirth = studentInfo[5] is null ? "0" : studentInfo[5].Replace("-", ".");
            this.Email = studentInfo[6] is null ? "0" : Regex.Replace(studentInfo[6], "[0-9]{2,}", Index);
            this.MName = studentInfo[7] is null ? "0" : studentInfo[7];
            this.FName = studentInfo[8] is null ? "0" : studentInfo[8];
        }

        // Imie studenta
        public string Name { get; set; }

        // Nazwisko studenta
        public string LName { get; set; }

        // Index studenta
        public string Index { get; set; }

        // Data urodzin
        public string DateOfBirth { get; set; }

        // Email studenta
        public string Email { get; set; }

        // Imie matki studenta
        public string MName { get; set; }

        // Imie ojca studenta
        public string FName { get; set; }

        // Typ studiów - informatyka, sztuka nowych mediów
        public string Type { get; set; }

        // Typ studiów - dzienne, zaoczne
        public string Type1 { get; set; }
    }
}
