using eSportSchool.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Facade
{
    [TestClass]
    public class BaseViewTests : AbstractClassTests
    {
        protected override object createObj() => new testClass();

        private class testClass: UniqueView { }
    }
}
