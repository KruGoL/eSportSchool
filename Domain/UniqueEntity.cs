using eSportSchool.Data;
using eSportSchool.Data.Party;

namespace eSportSchool.Domain
{
    public abstract class UniqueEntity
    {
        public static string DefaultStr = "Undefined";
        private const bool defaultBool = false;
        private static DateTime defaultDate => DateTime.MinValue;
        protected static string getValue(string? v) => v ?? DefaultStr;
        protected static bool getValue(bool? v) => v ?? defaultBool;
        protected static DateTime getValue(DateTime? v) => v ?? defaultDate;
        protected static IsoGender getValue(IsoGender? v) => v ?? IsoGender.NotApplicable;

    }
    public abstract class UniqueEntity<TData> : UniqueEntity where TData : UniqueData, new()
    {
        private readonly TData data;
        public TData Data => data;
        public UniqueEntity() : this(new TData()) { }
        public UniqueEntity(TData d) => data = d;
        public string Id => getValue(Data?.Id);
    }
}
