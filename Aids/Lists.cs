namespace eSportSchool.Aids {
    public static class Lists {
        public static T? GetFirst<T>(this List<T>? l) => ((l is null) || (l.Count < 1)) ? default : l[0];
        public static int? Remove<T>(this List<T>? l, Predicate<T> match) => Safe.Run(() => l?.RemoveAll(match), -1);
        public static bool IsEmpty<T>(this List<T>? l) => Safe.Run(() => (l?.Count ?? 0) == 0, true);
        public static bool ContainsItem<T>(this List<T>? l, Func<T, bool> match)
            => Safe.Run(
                () => {
                    var a = l is not null;
                    var x = l.Single(match);
                    var b = x is not null;
                    return a && b;
                },
                false);
    }
}
