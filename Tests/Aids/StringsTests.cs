using eSportSchool.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Aids {
    [TestClass] public class StringsTests : TypeTests {
        private string? testStr;
        [TestInitialize] public void Init() => testStr = "a1b1c1.d1e1f1.g1h1i1";
        [TestMethod] public void RemoveTest() => areEqual("abc.def.ghi", Strings.Remove(testStr, "1"));
        [TestMethod]
        public void IsTypeNameTest() {
            isFalse(Strings.IsTypeName(testStr));
            var s = Strings.Remove(testStr, "1");
            isFalse(Strings.IsTypeName(s));
            s = Strings.RemoveTail(s);
            isFalse(Strings.IsTypeName(s));
            s = Strings.RemoveTail(s);
            isTrue(Strings.IsTypeName(s));
        }
        [TestMethod]
        public void IsTypeFullNameTest() {
            isFalse(Strings.IsTypeFullName(testStr));
            isTrue(Strings.IsTypeFullName(Strings.Remove(testStr, "1")));
        }
        [TestMethod] public void RemoveTailTest() => areEqual("a1b1c1.d1e1f1", Strings.RemoveTail(testStr));
        [TestMethod] public void RemoveHeadTest() => areEqual("d1e1f1.g1h1i1", Strings.RemoveHead(testStr));
    }
}
