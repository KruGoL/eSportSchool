using eSportSchool.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace eSportSchool.Tests.Aids {
    [TestClass]
    public class GetAssemblyTests : IsTypeTested
    {
        [TestMethod] public void ByNameTest() {
            var name = Assembly.GetCallingAssembly().GetName().Name;
            var gName= GetAssembly.ByName(name);
            name += ".dll";
            areEqual(gName.ManifestModule.Name, name);
        }
        [TestMethod] public void OfTypeTest()
        {
            var a = Assembly.GetCallingAssembly();
            var aType = GetAssembly.OfType(a);
            areEqual(a.GetType().Assembly,aType);
        }
        [TestMethod] public void TypesTest() => isInconclusive();
        [TestMethod] public void TypeTest() => isInconclusive();
    }
}
