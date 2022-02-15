
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;

namespace eSportSchool.Facade
{
    public class ExerciseViewFactory 
    {
        public Exercise Create(ExerciseView v) => new(new ExerciseData()
        {
            Id = v.Id,
            TrainingId = v.TrainingId,
            ExerciseTitle = v.ExerciseTitle,
            Description = v.Description,
        });

        public ExerciseView Create(Exercise o) => new()
        {
            Id = o.Id,
            TrainingId = o.TrainingId,
            ExerciseTitle = o.ExerciseTitle,
            Description = o.Description,
        };
    }
}
