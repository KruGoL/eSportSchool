using Microsoft.VisualStudio.TestTools.UnitTesting;
using eSportSchool.Data;

namespace eSportSchool.Tests.Data {
    [TestClass]
    public class UniqueDataTests : AbstractClassTests {
        private class testClass : UniqueData { }
        protected override object createObj() => new testClass();
        [TestMethod]
        public void NewIdTest() {
            isNotNull(UniqueData.NewId);
            areNotEqual(UniqueData.NewId, UniqueData.NewId);
            var pi = typeof(UniqueData).GetProperty(nameof(UniqueData.NewId));
            isFalse(pi?.CanWrite);
        }
        [TestMethod] public void IdTest() => IsProperty<string>();
    }
}
