using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Infra;
using eSportSchool.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportSchool.Tests.Infra.Initializers {
    [TestClass] public class KindOfSportInitializerTests : SealedBaseTests<KindOfSportInitializer, BaseInitializer<KindOfSportData>> {
        protected override KindOfSportInitializer createObj() {
            var db = GetRepo.Instance<eSportSchoolDB>();
            return new KindOfSportInitializer(db);
        }
    }
}
