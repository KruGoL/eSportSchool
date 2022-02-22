using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace eSportSchool.Tests
{
    public abstract class AssertTests
    {
        protected static void inconclusive() => Assert.Inconclusive();
        protected static void isNotNull([NotNull] object? o = null) => Assert.IsNotNull(o);
        protected static void areEqual(object? expected, object? actual) => Assert.AreEqual(expected, actual);
    }
}
