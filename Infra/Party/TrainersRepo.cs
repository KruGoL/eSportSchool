using Microsoft.EntityFrameworkCore;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;

namespace eSportSchool.Infra.Party
{
    public abstract class TrainersRepo : Repo<Trainer, TrainerData>, ITrainersRepo
    {
        public TrainersRepo(eSportSchoolDB db) : base(db, db.Trainers) { }
        protected override Trainer toDomain(TrainerData d) => new (d);
        internal override IQueryable<TrainerData> addFilter(IQueryable<TrainerData> q)
        {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                x => x.FirstName.Contains(y)
                || x.LastName.Contains(y)
                || x.Id.Contains(y)
                || x.DoB.ToString().Contains(y)
                || x.Gender.ToString().Contains(y));
        }
    }
}
