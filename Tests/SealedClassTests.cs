using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests
{
    public abstract class SealedClassTests<TClass>: BaseTests where TClass : class, new() {
        protected override object createObj() => new TClass();
        [TestMethod] public void IsSealedTest() => isTrue(obj?.GetType()?.IsSealed?? false);
    }
}
