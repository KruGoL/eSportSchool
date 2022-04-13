using System.ComponentModel;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using Microsoft.Build.Framework;

namespace eSportSchool.Facade.Party
{
    public sealed class SportTeamView : UniqueView
    {
        [Required] public string? OwnerId { get; set; }
        [DisplayName("Team name")] public string? Title { get; set; }
        [DisplayName("Team created")] public DateTime? CreatedDate { get; set; }
        [DisplayName("Description")] public string? Description { get; set; }
        [DisplayName("Full name")] public string? FullName { get; set; }
    }
    public sealed class SportTeamViewFactory : BaseViewFactory<SportTeamView, SportTeam, SportTeamData>
    {
        protected override SportTeam toEntity(SportTeamData d) => new(d);
        public override SportTeamView Create(SportTeam? e)
        {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
}
