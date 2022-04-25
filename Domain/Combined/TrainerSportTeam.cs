using eSportSchool.Data.Сombined;
using eSportSchool.Domain.Party;

namespace eSportSchool.Domain.Combined
{
    public interface ITrainerSportTeamsRepo : IRepo<TrainerSportTeam> { }
    public class TrainerSportTeam : UniqueEntity<TrainerSportTeamData>
    {
        public TrainerSportTeam() : this(new()) { }
        public TrainerSportTeam(TrainerSportTeamData d) : base(d) { }
        public string TrainerId => getValue(Data?.TrainerId);
        public string STeamId => getValue(Data?.STeamId);
        public Trainer? Trainer => GetRepo.Instance<ITrainersRepo>()?.Get(TrainerId);
        public SportTeam? SportTeam => GetRepo.Instance<ISportTeamsRepo>()?.Get(STeamId);
    }
}
