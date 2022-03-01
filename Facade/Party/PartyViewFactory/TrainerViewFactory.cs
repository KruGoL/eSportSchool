
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;

namespace eSportSchool.Facade.Party.PartyViewFactory
{
    public class TrainerViewFactory
    {
        public Trainer Create(TrainerView v) => new(new TrainerData() {
            Id = v.Id,
            DoB = v.DoB,
            Gender = v.Gender,
            FirstName = v.FirstName,
            LastName = v.LastName
        });
    
        public TrainerView Create(Trainer o)=> new() {
            Id = o.Id,
            DoB = o.DoB,
            Gender = o.Gender,
            FirstName = o.FirstName,
            LastName = o.LastName,
            FullName = o.ToString(),
        };
    
    }
}
