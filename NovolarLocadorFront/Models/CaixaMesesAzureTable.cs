using Azure;
using Azure.Data.Tables;

namespace NovolarLocadorFront.Models
{
    public class CaixaMesesAzureTable : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string meses { get; set; }
        public string repasses { get; set; }
        public string despesas { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
        
    }
}
