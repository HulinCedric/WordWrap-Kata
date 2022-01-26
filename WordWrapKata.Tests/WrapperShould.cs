using FluentAssertions;
using Xunit;

namespace WordWrapKata.Tests;

public class WrapperShould
{
    [Fact]
    public void Fixme()
        => Wrapper.Wrap(null, 10).Should().Be("");
}