
using eSportSchool.Data.Preparation;
using eSportSchool.Domain.Preparation;
using eSportSchool.Facade.Preparation;

namespace eSportSchool.Facade.PreparationViewFactory
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
