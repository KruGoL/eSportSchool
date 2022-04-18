using eSportSchool.Data.Сombined;
using eSportSchool.Domain.Combined;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eSportSchool.Facade.Combined
{
    public class TrainerSportTeamView : UniqueView
    {
        [Required][DisplayName("Trainer")] public string TrainerId { get; set; } = string.Empty;
        [Required][DisplayName("Sport team")] public string STeamId { get; set; } = string.Empty;
        [DisplayName("Full name")] public string? FullName { get; set; }
    }
    public sealed class TrainerSportTeamViewFactory : BaseViewFactory<TrainerSportTeamView, TrainerSportTeam, TrainerSportTeamData>
    {
        protected override TrainerSportTeam toEntity(TrainerSportTeamData d) => new(d);
        public override TrainerSportTeamView Create(TrainerSportTeam? e)
        {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
    
}
