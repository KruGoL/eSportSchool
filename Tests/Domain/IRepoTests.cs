using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace eSportSchool.Tests.Domain
{
    [TestClass]
    public class IRepoTests : TestAsserts
    {
        [TestMethod] public void IsInterface() => isTrue(typeof(IRepo<Trainer>)?.IsInterface ?? false);
 
    }

    [TestClass]
    public class IBaseRepoTests : TestAsserts
    {
        [TestMethod] public void IsInterface() => isTrue(typeof(IBaseRepo<Trainer>)?.IsInterface ?? false);

    }

}
