using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eSportSchool.Facade.Party
{
    public sealed class TrainerView: UniqueView
    {
        [DisplayName("First name")] public string? FirstName { get; set; }
        [DisplayName("Last name")] [Required] public string? LastName { get; set; }
        [DisplayName("Gender")] public IsoGender? Gender { get; set; }
        [DisplayName("Date of birth")] public DateTime? DoB { get; set; }
        [DisplayName("Full name")]public string? FullName { get; set; }

    }
    public sealed class TrainerViewFactory : BaseViewFactory<TrainerView, Trainer, TrainerData>
    {
        protected override Trainer toEntity(TrainerData d) => new Trainer(d);
        public override TrainerView Create(Trainer? e)
        {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
}
