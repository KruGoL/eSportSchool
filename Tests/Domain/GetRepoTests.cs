using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using eSportSchool.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace eSportSchool.Tests.Domain {
    [TestClass]
    public class GetRepoTests : TypeTests {
        private class testClass : IServiceProvider {
            public object? GetService(Type serviceType) {
                throw new NotImplementedException();
            }
        }
        [TestMethod]
        public void InstanceTest()
            => Assert.IsInstanceOfType(GetRepo.Instance<IKindOfSportRepo>(), typeof(KindOfSportRepo));
        [TestMethod]
        public void SetServiceTest() {
            var x = new testClass();
            GetRepo.SetService(x);
            areEqual(x, GetRepo.service);
        }
    }
}
