using MasterData.Storage.Enumns;
using System;

namespace MasterData.Units
{
    public class UnitDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public OeeType Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
