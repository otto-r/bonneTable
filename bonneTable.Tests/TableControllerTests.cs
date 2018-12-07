using AutoFixture;
using bonneTable.API.Controllers;
using bonneTable.Services.Services;
using NSubstitute;
using Xunit;

namespace bonneTable.Tests
{
    public class TableControllerTests
    {
        private TableService _table;
        private Fixture _fixture;

        public TableControllerTests()
        {
            _table = Substitute.For<TableService>();
            _fixture = new Fixture();
        }

        [Fact]
        public async void TestGetAll()
        {
            var tableController = new TableController(_table);

            var actual = await tableController.GetAll();
            
        }
    }
}
