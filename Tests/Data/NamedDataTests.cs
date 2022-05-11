using Microsoft.VisualStudio.TestTools.UnitTesting;
using eSportSchool.Data;

namespace eSportSchool.Tests.Data {
    [TestClass]
    public class NamedDataTests : AbstractClassTests<NamedData, UniqueData> {
        private class testClass : NamedData { }
        protected override NamedData createObj() => new testClass();
        [TestMethod] public void NameTest() => isProperty<string?>();
        [TestMethod] public void DescriptionTest() => isProperty<string?>();
    }
}
