using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;

namespace eSportSchool.Pages
{
    public class SportTeamsPage : BasePage<SportTeamView, SportTeam, ISportTeamsRepo>
    {
        public SportTeamsPage(ISportTeamsRepo r) : base(r) {}

        protected override SportTeam toObject(SportTeamView? item) => new SportTeamViewFactory().Create(item);

        protected override SportTeamView toView(SportTeam? entity) => new SportTeamViewFactory().Create(entity);
    }
}
