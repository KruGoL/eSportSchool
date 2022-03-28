using eSportSchool.Data.Party;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportSchool.Domain.Party
{
    public interface IAddressRepo : IRepo<Address> { }
    public sealed class Address: Entity<AddressData>
    {
        public Address(): this(new AddressData()) { }
        public Address(AddressData d) : base(d) { }
        public string Street => getValue(Data?.Street);
        public string City => getValue(Data?.City);
        public string Region => getValue(Data?.Region);
        public string ZipCode => getValue(Data?.ZipCode);
        public string Country => getValue(Data?.Country);
    }
}
