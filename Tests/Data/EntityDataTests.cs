using Microsoft.VisualStudio.TestTools.UnitTesting;
using eSportSchool.Data;

namespace eSportSchool.Tests.Data.Party
{
    [TestClass]
    public class EntityDataTests : PublicClassTests<UniqueData>
    {
        [TestMethod] public void IdTest() => IsProperty<string>();
    }
}
