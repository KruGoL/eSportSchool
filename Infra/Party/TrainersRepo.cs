using Microsoft.EntityFrameworkCore;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;

namespace eSportSchool.Infra.Party
{
    public class TrainersRepo : Repo<Trainer, TrainerData>, ITrainersRepo
    {
        public TrainersRepo(DbContext c, DbSet<TrainerData> s) : base(c, s) { }
        protected override Trainer toDomain(TrainerData d) => new Trainer(d);
    }
}
