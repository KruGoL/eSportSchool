using eSportSchool.Data.Preparation;

namespace eSportSchool.Domain.Preparation
{
    public class Exercise
    {
        private const string _defaultStr = "Undefined";
        private ExerciseData _data;

        public Exercise() : this (new ExerciseData()){}
        public Exercise(ExerciseData d)=> _data=d;
        public ExerciseData Data => _data;

        public string Id => _data?.Id ?? _defaultStr;
        public string TrainingId => _data?.TrainingId?? _defaultStr;
        public string ExerciseTitle => _data?.ExerciseTitle?? _defaultStr;
        public string Description => _data?.Description ?? _defaultStr;
    }
}
