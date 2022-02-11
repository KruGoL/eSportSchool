using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;

namespace eSportSchool.Facade
{
    public class TrainingViewFactory
    {
        public Training Create(TrainingView v) => new(new TrainingData()
        {
            Id = v.Id,
            SportTeamId = v.SportTeamId,
            Title = v.Title,
            CreatedDate = v.CreatedDate,
            Exercises = v.Exercises
        });

        public TrainingView Create(Training o) => new()
        {
            Id = o.Id,
            SportTeamId = o.SportTeamId,
            Title = o.Title,
            CreatedDate = o.CreatedDate,
            Exercises = o.Exercises,
            FullName = o.ToString()
        };
    }
}
