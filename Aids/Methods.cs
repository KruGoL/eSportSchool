
using System.Reflection;

namespace eSportSchool.Aids {
    public static class Methods {
        public static bool HasAttribute<TAttribute>(this MethodInfo? m) where TAttribute : Attribute => Safe.Run(() => m?.GetCustomAttributes<TAttribute>()?.FirstOrDefault() is not null, false);
    }
}

