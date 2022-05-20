﻿using eSportSchool.Aids;
using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party {
    public interface ITrainersRepo : IRepo<Trainer> { }
    public sealed class Trainer : UniqueEntity<TrainerData> {
        public Trainer() : this(new()) { }
        public Trainer(TrainerData d) : base(d) { }

        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public IsoGender Gender => getValue(Data?.Gender);
        public DateTime DoB => getValue(Data?.DoB);
        public string ImgPath => getValue(Data?.ImgPath);
        public string FullName => FirstName + " " + LastName;
        public override string ToString() => $"{FirstName} {LastName} ({Gender.Description()}, {DoB})";
        public List<TrainerSportTeam> TrainerSportTeams
            => GetRepo.Instance<ITrainerSportTeamsRepo>()?
            .GetAll(x => x.TrainerId)?
            .Where(x => x.TrainerId == Id)?
            .ToList() ?? new List<TrainerSportTeam>();
        //public List<SportTeam?> SportTeams
        //    => TrainerSportTeams
        //    .Select(x => x.SportTeam)
        //    .ToList() ?? new List<SportTeam?>();
        public List<SportTeam> SportTeams => GetRepo.Instance<ISportTeamsRepo>()?
            .GetAll(x => x.OwnerId)?
            .Where(x => x.OwnerId == Id)?
            .ToList() ?? new List<SportTeam>();
        public string KindOfSport {
            get {
                string? k = null;
                foreach (SportTeam team in SportTeams) {
                    if (k != team.KindOfSport?.Name) k += team.KindOfSport?.Name;
                }
                if (k == null) return "Not known yet";
                return k;
            }
        }

        public string SportTeamsCount => SportTeams?.Count.ToString() ?? "Does not coach anyone";
    }
}
