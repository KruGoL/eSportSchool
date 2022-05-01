using eSportSchool.Domain.Party;
using eSportSchool.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eSportSchool.Data.Party;

namespace eSportSchool.Tests.Aids {
    [TestClass] public class GetNamespaceTests : IsTypeTested 
    {
        [TestMethod]
        public void OfTypeTest()
        {
            var obj = new TrainerData();
            var name = obj.GetType().Namespace;
            var n = GetNamespace.OfType(obj);
            areEqual(name, n);
        }
        [TestMethod]
        public void OfTypeNullTest() {
            TrainerData? obj = null;
            var n = GetNamespace.OfType(obj);
            areEqual(string.Empty, n);
        }
    }
}
