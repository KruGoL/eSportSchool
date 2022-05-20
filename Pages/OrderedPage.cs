using eSportSchool.Domain;
using eSportSchool.Facade;
using System.ComponentModel;
using System.Reflection;

namespace eSportSchool.Pages
{
    public abstract class OrderedPage<TView, TEntity, TRepo> : FilteredPage<TView, TEntity, TRepo>
        where TView : UniqueView, new()
        where TEntity : UniqueEntity
        where TRepo : IOrderedRepo<TEntity> {
        protected OrderedPage(TRepo r) : base(r) { }
        public string? CurrentOrder {
            get => fromCurrentOrder(repo.CurrentOrder);
            set => repo.CurrentOrder = toCurrentOrder(value);
        }
        private string? fromCurrentOrder(string? value) {
            var isDesc = value?.Contains("_desc") ?? false;
            var propertyName = value?.Replace("_desc", string.Empty);
            var pi = typeof(TView).GetProperty(propertyName);
            var displayName = getDisplayName(pi);
            return isDesc ? displayName + "_desc" : displayName;
        }
        private static string? getDisplayName(PropertyInfo? pi) {
            var dn = pi?.GetCustomAttribute<DisplayNameAttribute>();
            return dn?.DisplayName;
        }
        private string? toCurrentOrder(string? value) {
            var isDesc = value?.Contains("_desc") ?? false;
            var displayName = value?.Replace("_desc", string.Empty);
            foreach (var pi in typeof(TView).GetProperties()) {
                if (!isThisDisplayName(pi, displayName)) continue;
                return isDesc ? pi.Name + "_desc" : pi.Name;
            }
            return value;
        }
        private static bool isThisDisplayName(PropertyInfo pi, string? displayName)
            => getDisplayName(pi) == displayName;
        public string? SortOrder(string displayName) => repo.SortOrder(toCurrentOrder(displayName));
    }
}