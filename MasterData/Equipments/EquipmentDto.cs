using System;

namespace MasterData.Equipments
{
    public class EquipmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Usage { get; set; }
        public Guid UnitId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
