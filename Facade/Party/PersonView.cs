﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportSchool.Facade.Party
{
    public class PersonView
    {
        [Required] public string Id { get; set; }
        [DisplayName("First name")] public string? FirstName { get; set; }
        [DisplayName("Last name")] [Required] public string? LastName { get; set; }
        [DisplayName("Gender")] public  bool? Gender { get; set; }
        [DisplayName("Date of birth")] public DateTime? DoB { get; set; }
        [DisplayName("Full name")]public string? FullName { get; set; }

    }
}
