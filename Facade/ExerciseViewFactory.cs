
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;

namespace eSportSchool.Facade
{
    public class ExerciseViewFactory : TrainingViewFactory
    {
        public Exercise Create(ExerciseView v) => new(new ExerciseData()
        {
            ExerciseId = v.ExerciseId,
            ExerciseTitle = v.ExerciseTitle,
            Description = v.Description,
        });

        public ExerciseView Create(Exercise o) => new()
        {
            ExerciseId = o.ExerciseId,
            ExerciseTitle = o.ExerciseTitle,
            Description = o.Description,
        };
    }
}
