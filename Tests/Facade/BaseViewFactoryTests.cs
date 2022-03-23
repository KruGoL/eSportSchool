using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade;
using eSportSchool.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSportSchool.Tests.Facade
{
    [TestClass]
    public class BaseViewFactoryTests : AbstractClassTests
    {
        private class testClass : BaseViewFactory<AddressView, Address, AddressData>
        {
            protected override Address toEntity(AddressData d) => new Address(d);
        }
        protected override object createObj() => new testClass();
    }
}
