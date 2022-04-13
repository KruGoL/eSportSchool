using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;

namespace eSportSchool.Pages.Party
{
    public class CountriesPage : PagedPage<CountryView, Country, ICountriesRepo>
    {
        public CountriesPage(ICountriesRepo r) : base(r) { }
        protected override Country toObject(CountryView? item) => new CountryViewFactory().Create(item);
        protected override CountryView toView(Country? entity) => new CountryViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CountryView.Id),
            nameof(CountryView.Code),
            nameof(CountryView.Name),
            nameof(CountryView.Description)
        };
    }
}
