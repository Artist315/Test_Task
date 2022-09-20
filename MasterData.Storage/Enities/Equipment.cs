using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterData.Storage.Enities
{
    [Table("tbEquipment")]
    public class Equipment
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
        public string Name { get; set; }

        [Required]
        [Column("bIsUsed")]
        public bool IsUsed { get; set; }

        [Required]
        [Column("gUnitId")]
        public Guid UnitId { get; set; }
        [ForeignKey(nameof(UnitId))]
        public Unit Unit { get; set; }

        [Required]
        [Column("dtCreatedAt")]
        public DateTime CreatedAt { get; set; }


    }
}
