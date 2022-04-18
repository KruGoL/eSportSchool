using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party
{
    public interface ICurrenciesRepo : IRepo<Currency> { }

    public class Currency : NamedEntity<CurrencyData>
    {
        public Currency() : this(new CurrencyData()) { }
        public Currency(CurrencyData d) : base(d) { }
    }
}
