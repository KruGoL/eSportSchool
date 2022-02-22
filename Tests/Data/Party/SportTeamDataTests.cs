using eSportSchool.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportSchool.Tests.Data.Party
{
    [TestClass]
    public class SportTeamDataTests: BaseTests<SportTeamData>
    {
        [TestMethod] public void IdTest() => IsProperty<string>();
        [TestMethod] public void OwnerIdTest() => IsProperty<string?>();
        [TestMethod] public void TitleTest() => IsProperty<string?>();
        [TestMethod] public void CreatedDateTest() => IsProperty<DateTime?>();
        [TestMethod] public void DescriptionTest() => IsProperty<string?>();
    }
}
