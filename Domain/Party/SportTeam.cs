using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party {
    public interface ISportTeamsRepo : IRepo<SportTeam> { }
    public sealed class SportTeam : NamedEntity<SportTeamData>
    {

        public SportTeam():this(new SportTeamData()){}
        public SportTeam(SportTeamData d) : base(d){}

        public string OwnerId => getValue(Data?.OwnerId);
        public string SportId => getValue(Data?.SportId);
        public DateTime CreatedDate => getValue(Data?.CreatedDate);
        public override string ToString() => $"{Name} : {KindOfSport?.Name} ({CreatedDate})";

        // public KindOfSport? KindOfSport { get; set; }

        //public KindOfSport? KindOfSport => GetRepo.Instance<IKindOfSportRepo>()?
        //    .GetAll(x => x.Id)?
        //    .Where(x => x.Id == SportId).FirstOrDefault();
        public KindOfSport? KindOfSport => GetRepo.Instance<IKindOfSportRepo>()?.Get(SportId);
        //public List<TrainerSportTeam> TrainerSportTeams
        //    => GetRepo.Instance<ITrainerSportTeamsRepo>()?
        //    .GetAll(x => x.STeamId)?
        //    .Where(x => x.STeamId == Id)?
        //    .ToList() ?? new List<TrainerSportTeam>();
        //public List<Trainer?> Trainers
        //    => TrainerSportTeams
        //    .Select(x => x.Trainer)
        //    .ToList() ?? new List<Trainer?>();
        //public List<Trainer> Trainers => GetRepo.Instance<ITrainersRepo>()?
        //    .GetAll(x => x.Id)?
        //    .Where(x => x.Id == OwnerId)?
        //    .ToList() ?? new List<Trainer>();
        public string? SportName => KindOfSport?.Name ?? "Unknown";
    }
}
