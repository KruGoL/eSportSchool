using System.ComponentModel;
using Microsoft.Build.Framework;

namespace eSportSchool.Facade.Party
{
    public class SportTeamView
    {
        [Required] public string Id { get; set; }
        [Required] public string? OwnerId { get; set; }
        [DisplayName("Team name")] public string? Title { get; set; }
        [DisplayName("Team created")] public DateTime? CreatedDate { get; set; }
        [DisplayName("Description")] public string? Description { get; set; }
        [DisplayName("Full name")] public string? FullName { get; set; }
    }
}
