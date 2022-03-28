using Microsoft.VisualStudio.TestTools.UnitTesting;
using eSportSchool.Data;

namespace eSportSchool.Tests.Data.Party
{
    [TestClass]
    public class EntityDataTests : PublicClassTests<EntityData>
    {
        [TestMethod] public void IdTest() => IsProperty<string>();
    }
}
