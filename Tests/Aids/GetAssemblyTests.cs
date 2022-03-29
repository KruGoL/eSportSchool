using eSportSchool.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;

namespace eSportSchool.Tests.Aids {
    [TestClass]
    public class GetAssemblyTests : IsTypeTested
    {
        [TestMethod] public void ByNameTest() {
            var a = Assembly.GetCallingAssembly();
            var name = a.GetName().Name;
            var gName= GetAssembly.ByName(name);
            name += ".dll";
            areEqual(gName, a);
        }
        [TestMethod] public void OfTypeTest()
        {
            var a = Assembly.GetCallingAssembly();
            var aType = GetAssembly.OfType(a);
            areEqual(a.GetType().Assembly,aType);
        }
        [TestMethod]
        public void TypesTest()
        {
            var a = Assembly.GetCallingAssembly();
            var aType = GetAssembly.Types(a);
            var aList = a.GetTypes().ToList();
            CollectionAssert.Equals(aList, aType);
        }
        [TestMethod] public void TypeTest()
        {
            var a = Assembly.GetCallingAssembly();
            var aName = a.GetName().Name;
            var aTypeOfName = GetAssembly.Type(a, aName);
            var aType= a.DefinedTypes.FirstOrDefault(x => x.Name == aName);
            areEqual(aTypeOfName, aType);
        }
    }
}
