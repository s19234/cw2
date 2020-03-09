using System;
using System.Xml.Serialization;

namespace Ćwiczenia2
{
    [Serializable]
    public class Student
    {
        private string _name;
        private string _lname;
        private string _type;
        private string _type1;
        private string _index;
        private string _dateofbirth;
        private string _email;
        private string _fname;
        private string _mname;

        public void Add(string[] studentInfo)
        {
            this._name = studentInfo[0];
            this._lname = studentInfo[1];
            this._type = studentInfo[2];
            this._type1 = studentInfo[3];
            this._index = studentInfo[4];
            this._dateofbirth = studentInfo[5];
            this._email = studentInfo[6];
            this._mname = studentInfo[7];
            this._fname = studentInfo[8];



            this.Name = _name;
            this.LName = _lname;
            this.Type = _type;
            this.Type1 = _type1;
            this.Index = _index;
            this.DateOfBirth = _dateofbirth;
            this.MName = _mname;
            this.FName = _fname;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name is null)
                    _name = "0";
            }
        }

        public string LName
        {
            get { return _lname; }
            set
            {
                if (_lname is null)
                    _lname = "0";
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                if (_type is null)
                    _type = "0";
            }
        }

        public string Type1
        {
            get { return _type1; }
            set
            {
                if (_type1 is null)
                    _type1 = "0";
            }
        }

        [XmlAttribute("StudentIndexNumber")]
        public string Index
        {
            get { return _index; }
            set
            {
                if (_index is null)
                    _index = "0";
            }
        }

        public string DateOfBirth
        {
            get { return _dateofbirth; }
            set
            {
                if (_dateofbirth is null)
                    _dateofbirth = "0";
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email is null)
                    _email = "0";
            }
        }
        public string MName
        {
            get { return _mname; }
            set
            {
                if (_mname is null)
                    _mname = "0";
            }
        }

        public string FName
        {
            get { return _fname; }
            set
            {
                if (_fname is null)
                    _fname = "0";
            }
        }
    }
}
