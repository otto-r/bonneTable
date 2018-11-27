using AutoFixture;
using bonneTable.Models;
using bonneTable.Models.RequestModels;
using bonneTable.Services.Interfaces;
using bonneTable.Services.Services;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace bonneTable.Tests
{
    public class TableServiceTests
    {
        private Fixture _fixture;
        private IRepository<Table> _repository;

        public TableServiceTests()
        {
            _fixture = new Fixture();
            _repository = Substitute.For<IRepository<Table>>();
        }

        [Fact]
        public async void AddTable_WithValidSeats_ReturnsSuccessViewModel()
        {
            var tableService = new TableService(_repository);
            var seats = 2;

            var actual = await tableService.Add(seats);

            actual.Success.Should().BeTrue();
        }

        [Fact]
        public async void AddTable_WithNegativeSeats_ReturnsFailureViewModel()
        {
            var tableService = new TableService(_repository);
            var seats = -2;

            var actual = await tableService.Add(seats);

            actual.Success.Should().BeFalse();
        }
    }
}
