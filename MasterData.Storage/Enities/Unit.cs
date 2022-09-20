using MasterData.Storage.Enumns;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterData.Storage.Enities
{
    [Table("tblUnit")]
    public class Unit
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
        [Column("nType")]
        public OeeType Type { get; set; }

        [Required]
        [Column("dtCreatedAt")]
        public DateTime CreatedAt { get; set; }
    }
}
