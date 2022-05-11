using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eSportSchool.Facade
{
    public abstract class NamedView : UniqueView
    {
        [DisplayName("Name")] public string? Name { get; set; }
        [DisplayName("Description")] public string? Description { get; set; }
    }
}
