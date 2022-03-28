using eSportSchool.Data.Party;

namespace eSportSchool.Infra.Initializers
{
    public class SportTeamsInitializer : BaseInitializer<SportTeamData>
    {
        public SportTeamsInitializer(eSportSchoolDB? db) : base(db, db?.SportTeams) { }
        internal static SportTeamData createSportTeam(string ownerId, string title, string description, DateTime createdDate)
        {
            var sportTeam = new SportTeamData
            {
                Id = title + ownerId,
                OwnerId = ownerId,
                Title = title,
                Description = description,
                CreatedDate = createdDate
            };
            return sportTeam;
        }
        protected override IEnumerable<SportTeamData> getEntities => new[] {
            createSportTeam("TrainerId_1","SuperTeam","Never Lose",new DateTime(1888, 09, 19) ),
            createSportTeam("TrainerId_2","MiddleTeam","Lose +-",new DateTime(2010, 09, 19)),
            createSportTeam("TrainerId_3","LowTeam","Always Lose",new DateTime(2020, 09, 19)),
        };
    }
}