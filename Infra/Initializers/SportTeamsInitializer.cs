using eSportSchool.Data;
using eSportSchool.Data.Party;

namespace eSportSchool.Infra.Initializers
{
    public class SportTeamsInitializer : BaseInitializer<SportTeamData>
    {
        public SportTeamsInitializer(eSportSchoolDB? db) : base(db, db?.SportTeams) { }
        internal static SportTeamData createSportTeam(string ownerId, string title, string sportId, string description, DateTime createdDate)
        {
            var sportTeam = new SportTeamData
            {
                Id = UniqueData.NewId,
                OwnerId = ownerId,
                Title = title,
                SportId = sportId,
                Description = description,
                CreatedDate = createdDate
            };
            return sportTeam;
        }
        protected override IEnumerable<SportTeamData> getEntities => new[] {
            createSportTeam("TrainerId_1","SuperTeam","BaseBall","Never Lose",new DateTime(1888, 09, 19) ),
            createSportTeam("TrainerId_2","MiddleTeam","Run","Lose +-",new DateTime(2010, 09, 19)),
            createSportTeam("TrainerId_3","LowTeam","Hockey","Always Lose",new DateTime(2020, 09, 19)),
        };
    }
}