using eSportSchool.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Infra {
    [TestClass]
    public class eSportSchoolDBTests : SealedBaseTests<eSportSchoolDB, DbContext> {
        protected override eSportSchoolDB createObj() => null;
        protected override void isSealedTest() => isInconclusive();

    }
}

