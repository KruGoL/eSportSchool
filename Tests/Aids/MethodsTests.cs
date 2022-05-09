using eSportSchool.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace eSportSchool.Tests.Aids {
    [TestClass] public class MethodsTests : TypeTests {
        MethodInfo[] methods = typeof(MethodsTests).GetMethods(BindingFlags.Public);
        [TestMethod]
        public void HasAttributeTest()
        {
            foreach (var method in methods)
            {
                var x = Methods.HasAttribute<Attribute>(method);
                isTrue(x);
            }
        }
    }
}
