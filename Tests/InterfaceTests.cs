using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests
{
    public abstract class InterfaceTests<TClass> : BaseTests where TClass : class, new()
    {
        protected override object createObj() => new TClass();
        [TestMethod] public void IsInterface() => isTrue(obj?.GetType()?.IsInterface ?? false);
    }
}
