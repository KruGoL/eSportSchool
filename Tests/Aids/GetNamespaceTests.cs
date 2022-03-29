using eSportSchool.Domain.Party;
using eSportSchool.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Aids {
    [TestClass] public class GetNamespaceTests : IsTypeTested 
    {
        [TestMethod]
        public void OfTypeTest()
        {
            Address a = new Address();
            var aOfTypeNamespace = GetNamespace.OfType(a);
            var aNamespace = a.GetType().Namespace;
            areEqual(aNamespace, aOfTypeNamespace);
        }
    }
}
