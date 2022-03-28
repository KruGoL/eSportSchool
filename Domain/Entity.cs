using eSportSchool.Data;

namespace eSportSchool.Domain
{
    public abstract class Entity {
        private const string _defaultStr = "Undefined";
        private const bool _defaultBool = false;
        private static DateTime _defaultDate => DateTime.MinValue;
        protected static string getValue(string? v) => v ?? _defaultStr; 
        protected static bool getValue(bool? v) => v ?? _defaultBool;
        protected static DateTime getValue(DateTime? v) => v ?? _defaultDate;

    }
    public abstract class Entity<TData>: Entity where TData : EntityData, new() {
        private readonly TData data;
        public TData Data => data;
        public Entity() : this(new TData()) { }
        public Entity(TData d) => data = d;
        public string Id => getValue(Data?.Id);
    }
}
