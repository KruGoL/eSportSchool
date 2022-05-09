using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;

namespace eSportSchool.Infra.Party {
    public class TrainerSportTeamsRepo : Repo<TrainerSportTeam, TrainerSportTeamData>, ITrainerSportTeamsRepo {
        public TrainerSportTeamsRepo(eSportSchoolDB? db) : base(db, db?.TrainerSportTeams) { }
        protected override TrainerSportTeam toDomain(TrainerSportTeamData d) => new(d);
        internal override IQueryable<TrainerSportTeamData> addFilter(IQueryable<TrainerSportTeamData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                x => x.Id.Contains(y)
                || x.TrainerId.Contains(y)
                || x.STeamId.Contains(y)
            );
        }
    }

}
