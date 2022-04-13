using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using Microsoft.Build.Framework;
using System.ComponentModel;

namespace eSportSchool.Facade.Party
{
    public sealed class AddressView : UniqueView
    {
        [Required][DisplayName("Street")] public string Street { get; set; }
        [DisplayName("City")] public string? City { get; set; }
        [DisplayName("Region")] public string? Region { get; set; }
        [DisplayName("Zip Code")] public string? ZipCode { get; set; }
        [DisplayName("Country")] public string? Country { get; set; }
    }
    public sealed class AddressViewFactory : BaseViewFactory<AddressView, Address, AddressData>
    {
        protected override Address toEntity(AddressData d) => new (d);
    }
}
