using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;

namespace eSportSchool.Facade.Party
{
    public sealed class SportTeamView : NamedView
    {
        [Required][DisplayName("Trainer name")] public string? OwnerId { get; set; }
        [DisplayName("Trainer name")] public string? OwnerName { get; set; }
        [DisplayName("Kind of sport")] public string? SportId { get; set; }
        [DisplayName("Kind of sport")] public string? SportName { get; set; }

        [DisplayName("Team created")][DataType(DataType.Date)] public DateTime? CreatedDate { get; set; }
        [DisplayName("Full name")] public string? FullName { get; set; }
    }
    public sealed class SportTeamViewFactory : BaseViewFactory<SportTeamView, SportTeam, SportTeamData>
    {
        protected override SportTeam toEntity(SportTeamData d) => new(d);
        public override SportTeamView Create(SportTeam? e)
        {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            v.CreatedDate = e?.CreatedDate;
            return v;
        }
    }
}
