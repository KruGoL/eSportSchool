using eSportSchool.Data.Party;
using eSportSchool.Domain.Combined;

namespace eSportSchool.Domain.Party
{
    public interface ITrainersRepo : IRepo<Trainer> { }
    public sealed class Trainer:UniqueEntity<TrainerData> 
    {
        public Trainer ():this (new ()){}
        public Trainer(TrainerData d) : base(d) { }

        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public IsoGender Gender => getValue(Data?.Gender);
        public DateTime DoB => getValue(Data?.DoB);
        public string FullName => FirstName + " " + LastName;
        public override string ToString() => $"{FirstName}{LastName}({Gender},{DoB})";

        public List<SportTeam?> SportTeams => GetRepo.Instance<ISportTeamsRepo>()?
                       .GetAll(x => x.OwnerId)?
                       .Where(x => x.OwnerId == Id)?
                       .ToList() ?? new List<SportTeam?>();
        public string SportTeamsCount => SportTeams?.Count.ToString() ?? "Does not coach anyone";
    }
}
