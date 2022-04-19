using eSportSchool.Data.Party;
using eSportSchool.Domain.Combined;

namespace eSportSchool.Domain.Party
{
    public interface ITrainersRepo : IRepo<Trainer> { }
    public sealed class Trainer:UniqueEntity<TrainerData> 
    {
        public Trainer ():this (new TrainerData()){}
        public Trainer(TrainerData d) : base(d) { }

        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public IsoGender Gender => getValue(Data?.Gender);
        public DateTime DoB => getValue(Data?.DoB);
        public string FullName => FirstName + " " + LastName;
        public override string ToString() => $"{FirstName}{LastName}({Gender},{DoB})";

        public List<TrainerSportTeam> TrainerSportTeams
           => GetRepo.Instance<ITrainerSportTeamRepo>()?
           .GetAll(x => x.TrainerId)?
           .Where(x => x.TrainerId == Id)?
           .ToList() ?? new List<TrainerSportTeam>();

        public List<SportTeam?> SportTeams
            => TrainerSportTeams
            .Select(x => x.SportTeam)
            .ToList() ?? new List<SportTeam?>();
    }
}
