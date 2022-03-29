using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests
{
    public abstract class InterfaceTests<T> : TestAsserts
    {

        [TestMethod] public void IsInterface() => isTrue(typeof(T)?.IsInterface ?? false);
    }
}