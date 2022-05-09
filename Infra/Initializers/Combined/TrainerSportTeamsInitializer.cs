using eSportSchool.Data;
using eSportSchool.Data.Party;

namespace eSportSchool.Infra.Initializers.Combined {
    public sealed class TrainerSportTeamsInitializer : BaseInitializer<TrainerSportTeamData>
    {
        public TrainerSportTeamsInitializer(eSportSchoolDB? db) : base(db, db?.TrainerSportTeams) { }

        protected override IEnumerable<TrainerSportTeamData> getEntities => new[] { createTrainerSportTeam() };

        internal static TrainerSportTeamData createTrainerSportTeam() => new()
        {
            Id = UniqueData.NewId,
            TrainerId = UniqueData.NewId,
            STeamId = UniqueData.NewId,

        };
        
    }
    
}
