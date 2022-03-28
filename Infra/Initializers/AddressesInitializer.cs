using eSportSchool.Data.Party;

namespace eSportSchool.Infra.Initializers
{
    public class AddressesInitializer : BaseInitializer<AddressData>
    {

        public AddressesInitializer(eSportSchoolDB? db) : base(db, db?.Addresses) { }
    protected override IEnumerable<AddressData> getEntities => new[] {
            createAddress("4 Privet Drive", "Little Whinging", "Surrey", "LW41 1AB", "GB"),
            createAddress("Heathgate at Meadway", "Hampstead Garden Suburb", "London", "NW11 7GH", "GB"),
            createAddress("The Burrow", "Ottery St Catchpole", "Devon", "DE17 5BB", "GB"),
            createAddress("School of Witchcraft and Wizardry", "Hogwarts", "Hogsmeade", "HO29 9XX", "GB"),
        };
    internal static AddressData createAddress(string street, string city, string region, string zipCode, string country)
    {
        var address = new AddressData
        {
            Id = street,
            Street = street,
            City = city,
            Region = region,
            ZipCode = zipCode,
            Country = country
        };
        return address;
    }
}
}
