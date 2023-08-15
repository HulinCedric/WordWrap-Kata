namespace WordWrapKata;

internal readonly record struct Sentence(string Value)
{
    public Sentence[] Wrap(int length)
        => Wrap(Value, length).Split("\n").Select(New).ToArray();

    private static string Wrap(string sentence, int length)
    {
        if (sentence.Length <= length)
            return sentence;

        var space = sentence
            .Substring(0, length + 1)
            .LastIndexOf(" ", StringComparison.Ordinal);

        if (space >= 0)
            return BreakBetween(sentence, space, space + 1);

        return BreakBetween(sentence, length, length);
    }

    private static string BreakBetween(string s, int start, int end)
        => s.Substring(0, start) +
           "\n" +
           Wrap(s.Substring(end), start);

    public static Sentence New(string sentence)
        => new(sentence);
}

public static class Wrapper
{
    public static string Wrap(string? text, int column)
    {
        if (text is null)
            return "";

        return SentencesFrom(text)
            .BreakSentencesAt(column)
            .ToText();
    }

    private static Sentence[] SentencesFrom(string text)
        => text.Split("\n").Select(Sentence.New).ToArray();

    private static IEnumerable<Sentence> BreakSentencesAt(this IEnumerable<Sentence> sentences, int column)
        => sentences.SelectMany(sentence => sentence.Wrap(column));

    private static string ToText(this IEnumerable<Sentence> sentences)
        => sentences
            .Select(s => s.Value)
            .Aggregate((wrappedText, sentence) => $"{wrappedText}\n{sentence}");
}