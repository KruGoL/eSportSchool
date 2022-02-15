using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace eSportSchool.Data.Party
{
    public class ExerciseData : TrainingData
    {
        public string ExerciseId { get; set; }
        public string? ExerciseTitle { get; set; }
        public string? Description { get; set; }

    }

}
