using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade;
using eSportSchool.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportSchool.Tests.Facade.Party {
    [TestClass]
    public class SportTeamViewTests : SealedClassTests<SportTeamView, NamedView> {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void OwnerIdTest() => isProperty<string?>();
        [TestMethod] public void OwnerNameTest() => isProperty<string?>();
        [TestMethod] public void SportIdTest() => isProperty<string?>();
        [TestMethod] public void NameTest() => isProperty<string?>();
        [TestMethod] public void CreatedDateTest() => isProperty<DateTime?>();
        [TestMethod] public void DescriptionTest() => isProperty<string?>();
        [TestMethod] public void FullNameTest() => isProperty<string?>();
    }
}
