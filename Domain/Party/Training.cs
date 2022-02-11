
using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party
{
    public class Training
    {
        private const string _defaultStr = "Undefined";
        private DateTime _defaultDate => DateTime.Now;
        private TrainingData _data;
        
        public Training() : this(new TrainingData()) { }
        public Training(TrainingData d) => _data = d;
        public TrainingData Data => _data;

        public string Id => _data?.Id ?? _defaultStr;
        public string SportTeamId => _data?.SportTeamId ?? _defaultStr;
        public string Title => _data?.Title ?? _defaultStr;
        public DateTime CreatedDate => _data?.CreatedDate ?? _defaultDate;
        public override string ToString() => $"{Title} ({CreatedDate})";
    }
}
