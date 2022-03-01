using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party
{
    public class Trainer
    {
        private const string _defaultStr = "Undefined";
        private const bool _defaultGender = true;
        private DateTime _defaultDate => DateTime.MinValue;
        private TrainerData _data;

        public Trainer ():this (new TrainerData()){}
        public Trainer(TrainerData d) => _data = d;

        public string Id => _data?.Id ?? _defaultStr;
        public string FirstName => _data?.FirstName ?? _defaultStr;
        public string LastName => _data?.LastName ?? _defaultStr;
        public bool Gender => _data?.Gender ?? _defaultGender;
        public DateTime DoB => _data?.DoB ?? _defaultDate;
        public TrainerData Data => _data;
        public override string ToString() => $"{FirstName}{LastName}({Gender},{DoB})";


    }
}
