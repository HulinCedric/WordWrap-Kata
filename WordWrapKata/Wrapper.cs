namespace WordWrapKata;

public static class Wrapper
{
    public static string Wrap(string s, int length)
    {
        if (s == null)
            return "";

        if (s.Length <= length)
            return s;

        var space = s
            .Substring(0, length + 1)
            .LastIndexOf(" ", StringComparison.Ordinal);

        if (space >= 0)
            return BreakBetween(s, space, space + 1);

        return BreakBetween(s, length, length);
    }

    private static string BreakBetween(string s, int start, int end)
        => s.Substring(0, start) +
           "\n" +
           Wrap(s.Substring(end), start);
}