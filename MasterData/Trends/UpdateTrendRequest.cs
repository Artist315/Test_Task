using System;

namespace MasterData.Trends
{
    public class UpdateTrendRequest
    {
        public string Name { get; set; }
        public Guid? UnitId { get; set; }
        public Guid? EquipmentId { get; set; }
    }
}
