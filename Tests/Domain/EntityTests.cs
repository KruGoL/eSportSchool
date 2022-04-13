using eSportSchool.Data.Party;
using eSportSchool.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Domain
{
    [TestClass]
    public abstract class EntityTests : AbstractClassTests
    {
        private class testEntity : UniqueEntity { }
        protected override object createObj() => new testEntity();
        
        
    }
    [TestClass]
    public abstract class EntityTDataTests : AbstractClassTests
    {
        private class testClass : UniqueEntity<AddressData> { }
        protected override object createObj() => new testClass();
    }
}
