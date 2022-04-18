using eSportSchool.Domain.Party;
using eSportSchool.Domain.Sport;
using eSportSchool.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSportSchool.Pages.Party
{
    public class SportTeamsPage : PagedPage<SportTeamView, SportTeam, ISportTeamsRepo>
    {
        private readonly IKindOfSportRepo sports;
        public SportTeamsPage(ISportTeamsRepo r , IKindOfSportRepo s) : base(r) => sports = s;

        protected override SportTeam toObject(SportTeamView? item) => new SportTeamViewFactory().Create(item);
        protected override SportTeamView toView(SportTeam? entity) => new SportTeamViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(SportTeamView.Id),
            nameof(SportTeamView.OwnerId),
            nameof(SportTeamView.Title),
            nameof(SportTeamView.SportId),
            nameof(SportTeamView.CreatedDate),
            nameof(SportTeamView.Description),
            nameof(SportTeamView.FullName)
        };
        public IEnumerable<SelectListItem> Sports
           => sports?.GetAll(x => x.Name)?
           .Select(x => new SelectListItem(x.Name, x.Id))
           ?? new List<SelectListItem>();

        public string SportName(string? sportId = null)
            => Sports?.FirstOrDefault(x => x.Value == (sportId ?? string.Empty))?.Text ?? "Unspecified";

        public override object? GetValue(string name, SportTeamView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(SportTeamView.SportId) ? SportName(r as string) : r;
        }
    }
}
