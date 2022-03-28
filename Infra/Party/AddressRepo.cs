using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;

namespace eSportSchool.Infra.Party
{
    public class AddressRepo : Repo<Address, AddressData>, IAddressRepo
    {
        public AddressRepo(eSportSchoolDB? db) : base(db, db?.Addresses) { }
        protected override Address toDomain(AddressData d) => new (d);
    }
}
