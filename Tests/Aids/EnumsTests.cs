using eSportSchool.Aids;
using eSportSchool.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Aids {
    [TestClass] public class EnumsTests : IsTypeTested {
        [TestMethod]
        public void DescriptionTest()
         => areEqual("Not applicable", Enums.Description(IsoGender.NotApplicable));
        [TestMethod]
        public void ToStringTest()
              => areEqual("NotApplicable", IsoGender.NotApplicable.ToString());
    }
}
