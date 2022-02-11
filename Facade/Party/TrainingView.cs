using System.ComponentModel;
using eSportSchool.Data.Party;
using Microsoft.Build.Framework;

namespace eSportSchool.Facade.Party
{
    public class TrainingView
    {
        [Required] public string Id { get; set; }
        [Required] public string? SportTeamId { get; set; }
        [DisplayName("Workout name")] public string? Title { get; set; }
        [DisplayName("Workout created")] public DateTime? CreatedDate { get; set; }
        [DisplayName("Full name")] public string? FullName { get; set; }
    }
}
