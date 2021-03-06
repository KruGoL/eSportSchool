using Microsoft.EntityFrameworkCore;
using eSportSchool.Data;
using eSportSchool.Domain;

namespace eSportSchool.Infra {
    public abstract class Repo<TDomain, TData> : PagedRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new()
    {
        protected Repo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
        protected internal static bool contains(string? x, string? y) => (y is null) || (x?.Contains(y) ?? false);
    }
}
