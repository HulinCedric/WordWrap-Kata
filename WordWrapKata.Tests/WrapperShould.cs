using FluentAssertions;
using Xunit;

namespace WordWrapKata.Tests;

/**
 * # Respect the Transformation Priority Premise
 * source: http://blog.cleancoder.com/uncle-bob/2013/05/27/TheTransformationPriorityPremise.html
 * 
 * | Transformation name    | Description                                          | Example                                                 |
 * | ---------------------- | ---------------------------------------------------- | ------------------------------------------------------- |
 * | {} → nil               | no code at all → code that employs nil               | no code → nil                                           |
 * | nil → constant         |                                                      | nil → "", 1                                             |
 * | constant → constant+   | a simple constant to a more complex constant         | "", 1 → "Australia", 42                                 |
 * | constant → scalar      | replacing a constant with a variable or an argument  | "Australia" → country                                   |
 * | statement → statements | adding more unconditional statements                 | country = "Australia" → country = "Australia"; num = 42 |
 * | unconditional → if     | splitting the execution path                         | no if → if, ternary if statement                        |
 * | scalar → array         |                                                      | dog → [dog, cat]                                        |
 * | array → container      |                                                      | [dog, cat] → { dog: 'woof', cat: 'meow' }               |
 * | statement → recursion  |                                                      | statement → recursion(statement)                        |
 * | if → while             |                                                      | if door_open → while(door_open)                         |
 * | expression → function  | replacing an expression with a function or algorithm | Date.today - birthdate → age_in_days(birthdate)         |
 * | variable → assignment  | replacing the value of a variable                    | days_left → days_left = 10                              |
 */
public class WrapperShould
{
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