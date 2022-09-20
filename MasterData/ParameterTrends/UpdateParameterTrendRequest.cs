using MasterData.Storage.Enumns;
using System;

namespace MasterData.ParameterTrends
{
    public class UpdateParameterTrendRequest
    {
        public string Name { get; set; }
        public Guid TrendId { get; set; }
        public RecordMode RecordMode { get; set; }
    }
}
