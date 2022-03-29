using eSportSchool.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace eSportSchool.Tests.Domain.Party
{
    [TestClass]
    public class ITrainersRepoTests : InterfaceTests<ITrainersRepo> { }

    [TestClass]
    public class TrainerTests : SealedClassTests<Trainer> { }
}
