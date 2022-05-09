
namespace eSportSchool.Data
{
    public abstract class NamedData: UniqueData
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
