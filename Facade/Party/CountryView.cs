using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportSchool.Facade.Party
{
    public sealed class CountryView : IsoNamedView
    {
    }
    public sealed class CountryViewFactory : BaseViewFactory<CountryView, Country, CountryData>
    {
        protected override Country toEntity(CountryData d) => new(d);
    }
}
