
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;

namespace eSportSchool.Facade.Party.PartyViewFactory
{
    public class SportTeamViewFactory
    {
        public SportTeam Create(SportTeamView v)=>new( new SportTeamData()
        {
            Id = v.Id,
            OwnerId = v.OwnerId,
            Title = v.Title,
            CreatedDate = v.CreatedDate,
            Description = v.Description
        });

        public SportTeamView Create(SportTeam o) => new()
        {
            Id = o.Id,
            OwnerId = o.OwnerId,
            Title = o.Title,
            CreatedDate = o.CreatedDate,
            Description = o.Description,
            FullName = o.ToString()
        };

    }
}

