using eSportSchool.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace eSportSchool.Tests.Data.Party
{
    [TestClass]
    public class SportTeamDataTests: SealedClassTests<SportTeamData>
    {
        [TestMethod] public void IdTest() => IsProperty<string>();
        [TestMethod] public void OwnerIdTest() => IsProperty<string?>();
        [TestMethod] public void TitleTest() => IsProperty<string?>();
        [TestMethod] public void CreatedDateTest() => IsProperty<DateTime?>();
        [TestMethod] public void DescriptionTest() => IsProperty<string?>();
    }
}
