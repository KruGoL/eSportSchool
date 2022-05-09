using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade;
using eSportSchool.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Facade {
    [TestClass]
    public class BaseViewFactoryTests : AbstractClassTests<BaseViewFactory<SportTeamView, SportTeam, SportTeamData>, object> {
        private class testClass : BaseViewFactory<SportTeamView, SportTeam, SportTeamData> {
            protected override SportTeam toEntity(SportTeamData d) => new(d);
        }
        protected override BaseViewFactory<SportTeamView, SportTeam, SportTeamData> createObj() => new testClass();
    }
}