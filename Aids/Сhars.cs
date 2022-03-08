﻿namespace eSportSchool.Aids {
    public static class Chars {
        public static bool IsNameChar(this char x) => char.IsLetterOrDigit(x) || x == '_' || x == '.';
    }
}

