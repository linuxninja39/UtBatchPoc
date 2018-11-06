using System.Collections.Generic;
using Summer.Batch.Core.Configuration;
using Summer.Batch.Core.Unity.Xml;

namespace ArBatch
{
    public class ArBatchJobConfig : IJobConfigurator
    {
        public static readonly string ItemReaderRefName = "FlatFileReader/FlatFileReader";
        public static readonly string ItemProcessorRefName = "FlatFileReader/Processor";
        public static readonly string ItemWriterRefName = "FlatFileReader/DatabaseWriter";

        public XmlJob GetXmlJob()
        {
            return new XmlJob
            {
                Id = "ArBatch",
                JobElements = new List<XmlJobElement>
                {
                    new XmlStep
                    {
                        Chunk = new XmlChunk
                        {
                            Reader = new XmlItemReader {Ref = ItemReaderRefName},
                            Processor = new XmlItemProcessor {Ref = ItemProcessorRefName},
                            Writer = new XmlItemWriter {Ref = ItemWriterRefName},
                            ItemCount = "1000"
                        },
                        Id = "ArBatch",
                        Transitions = new List<XmlTransitionElement>()
                    }
                }
            };
        }
    }
}