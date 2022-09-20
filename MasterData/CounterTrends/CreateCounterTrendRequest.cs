using MasterData.Storage.Enumns;
using System;

namespace MasterData.CounterTrends
{
    public class CreateCounterTrendRequest
    {
        public string Name { get; set; }
        public Guid TrendId { get; set; }
        public CounterTrendTypes Type { get; set; }
        public RecordMode RecordMode { get; set; }
    }
}
