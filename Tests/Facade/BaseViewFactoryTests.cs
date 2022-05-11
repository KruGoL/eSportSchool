using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade;
using eSportSchool.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Facade {
    [TestClass]
    public class BaseViewFactoryTests : AbstractClassTests<BaseViewFactory<TrainerView, Trainer, TrainerData>, object> {
        private class testClass : BaseViewFactory<TrainerView, Trainer, TrainerData> {
            protected override Trainer toEntity(TrainerData d) => new(d);
        }
        protected override BaseViewFactory<TrainerView, Trainer, TrainerData> createObj() => new testClass();

        [TestMethod] public void CreateTest() { }
        [TestMethod]
        public void CreateViewTest() {
            var v = GetRandom.Value<TrainerView>();
            var o = obj.Create(v);
            areEqualProperties(v, o.Data);
        }
        [TestMethod]
        public void CreateObjectTest() {
            var d = GetRandom.Value<TrainerData>();
            var v = obj.Create(new Trainer(d));
            areEqualProperties(d, v);
        }
    }
}