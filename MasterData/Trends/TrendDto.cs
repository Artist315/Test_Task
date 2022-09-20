using System;

namespace MasterData.Trends
{
    public class TrendDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UnitId { get; set; }
        public Guid? EquipmentId { get; set; }
    }
}
