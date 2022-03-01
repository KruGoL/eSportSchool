using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using eSportSchool.Data.Party;

namespace eSportSchool.Tests.Data.Party
{
    [TestClass]
    public class TrainerDataTests: BaseTests<TrainerData>
    {
        [TestMethod] public void IdTest() => IsProperty<string>();
        [TestMethod] public void FirstNameTest() => IsProperty<string?>();
        [TestMethod] public void LastNameTest() => IsProperty<string?>();
        [TestMethod] public void GenderTest() => IsProperty<bool?>();
        [TestMethod] public void DoBTest() => IsProperty<DateTime?>();
    }
}
