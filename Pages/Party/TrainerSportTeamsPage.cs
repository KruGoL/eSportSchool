using eSportSchool.Domain.Combined;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Combined;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSportSchool.Pages.Party
{
    public class TrainerSportTeamsPage : PagedPage<TrainerSportTeamView, TrainerSportTeam, ITrainerSportTeamsRepo>
    {
        private readonly ITrainersRepo trainers;
        private readonly ISportTeamsRepo teams;
        public TrainerSportTeamsPage(ITrainerSportTeamsRepo r, ITrainersRepo t, ISportTeamsRepo st) : base(r)
        {
            trainers = t;
            teams = st;
        }
        protected override TrainerSportTeam toObject(TrainerSportTeamView? item) => new TrainerSportTeamViewFactory().Create(item);
        protected override TrainerSportTeamView toView(TrainerSportTeam? entity) => new TrainerSportTeamViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(TrainerSportTeamView.TrainerId),
            nameof(TrainerSportTeamView.STeamId),
        };
        public IEnumerable<SelectListItem> Trainers
            => trainers?.GetAll(x => x.FullName)?
            .Select(x => new SelectListItem(x.FullName, x.Id))
            ?? new List<SelectListItem>();
        public IEnumerable<SelectListItem> SportTeams
            => teams?.GetAll(x => x.Title)?
            .Select(x => new SelectListItem(x.Title, x.Id))
            ?? new List<SelectListItem>();
        public string TrainerName(string? trainerId = null)
            => Trainers?.FirstOrDefault(x => x.Value == (trainerId ?? string.Empty))?.Text ?? "Unspecified";
        public string SportTeamName(string? teamId = null)
            => SportTeams?.FirstOrDefault(x => x.Value == (teamId ?? string.Empty))?.Text ?? "Unspecified";
        public override object? GetValue(string name, TrainerSportTeamView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(TrainerSportTeamView.TrainerId) ? TrainerName(r as string)
                : name == nameof(TrainerSportTeamView.STeamId) ? SportTeamName(r as string)
                : r;
        }

    }
}
