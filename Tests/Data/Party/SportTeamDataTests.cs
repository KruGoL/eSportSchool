using eSportSchool.Data;
using eSportSchool.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace eSportSchool.Tests.Data.Party
{
    [TestClass]
    public class SportTeamDataTests : SealedClassTests<SportTeamData, NamedData>
    {
        [TestMethod] public void OwnerIdTest() => isProperty<string?>();
        [TestMethod] public void SportIdTest() => isProperty<string?>();
        [TestMethod] public void CreatedDateTest() => isProperty<DateTime?>();
    }
}
