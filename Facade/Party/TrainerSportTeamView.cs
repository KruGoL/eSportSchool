using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eSportSchool.Facade.Party {
    public class TrainerSportTeamView : UniqueView {
        [Required][DisplayName("Trainer")] public string TrainerId { get; set; } = string.Empty;
        [Required][DisplayName("Sport team")] public string STeamId { get; set; } = string.Empty;
    }
    public sealed class TrainerSportTeamViewFactory : BaseViewFactory<TrainerSportTeamView, TrainerSportTeam, TrainerSportTeamData> {
        protected override TrainerSportTeam toEntity(TrainerSportTeamData d) => new(d);
    }

}
