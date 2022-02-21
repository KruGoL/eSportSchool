
using eSportSchool.Data.Preparation;
using eSportSchool.Domain.Preparation;
using eSportSchool.Facade.Preparation;

namespace eSportSchool.Facade.Preparation.PreparationViewFactory
{
    public class TrainingViewFactory
    {
        public Training Create(TrainingView v) => new(new TrainingData()
        {
            Id = v.Id,
            SportTeamId = v.SportTeamId,
            Title = v.Title,
            CreatedDate = v.CreatedDate,
        });

        public TrainingView Create(Training o) => new()
        {
            Id = o.Id,
            SportTeamId = o.SportTeamId,
            Title = o.Title,
            CreatedDate = o.CreatedDate,
            FullName = o.ToString()
        };
    }
}
