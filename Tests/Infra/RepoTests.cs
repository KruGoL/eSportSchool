using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Infra
{
    [TestClass]
    public class RepoTests : AbstractClassTests
    {
        private class testClass : Repo<Address, AddressData>
        {
            public testClass(DbContext? c, DbSet<AddressData>? s) : base(c, s)
            {
            }

            protected override Address toDomain(AddressData d) => new(d);
        }
        protected override object createObj() => new testClass(null, null);
    }
}
