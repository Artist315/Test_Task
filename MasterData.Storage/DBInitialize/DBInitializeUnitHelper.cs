using MasterData.Storage.Enities;
using MasterData.Storage.Enumns;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterData.Storage.DBInitialize
{
    public class DBInitializeUnitHelper
    {
        public static void InsertInitialData(ModelBuilder modelBuilder)
        {
            List<Unit> productionTimeIntervals = FillReferences();
            modelBuilder.Entity<Unit>().HasData(productionTimeIntervals);
            Console.WriteLine("References has been added");
        }

        protected static List<Unit> FillReferences()
        {
            var productionTimeIntervals = new List<Unit>
                {
                    new Unit()
                    {
                        Id = Guid.Parse("F8A5032E-6995-4826-B128-41423B2930F7"),
                        Key = 1,
                        Name = "Test1",
                        Type = OeeType.AVGOEE,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Unit()
                    {
                        Id = Guid.Parse("2E0685BC-E6AC-4DDA-9D67-8CE361E4E760"),
                        Key = 2,
                        Name = "Test2",
                        CreatedAt = DateTime.UtcNow,
                        Type = OeeType.MAXOEE,
                    },
                    new Unit()
                    {
                        Id = Guid.Parse("C89E11A1-34C5-4EAF-8084-956CC5E510BF"),
                        Key = 3,
                        Name = "Test3",
                        CreatedAt = DateTime.UtcNow,
                        Type = OeeType.MAXOEE,
                    },
                    new Unit()
                    {
                        Id = Guid.Parse("A2664588-F699-4FE2-AD24-696C679F68B6"),
                        Key = 4,
                        Name = "Test4",
                        CreatedAt = DateTime.UtcNow,
                        Type = OeeType.MAXOEE,
                    }
                };
            return productionTimeIntervals;
        }
    }
}