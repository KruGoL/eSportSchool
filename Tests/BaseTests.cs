﻿using eSportSchool.Aids;
using System.Reflection;
using System.Diagnostics;

namespace eSportSchool.Tests
{
    public abstract class BaseTests<TClass> : AssertTests where TClass : class, new()
    {
        protected TClass obj;
        protected BaseTests() => obj = new TClass();
        protected void IsProperty<T>(T? value = default, bool isReadOnly = false)
        {
            var memberName = getCallingNumber(nameof(IsProperty)).Replace("Test", string.Empty);
            var propertyInfo = obj.GetType().GetProperty(memberName);
            isNotNull(propertyInfo);
            if (isNullOrDefault(value)) value = random<T>();
            if (canWrite(propertyInfo, isReadOnly)) propertyInfo.SetValue(obj, value);
            areEqual(value, propertyInfo.GetValue(obj));
        }
        private static bool isNullOrDefault<T>(T? value) => value?.Equals(default(T)) ?? true;
        private static bool canWrite(PropertyInfo i, bool isReadOnly)
        {
            var canWrite = i?.CanWrite ?? false;
            areEqual(canWrite, !isReadOnly);
            return canWrite;
        }
        private static T random<T>() => GetRandom.Value<T>();
        private string getCallingNumber(string memberName)
        {
            var s = new StackTrace();
            var isNext = false;
            for (var i = 0; i < s.FrameCount - 1; i++)
            {
                var n = s.GetFrame(i)?.GetMethod()?.Name ?? string.Empty;
                if (n is "MoveNext" or "Start") continue;
                if (isNext) return n;
                if (n == memberName) isNext = true;
            }
            return string.Empty;
        }
    }
}
