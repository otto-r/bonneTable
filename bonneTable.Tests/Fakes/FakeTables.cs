using bonneTable.Models;
using System;
using System.Collections.Generic;

namespace bonneTable.Tests.Fakes
{
    public class FakeTables
    {
        public static List<Table> GetAll3x2Tables()
        {
            var tables = new List<Table> {
                new Table
                {
                    Id = new Guid("D7E47942-D20C-449F-9DF1-ADBCDD554DBB"),
                    Seats = 2
                },
                new Table
                {
                    Id = new Guid("39A926B2-1B98-4135-926D-0F1219B10265"),
                    Seats = 2
                },
                new Table
                {
                    Id = new Guid("DC3B1144-0006-4C75-9020-BD12355BC7B3"),
                    Seats = 2
                },
            };
            return tables;
        }

        public static List<Table> GetAll4x2Tables()
        {
            var tables = new List<Table> {
                new Table
                {
                    Id = new Guid("D7E47942-D20C-449F-9DF1-ADBCDD554DBB"),
                    Seats = 2
                },
                new Table
                {
                    Id = new Guid("39A926B2-1B98-4135-926D-0F1219B10265"),
                    Seats = 2
                },
                new Table
                {
                    Id = new Guid("DC3B1144-0006-4C75-9020-BD12355BC7B3"),
                    Seats = 2
                },
                new Table
                {
                    Id = new Guid("08955F94-9300-429D-B733-55173E97EC8E"),
                    Seats = 2
                }
            };
            return tables;
        }
    }
}