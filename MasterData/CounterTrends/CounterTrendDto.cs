using MasterData.Storage.Enumns;
using System;

namespace MasterData.CounterTrends
{
    public class CounterTrendDto
    {
        public Guid Id { get; set; }
        public int Key { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid TrendId { get; set; }
        public RecordMode RecordMode { get; set; }
        public CounterTrendTypes Type { get; set; }
    }
}
