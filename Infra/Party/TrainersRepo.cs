using Microsoft.EntityFrameworkCore;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;

namespace eSportSchool.Infra.Party
{
    public class TrainersRepo : Repo<Trainer, TrainerData>, ITrainersRepo
    {
        public TrainersRepo(eSportSchoolDB db) : base(db, db.Trainers) { }
        protected override Trainer toDomain(TrainerData d) => new (d);
    }
}
