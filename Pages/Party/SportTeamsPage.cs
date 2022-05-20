using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSportSchool.Pages.Party {
    //[Authorize]
    public class SportTeamsPage : PagedPage<SportTeamView, SportTeam, ISportTeamsRepo>
    {
        private readonly IKindOfSportRepo sports;
        private readonly ITrainersRepo trainers;
        public SportTeamsPage(ISportTeamsRepo r, IKindOfSportRepo s, ITrainersRepo t) : base(r) {
            sports = s ; trainers = t; 
        }

        protected override SportTeam toObject(SportTeamView? item) => new SportTeamViewFactory().Create(item);
        protected override SportTeamView toView(SportTeam? entity) => new SportTeamViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(SportTeamView.Name),
            nameof(SportTeamView.SportId),
            nameof(SportTeamView.OwnerId),
            nameof(SportTeamView.CreatedDate),
        };
        public IEnumerable<SelectListItem> Sports
           => sports?.GetAll(x => x.Name)?
           .Select(x => new SelectListItem(x.Name, x.Id))
           ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> Trainers
           => trainers?.GetAll(x => x.FullName)?
           .Select(x => new SelectListItem(x.FullName, x.Id))
           ?? new List<SelectListItem>();

        public string SportName(string? sportId = null)
            => Sports?.FirstOrDefault(x => x.Value == (sportId ?? string.Empty))?.Text ?? "Unspecified";
        public string TrainerName(string? trainerId = null)
            => Trainers?.FirstOrDefault(x => x.Value == (trainerId ?? string.Empty))?.Text ?? "Unspecified";

        public override object? GetValue(string name, SportTeamView v)
        {         
            var r = base.GetValue(name, v);
            if (name == nameof(SportTeamView.SportId))
            {
                return SportName(r as string);
            }
            else if (name == nameof(SportTeamView.OwnerId))
            {
                return TrainerName(r as string);
            }
            else return r;
        }
    }
}
