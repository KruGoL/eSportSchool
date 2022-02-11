using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
