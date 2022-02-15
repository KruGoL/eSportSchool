using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace eSportSchool.Facade.Party
{
    public class ExerciseView : TrainingView
    {
        [Required] public string ExerciseId { get; set; }
        [DisplayName("Title")] public string ExerciseTitle { get; set; }
        [DisplayName("Description")] public string? Description { get; set; }

    }
}
