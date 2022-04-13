using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party
{
    public interface ITrainersRepo : IRepo<Trainer> { }
    public sealed class Trainer:UniqueEntity<TrainerData> 
    {
        public Trainer ():this (new TrainerData()){}
        public Trainer(TrainerData d) : base(d) { }

        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public bool Gender => getValue(Data?.Gender);
        public DateTime DoB => getValue(Data?.DoB);
        public override string ToString() => $"{FirstName}{LastName}({Gender},{DoB})";


    }
}
