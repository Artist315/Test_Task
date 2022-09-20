using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterData.Storage.Enities
{
    [Table("tblTrend")]
    public class Trend
    {
        [Key]
        [Required]
        [Column("gId")]
        public Guid Id { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("nKey")]
        public int Key { get; set; }

        [Required]
        [Column("szName")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [Column("dtCreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("gUnitId")]
        public Guid? UnitId { get; set; }
        [ForeignKey(nameof(UnitId))]
        public Unit Unit { get; set; }

        [Column("gEquipmentId")]
        public Guid? EquipmentId { get; set; }
        [ForeignKey(nameof(EquipmentId))]
        public Equipment Equipment { get; set; }
    }
}
