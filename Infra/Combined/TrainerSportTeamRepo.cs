﻿using eSportSchool.Data.Сombined;
using eSportSchool.Domain.Combined;

namespace eSportSchool.Infra.Combined
{
    public class TrainerSportTeamRepo : Repo<TrainerSportTeam, TrainerSportTeamData>, ITrainerSportTeamRepo
    {
        public TrainerSportTeamRepo(eSportSchoolDB? db) : base(db, db?.TrainerSportTeams) { }
        protected override TrainerSportTeam toDomain(TrainerSportTeamData d) => new(d);
        internal override IQueryable<TrainerSportTeamData> addFilter(IQueryable<TrainerSportTeamData> q)
        {
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
