using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportSchool.Data
{
    public class PersonData
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public  string? LastName { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DoB { get; set; }
    }
}
