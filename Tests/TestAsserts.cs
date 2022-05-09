using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace eSportSchool.Tests
{
    public abstract class TestAsserts
    {
        protected static void isTrue(bool? b, string? msg = null) => Assert.IsTrue(b ?? false, msg ?? string.Empty);
        protected static void isFalse(bool? b, string? msg = null) => Assert.IsFalse(b ?? true, msg ?? string.Empty);
        protected static void isInconclusive(string? s = null) => Assert.Inconclusive(s ?? string.Empty);
        protected static void isNotNull([NotNull] object? o = null, string? msg = null) => Assert.IsNotNull(o, msg);
        protected static void isNull(object? o = null, string? msg = null) => Assert.IsNull(o, msg);
        protected static void areEqual(object? expected, object? actual, string? msg = null) => Assert.AreEqual(expected, actual, msg);
        protected static void areNotEqual(object? expected, object? actual, string? msg = null) => Assert.AreNotEqual(expected, actual, msg);
        protected static void isInstanceOfType(object o, Type expectedType, string? msg = null) => Assert.IsInstanceOfType(o, expectedType, msg);

    }
}
