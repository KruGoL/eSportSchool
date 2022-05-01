using Microsoft.VisualStudio.TestTools.UnitTesting;
using eSportSchool.Data;

namespace eSportSchool.Tests.Data {
    [TestClass]
    public class NamedDataTests : AbstractClassTests {
        private class testClass : NamedData { }
        protected override object createObj() => new testClass();
       // [TestMethod] public void CodeTest() => IsProperty<string>();
        [TestMethod] public void NameTest() => IsProperty<string?>();
        [TestMethod] public void DescriptionTest() => IsProperty<string?>();
    }
}
