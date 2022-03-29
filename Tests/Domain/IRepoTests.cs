using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace eSportSchool.Tests.Domain
{
    [TestClass]
    public class IRepoTests : InterfaceTests<IRepo<Trainer>> { }

    [TestClass]
    public class IBaseRepoTests : InterfaceTests<IBaseRepo<Trainer>>   { }

}
