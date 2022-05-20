namespace eSportSchool.Aids;
public static class ConcurrencyToken {
    public static string ToStr(byte[]? token = null) {
        var s = string.Empty;
        foreach (var b in token ?? Array.Empty<byte>()) s += b;
        return s;
    }
    public static byte[] ToByteArray(string? token = null) {
        var l = new List<byte>();
        foreach (var c in token ?? GetRandom.String(8, 8)) l.Add(Convert.ToByte(c));
        return l.ToArray();
    }
}
