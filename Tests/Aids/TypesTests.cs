using eSportSchool.Aids;
using eSportSchool.Data;
using eSportSchool.Data.Sport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace eSportSchool.Tests.Aids {
    [TestClass] public class TypesTests : IsTypeTested {
        private Type type = typeof(object);
        private string? nameSpace;
        private string? fullName;
        private string? name;
        private string? randomStr;
        [TestInitialize]
        public void Init() {
            type = typeof(KindOfSportData);
            nameSpace = type.Namespace;
            fullName = type.FullName;
            name = type.Name;
            randomStr = GetRandom.String();
        }
        [TestMethod]
        public void BelongsToTest() {
            isTrue(type.BelongsTo(nameSpace));
            isFalse(type.BelongsTo(randomStr));
        }
        [TestMethod]
        public void NameIsTest() {
            isTrue(type.NameIs(fullName));
            isFalse(type.NameIs(randomStr));
        }
        [TestMethod]
        public void NameEndsTest() {
            isTrue(type.NameEnds(name));
            isFalse(type.NameEnds(randomStr));
        }
        [TestMethod]
        public void NameStartsTest() {
            isTrue(type.NameStarts(nameSpace));
            isFalse(type.NameStarts(randomStr));
        }
        [TestMethod]
        public void IsRealTypeTest() {
            isTrue(type.IsRealType());
            isTrue(typeof(NamedData).IsRealType());
            var a = GetAssembly.OfType(this);
            var allTypes = (a?.GetTypes() ?? Array.Empty<Type>()).ToList();
            var realTypes = allTypes?.FindAll(t => t.IsRealType());
            isNotNull(realTypes);
            isTrue(realTypes.Count < (allTypes?.Count ?? 0));
            isTrue(realTypes.Count > 0);
        }
        [TestMethod]
        public void GetNameTest() {
            areEqual(name, type.GetName());
            areNotEqual(randomStr, type.GetName());
        }
        [TestMethod]
        public void DeclaredMembersTest() {
            areEqual(1, type?.DeclaredMembers()?.Count);
            var l = typeof(NamedData)?.DeclaredMembers();
            areEqual(7, l?.Count);
        }
        [TestMethod]
        public void IsInheritedTest() {
            Type? nullType = null;
            isTrue(type.IsInherited(typeof(object)));
            isTrue(type.IsInherited(typeof(NamedData)));
            isFalse(type.IsInherited(nullType));
            isFalse(type.IsInherited(typeof(KindOfSportData)));
        }
        [TestMethod]
        public void HasAttributeTest() {
            isFalse(type.HasAttribute<TestClassAttribute>());
            isTrue(GetType().HasAttribute<TestClassAttribute>());
            isFalse(type.HasAttribute<TestMethodAttribute>());
            isFalse(GetType().HasAttribute<TestMethodAttribute>());
        }
        [TestMethod]
        public void MethodTest() {
            var n = nameof(MethodTest);
            var m = GetType().Method(n);
            areEqual(n, m?.Name);
        }
    }
}
