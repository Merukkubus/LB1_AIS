using Microsoft.VisualBasic.FileIO;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.IO;
using System.Text;
using static ЛБ1.Reader;

namespace ЛБ1
{
 
 
        public class Reader
        {
            public int id { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public int semester { get; set; }
            public bool scholarship { get; set; }

            public Reader(int _id, string _name, string _surname, int _semester, bool _scholarship)
            {
                this.id = _id;
                this.name = _name;
                this.surname = _surname;
                this.semester = _semester;
                this.scholarship = _scholarship;
            }

            public string GetLine()
            {
                return string.Format("{0} {1} {2} {3} {4}", id, name, surname, semester, scholarship);
            }
        }
}