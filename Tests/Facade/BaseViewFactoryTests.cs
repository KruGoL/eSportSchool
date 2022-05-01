using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade;
using eSportSchool.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Facade
{
    [TestClass]
    public class BaseViewFactoryTests : AbstractClassTests
    {
        private class testClass : BaseViewFactory<TrainerView, Trainer, TrainerData>
        {
            protected override Trainer toEntity(TrainerData d) => new Trainer(d);
        }
        protected override object createObj() => new testClass();
    }
}
