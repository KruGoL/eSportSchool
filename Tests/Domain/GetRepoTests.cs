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
            => Assert.IsInstanceOfType(GetRepo.Instance<ISportTeamsRepo>(), typeof(SportTeamsRepo));
        [TestMethod]
        public void SetServiceTest() {
            var s = GetRepo.service;
            var x = new testClass();
            GetRepo.SetService(x);
            areEqual(x, GetRepo.service);
            GetRepo.service = s;
        }
    }
}
