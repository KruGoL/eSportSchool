using eSportSchool.Data.Party;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportSchool.Domain.Party
{
    public interface ICurrenciesRepo : IRepo<Currency> { }

    public class Currency : NamedEntity<CurrencyData>
    {
        public Currency() : this(new CurrencyData()) { }
        public Currency(CurrencyData d) : base(d) { }
    }
}
