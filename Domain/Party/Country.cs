using eSportSchool.Data.Party;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportSchool.Domain.Party
{
    public interface ICountriesRepo : IRepo<Country> { }

    public class Country : NamedEntity<CountryData>
    {
        public Country() : this(new CountryData()) { }
        public Country(CountryData d) : base(d) { }
    

    }
}
