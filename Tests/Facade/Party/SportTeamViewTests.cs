using eSportSchool.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportSchool.Tests.Facade.Party
{
    [TestClass]
    public class SportTeamViewTests: SealedClassTests<SportTeamView>
    {
        [TestMethod] public void IdTest() => IsProperty<string>();
        [TestMethod] public void OwnerIdTest() => IsProperty<string?>();
        [TestMethod] public void TitleTest() => IsProperty<string?>();
        [TestMethod] public void CreatedDateTest() => IsProperty<DateTime?>();
        [TestMethod] public void DescriptionTest() => IsProperty<string?>();
        [TestMethod] public void FullNameTest() => IsProperty<string?>();
    }
}
