
using System.ComponentModel.DataAnnotations;

namespace eSportSchool.Data.Party
{
    public sealed class SportTeamData : NamedData
    {
        public string? OwnerId { get; set; }
        public string? SportId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
