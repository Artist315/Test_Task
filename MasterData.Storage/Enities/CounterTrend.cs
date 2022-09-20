using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MasterData.Storage.Enumns;

namespace MasterData.Storage.Enities
{
    [Table("tblCounterTrend")]
    public class CounterTrend
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

        [Required]
        [Column("gTrendId")]
        public Guid TrendId { get; set; }
        [ForeignKey(nameof(TrendId))]
        public Trend Trend { get; set; }

        [Required]
        [Column("nRecordMode")]
        public RecordMode RecordMode { get; set; }

        [Required]
        [Column("nType")]
        public CounterTrendTypes Type { get; set; }
    }
}
