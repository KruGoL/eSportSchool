

namespace eSportSchool.Data.Party
{
    public sealed class AddressData: UniqueData
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
    }
}
