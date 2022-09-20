using System;

namespace MasterData.Equipments
{
    public class UpdateEquipmentRequest
    {
        public string Name { get; set; }
        public bool IsUsed { get; set; }
        public Guid UnitId { get; set; }
    }
}
