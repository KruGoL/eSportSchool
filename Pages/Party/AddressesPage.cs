using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;

namespace eSportSchool.Pages.Party
{
    public class AddressesPage : PagedPage<AddressView, Address, IAddressRepo>
    {
        public AddressesPage(IAddressRepo r) : base(r) { }
        protected override Address toObject(AddressView? item) => new AddressViewFactory().Create(item);
        protected override AddressView toView(Address? entity) => new AddressViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(AddressView.Street),
            nameof(AddressView.City),
            nameof(AddressView.Region),
            nameof(AddressView.ZipCode),
            nameof(AddressView.Country)
        };
    }
}
