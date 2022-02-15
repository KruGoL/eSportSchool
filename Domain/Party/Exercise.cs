using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party
{
    public class Exercise:Training
    {
        private const string _defaultStr = "Undefined";
        private ExerciseData _data;

        public Exercise() : this (new ExerciseData()){}
        public Exercise(ExerciseData d)=> _data=d;
        public ExerciseData Data => _data;

        public string ExerciseId => _data?.ExerciseId ?? _defaultStr;
        public string ExerciseTitle => _data?.ExerciseTitle?? _defaultStr;
        public string Description => _data?.Description ?? _defaultStr;
    }
}
