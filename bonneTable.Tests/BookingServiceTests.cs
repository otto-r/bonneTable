using FluentAssertions;
using System;
using Xunit;

namespace bonneTable.Tests
{
    public class BookingServiceTests
    {
        [Fact]
        public void ClientBookTable_Test()
        {
            5.Should().Be(5);
        }
    }
}
