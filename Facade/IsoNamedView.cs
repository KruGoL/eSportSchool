using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eSportSchool.Facade.Party
{
    public abstract class IsoNamedView : NamedView
    {
        [Required][DisplayName("ISO three letter code")] public string? Code { get; set; }
        [DisplayName("English name")] public new string? Name { get; set; }
        [DisplayName("Native name")] public new string? Description { get; set; }
    }
}
