using MasterData.Storage.Enumns;
using System;

namespace MasterData.ParameterTrends
{
    public class ParameterTrendDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid TrendId { get; set; }
        public RecordMode RecordMode { get; set; }
    }
}
