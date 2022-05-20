using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Soft {
    [TestClass]
    public class IsSoftTested : AssemblyTests {
        protected override void isAllTested() => isInconclusive("Namespace has to be changed to \"eSportSchool.Soft\"");

    }
}
