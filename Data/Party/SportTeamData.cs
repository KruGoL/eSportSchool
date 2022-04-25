
using System.ComponentModel.DataAnnotations;

namespace eSportSchool.Data.Party
{
    public sealed class SportTeamData : UniqueData
    {
        public string? OwnerId { get; set; }
        public string? Title { get; set; }
        public string? SportId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Description { get; set; }

    }
}
