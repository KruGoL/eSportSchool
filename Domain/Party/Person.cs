using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSportSchool.Data;

namespace eSportSchool.Domain.Party
{
    public class Person
    {
        private const string _defaultStr = "Undefined";
        private const bool _defaultGender = true;
        private DateTime _defaultDate => DateTime.MinValue;
        private PersonData _data;

        public Person ():this (new PersonData()){}
        public Person(PersonData d) => _data = d;
        public string Id => _data?.Id ?? _defaultStr;
        public string FirstName => _data?.FirstName ?? _defaultStr;
        public string LastName => _data?.LastName ?? _defaultStr;
        public bool Gender => _data?.Gender ?? _defaultGender;
        public DateTime DoB => _data?.DoB ?? _defaultDate;
        public override string ToString() => $"{FirstName}{LastName}({Gender},{DoB})";


    }
}
