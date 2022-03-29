using eSportSchool.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Domain.Party
{
    [TestClass]
    public class ISportTeamsRepoTests : InterfaceTests<ISportTeamsRepo> { }

    [TestClass]
    public class SportTeamTests : SealedClassTests<SportTeam> { }
}
