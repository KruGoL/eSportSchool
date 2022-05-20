using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using eSportSchool.Infra;
using eSportSchool.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportSchool.Tests.Infra.Party {
    [TestClass]
    public class KindOfSportRepoTests : SealedRepoTests<KindOfSportRepo, Repo<KindOfSport, KindOfSportData>, KindOfSport, KindOfSportData> {
        protected override KindOfSportRepo createObj() => new (GetRepo.Instance<eSportSchoolDB>());
        protected override object? getSet(eSportSchoolDB db) => db.KindOfSports;
    }
}
