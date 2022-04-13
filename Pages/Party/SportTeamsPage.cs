using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;

namespace eSportSchool.Pages.Party
{
    public class SportTeamsPage : PagedPage<SportTeamView, SportTeam, ISportTeamsRepo>
    {
        public SportTeamsPage(ISportTeamsRepo r) : base(r) { }

        protected override SportTeam toObject(SportTeamView? item) => new SportTeamViewFactory().Create(item);

        protected override SportTeamView toView(SportTeam? entity) => new SportTeamViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(SportTeamView.Id),
            nameof(SportTeamView.OwnerId),
            nameof(SportTeamView.Title),
            nameof(SportTeamView.CreatedDate),
            nameof(SportTeamView.Description),
            nameof(SportTeamView.FullName)
        };
    }
}
