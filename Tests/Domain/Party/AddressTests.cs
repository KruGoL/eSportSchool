using eSportSchool.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Domain.Party
{
    [TestClass]
    public class IAddressRepoTests : InterfaceTests<IAddressRepo> { }

    [TestClass]
    public class AddressTests : SealedClassTests<Address>   { }
}
