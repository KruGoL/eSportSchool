using eSportSchool.Data;
using eSportSchool.Data.Party;

namespace eSportSchool.Domain
{
    public abstract class UniqueEntity
    {
        public static string DefaultStr => "Undefined";
        private const bool defaultBool = false;
        private static DateTime defaultDate => DateTime.MinValue;
        protected static string getValue(string? v) => v ?? DefaultStr;
        protected static bool getValue(bool? v) => v ?? defaultBool;
        protected static IsoGender getValue(IsoGender? v) => v ?? IsoGender.NotApplicable;
        protected static DateTime getValue(DateTime? v) => v ?? defaultDate;
        public abstract string Id { get; }
        public abstract byte[] Token { get; }
    }
    public abstract class UniqueEntity<TData> : UniqueEntity where TData : UniqueData, new()
    {
        public TData Data { get; }
        public UniqueEntity() : this(new TData()) { }
        public UniqueEntity(TData d) => Data = d;
        public override string Id => getValue(Data?.Id);
        public override byte[] Token => Data?.Token ?? Array.Empty<byte>();
    }
}
