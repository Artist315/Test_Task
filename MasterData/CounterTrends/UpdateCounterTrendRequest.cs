using MasterData.Storage.Enumns;
using System;

namespace MasterData.CounterTrends
{
    public class UpdateCounterTrendRequest
    {
        public string Name { get; set; }
        public Guid TrendId { get; set; }
        public RecordMode RecordMode { get; set; }
        public CounterTrendTypes Type { get; set; }
    }
}
