using eSportSchool.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace eSportSchool.Tests.Aids {
    [TestClass] public class SafeTests : TypeTests {
        private int expected;
        private int def;
        [TestInitialize]
        public void Init() {
            expected = GetRandom.Int32();
            def = GetRandom.Int32();
        }
        [TestMethod]
        public void RunFuncTest() {
            var actual = Safe.Run(() => expected, def);
            areEqual(expected, actual);
        }
        [TestMethod]
        public void RunFuncExceptionTest() {
            var actual = Safe.Run(() => throw new Exception(), def);
            areEqual(def, actual);
        }
        [TestMethod] public void RunActionTest() => Safe.Run(() => throw new Exception());
        [TestMethod] public void RunTest() { }
    }
}
