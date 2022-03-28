using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests
{
    public abstract class PublicClassTests<TClass> : BaseTests where TClass : class, new() {
        protected override object createObj() => new TClass();
        [TestMethod] public void IsPublicTest() => isTrue(obj?.GetType()?.IsPublic ?? false);
    }
}
