using eSportSchool.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Facade.Party
{   [TestClass]
    public class AddressViewTests: SealedClassTests<AddressView>
    {
        [TestMethod] public void IdTest() => IsProperty<string>();
        [TestMethod] public void StreetTest() => IsProperty<string>();
        [TestMethod] public void CityTest() => IsProperty<string?>();
        [TestMethod] public void RegionTest() => IsProperty<string?>();
        [TestMethod] public void ZipCodeTest() => IsProperty<string?>();
        [TestMethod] public void CountryTest() => IsProperty<string?>();

    }
}
