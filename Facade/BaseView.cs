using Microsoft.Build.Framework;

namespace eSportSchool.Facade
{
    public abstract class BaseView
    {
        [Required] public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
