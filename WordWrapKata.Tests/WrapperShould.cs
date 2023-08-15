using FluentAssertions;
using Xunit;

namespace WordWrapKata.Tests;

public class WrapperShould
{
    [Fact]
    public void Return_empty_string_when_text_is_null()
        => Wrapper.Wrap(null, 10).Should().Be("");
    
    [Fact]
    public void Return_empty_string_when_text_is_empty_string()
        => Wrapper.Wrap("", 10).Should().Be("");
    
    [Fact]
    public void Test_1()
        => Wrapper.Wrap("aaa", 10).Should().Be("aaa");
    
    [Fact]
    public void Test_2()
        => Wrapper.Wrap("aaa", 2).Should().Be("aa\na");
    
    [Fact]
    public void Test_3()
        => Wrapper.Wrap("aabbc", 2).Should().Be("aa\nbb\nc");
    
    
    [Fact]
    public void Test_4()
        => Wrapper.Wrap("aa\nbb\nc", 2).Should().Be("aa\nbb\nc");
    
    [Fact]
    public void Test_5()
        => Wrapper.Wrap("aa\nbb\nc", 10).Should().Be("aa\nbb\nc");
    
    
    [Fact]
    public void Test_6()
        => Wrapper.Wrap("aa\n\nbbc\nddeef", 2).Should().Be("aa\n\nbb\nc\ndd\nee\nf");
    
    
    [Fact]
    public void Return_empty_string_when_wrap_null()
        => Wrapper.Wrap(null, 10).Should().Be("");

    [Fact]
    public void Return_empty_string_when_wrap_empty_string()
        => Wrapper.Wrap("", 10).Should().Be("");

    [Fact]
    public void Not_wrap_one_short_word()
        => Wrapper.Wrap("word", 5).Should().Be("word");

    [Fact]
    public void Breaks_at_length_when_word_longer_than_length()
    {
        Wrapper.Wrap("longword", 4).Should().Be("long\nword");
        Wrapper.Wrap("longerword", 6).Should().Be("longer\nword");
    }

    [Fact]
    public void Break_twice_when_word_longer_than_twice_length()
        => Wrapper.Wrap("verylongword", 4).Should().Be("very\nlong\nword");

    [Fact]
    public void Wrap_when_two_words_longer_than_limit()
    {
        Wrapper.Wrap("word word", 6).Should().Be("word\nword");
        Wrapper.Wrap("wrap me", 6).Should().Be("wrap\nme");
    }

    [Fact]
    public void Wrap_when_three_words_each_longer_than_limit()
        => Wrapper.Wrap("word word word", 4).Should().Be("word\nword\nword");

    [Fact]
    public void Break_at_second_word_when_three_words_just_over_the_Limit()
        => Wrapper.Wrap("word word word", 11).Should().Be("word word\nword");
}