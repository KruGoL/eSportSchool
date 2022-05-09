﻿

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using eSportSchool.Aids;

namespace eSportSchool.Tests {
    public abstract class AssemblyTests : TestAsserts {
        private Assembly? testingAssembly;
        private Assembly? assemblyToBeTested;
        private List<Type>? testingTypes;
        private List<Type>? typesToBeTested;
        private string? namespaceOfTest;
        private string? namespaceOfType;
        [TestMethod] public void IsAllTested() => isAllTested();
        protected virtual void isAllTested() {
            testingAssembly = getAssembly(this);
            testingTypes = getTypes(testingAssembly);
            namespaceOfTest = getNamespace(this);
            removeNotInNamespace();
            namespaceOfType = removeTestsTagFrom(namespaceOfTest);
            assemblyToBeTested = getAssembly(namespaceOfType);
            typesToBeTested = getTypes(assemblyToBeTested);
            removeNotNeedTesting();
            removeTested();
            if (allAreTested()) return;
            reportNotAllIsTested();
        }

        private void removeNotInNamespace() => testingTypes.Remove(x => !Types.NameStarts(x, namespaceOfTest));

        private static string? removeTestsTagFrom(string? s) => s?.Remove("Tests.");
        private static string? getNamespace(object o) => GetNamespace.OfType(o);
        private static Assembly? getAssembly(object o) => GetAssembly.OfType(o);
        private static Assembly? getAssembly(string? name) => GetAssembly.ByName(name);
        private static List<Type>? getTypes(Assembly? a) => GetAssembly.Types(a);
        private void reportNotAllIsTested() => isInconclusive($"Class \"{fullNameOfFirstNotTested()}\" is not tested");
        private string fullNameOfFirstNotTested() => firstNotTestedType(typesToBeTested)?.FullName ?? string.Empty;
        private static Type? firstNotTestedType(List<Type>? l) => l.GetFirst();
        private bool allAreTested() => typesToBeTested.IsEmpty();
        private void removeTested() => typesToBeTested?.Remove(x => isItTested(x));
        private bool isItTested(Type x) => testingTypes?.ContainsItem(y => isTestFor(y, x) && isCorrectTest(y)) ?? false;
        private static bool isCorrectTest(Type x) {
            var a = isCorrectlyInherited(x);
            var b = isTestClass(x);
            return a && b;
        }
        private static bool isTestClass(Type x) => x?.HasAttribute<TestClassAttribute>() ?? false;
        private static bool isCorrectlyInherited(Type x) => x.IsInherited(typeof(TypeTests));
        private static bool isTestFor(Type testingType, Type typeToBeTested) {
            var testName = typeToBeTested.Name;
            var length = testName.IndexOf('`');
            if (length >= 0) testName = testName[..length];
            testName += "Tests";
            var r = testingType.NameEnds(testName);
            return r;
        }
        private void removeNotNeedTesting() => typesToBeTested?.Remove(x => !isTypeToBeTested(x));
        private bool isTypeToBeTested(Type x) => x?.BelongsTo(namespaceOfType) ?? false;
    }
}