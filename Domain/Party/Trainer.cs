using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party
{
    public class Trainer:Entity<TrainerData> 
    {
        private const string _defaultStr = "Undefined";
        private const bool _defaultGender = true;
        private DateTime _defaultDate => DateTime.MinValue;
        public Trainer ():this (new TrainerData()){}
        public Trainer(TrainerData d) : base(d) { }

        public string Id => Data?.Id ?? _defaultStr;
        public string FirstName => Data?.FirstName ?? _defaultStr;
        public string LastName => Data?.LastName ?? _defaultStr;
        public bool Gender => Data?.Gender ?? _defaultGender;
        public DateTime DoB => Data?.DoB ?? _defaultDate;
        public override string ToString() => $"{FirstName}{LastName}({Gender},{DoB})";


    }
}
