using eSportSchool.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Facade {
    [TestClass]
    public class NamedViewTests : AbstractClassTests<NamedView, UniqueView> {
        private class testClass : NamedView { }
        protected override NamedView createObj() => new testClass();
        [TestMethod] public void NameTest() => isDisplayNamed<string?>("Name");
        [TestMethod] public void DescriptionTest() => isDisplayNamed<string?>("Description");
    }
}
