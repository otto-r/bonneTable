using bonneTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bonneTable.Tests.Fakes
{
    public class FakeBookings
    {
        public static List<Booking> Get3Bookings()
        {
            var tables = FakeTables.GetAll3x2Tables();

            var bookingsByDate = new List<Booking>
            {
                new Booking
                {
                    Id = new Guid("116A399F-7A95-4CAA-A461-FC1F9AA8374F"),
                    CustomerName = "Otto",
                    Email = "otto@otto.com",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "d7e47942-d20c-449f-9df1-adbcdd554dbb").First(),
                    Time = DateTime.Now                   
                },
                new Booking
                {
                    Id = new Guid("21070F3C-F2C4-41DE-9AC3-C3B4B58A449B"),
                    CustomerName = "John",
                    Email = "John@Doe.us",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "39a926b2-1b98-4135-926d-0f1219b10265").First(),
                    Time = DateTime.Now
                },
                new Booking
                {
                    Id = new Guid("3BFD706B-869A-40DE-910A-4D0CDB0FA095"),
                    CustomerName = "Jane",
                    Email = "Jane@Doe.us",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "dc3b1144-0006-4c75-9020-bd12355bc7b3").First(),
                    Time = DateTime.Now
                }
            };

            return bookingsByDate;
        }

        public static List<Booking> Get3Bookings1Late()
        {
            var tables = FakeTables.GetAll3x2Tables();

            var bookingsByDate = new List<Booking>
            {
                new Booking
                {
                    Id = new Guid("116A399F-7A95-4CAA-A461-FC1F9AA8374F"),
                    CustomerName = "Otto",
                    Email = "otto@otto.com",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "d7e47942-d20c-449f-9df1-adbcdd554dbb").First(),
                    Time = DateTime.Now
                },
                new Booking
                {
                    Id = new Guid("21070F3C-F2C4-41DE-9AC3-C3B4B58A449B"),
                    CustomerName = "John",
                    Email = "John@Doe.us",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "39a926b2-1b98-4135-926d-0f1219b10265").First(),
                    Time = DateTime.Now
                },
                new Booking
                {
                    Id = new Guid("3BFD706B-869A-40DE-910A-4D0CDB0FA095"),
                    CustomerName = "Jane",
                    Email = "Jane@Doe.us",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "dc3b1144-0006-4c75-9020-bd12355bc7b3").First(),
                    Time = DateTime.Now.AddHours(2)
                }
            };

            return bookingsByDate;
        }

        public static List<Booking> Get3Bookings1Early()
        {
            var tables = FakeTables.GetAll3x2Tables();

            var bookingsByDate = new List<Booking>
            {
                new Booking
                {
                    Id = new Guid("116A399F-7A95-4CAA-A461-FC1F9AA8374F"),
                    CustomerName = "Otto",
                    Email = "otto@otto.com",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "d7e47942-d20c-449f-9df1-adbcdd554dbb").First(),
                    Time = DateTime.Now
                },
                new Booking
                {
                    Id = new Guid("21070F3C-F2C4-41DE-9AC3-C3B4B58A449B"),
                    CustomerName = "John",
                    Email = "John@Doe.us",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "39a926b2-1b98-4135-926d-0f1219b10265").First(),
                    Time = DateTime.Now
                },
                new Booking
                {
                    Id = new Guid("3BFD706B-869A-40DE-910A-4D0CDB0FA095"),
                    CustomerName = "Jane",
                    Email = "Jane@Doe.us",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "dc3b1144-0006-4c75-9020-bd12355bc7b3").First(),
                    Time = DateTime.Now.AddHours(-2)
                }
            };

            return bookingsByDate;
        }

        public static List<Booking> Get3Bookings1Overlap()
        {
            var tables = FakeTables.GetAll3x2Tables();

            var bookingsByDate = new List<Booking>
            {
                new Booking
                {
                    Id = new Guid("116A399F-7A95-4CAA-A461-FC1F9AA8374F"),
                    CustomerName = "Otto",
                    Email = "otto@otto.com",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "d7e47942-d20c-449f-9df1-adbcdd554dbb").First(),
                    Time = DateTime.Now
                },
                new Booking
                {
                    Id = new Guid("21070F3C-F2C4-41DE-9AC3-C3B4B58A449B"),
                    CustomerName = "John",
                    Email = "John@Doe.us",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "39a926b2-1b98-4135-926d-0f1219b10265").First(),
                    Time = DateTime.Now
                },
                new Booking
                {
                    Id = new Guid("3BFD706B-869A-40DE-910A-4D0CDB0FA095"),
                    CustomerName = "Jane",
                    Email = "Jane@Doe.us",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "dc3b1144-0006-4c75-9020-bd12355bc7b3").First(),
                    Time = DateTime.Now.AddHours(1)
                }
            };

            return bookingsByDate;
        }

        public static List<Booking> Get3Bookings2HoursLater()
        {
            var tables = FakeTables.GetAll3x2Tables();

            var bookingsByDate = new List<Booking>
            {
                new Booking
                {
                    Id = new Guid("116A399F-7A95-4CAA-A461-FC1F9AA8374F"),
                    CustomerName = "Otto",
                    Email = "otto@otto.com",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "d7e47942-d20c-449f-9df1-adbcdd554dbb").First(),
                    Time = DateTime.Now.AddHours(2)
                },
                new Booking
                {
                    Id = new Guid("21070F3C-F2C4-41DE-9AC3-C3B4B58A449B"),
                    CustomerName = "John",
                    Email = "John@Doe.us",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "39a926b2-1b98-4135-926d-0f1219b10265").First(),
                    Time = DateTime.Now.AddHours(2)
                },
                new Booking
                {
                    Id = new Guid("3BFD706B-869A-40DE-910A-4D0CDB0FA095"),
                    CustomerName = "Jane",
                    Email = "Jane@Doe.us",
                    PhoneNumber = "0102030405",
                    Seats = 2,
                    Table = tables.Where(t => t.Id.ToString() == "dc3b1144-0006-4c75-9020-bd12355bc7b3").First(),
                    Time = DateTime.Now.AddHours(2)
                }
            };

            return bookingsByDate;
        }
    }
}
