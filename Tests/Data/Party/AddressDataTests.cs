using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using eSportSchool.Data.Party;

namespace eSportSchool.Tests.Data.Party
{
    [TestClass]
    public class AddressDataTests: SealedClassTests<AddressData>
    {
        [TestMethod] public void IdTest() => IsProperty<string>();
        [TestMethod] public void StreetTest() => IsProperty<string?>();
        [TestMethod] public void CityTest() => IsProperty<string?>();
        [TestMethod] public void RegionTest() => IsProperty<string?>();
        [TestMethod] public void ZipCodeTest() => IsProperty<string?>();
        [TestMethod] public void CountryTest() => IsProperty<string?>();

    }
}
