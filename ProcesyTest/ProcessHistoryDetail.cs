using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProcesyTest
{
    [Serializable]
    public class ProcessHistoryDetail
    {
        public DateTime Start;
        public DateTime End;
        
        [XmlIgnore]
        public TimeSpan Duration;

        public String duration
        {
            set
            {
                Duration = TimeSpan.Parse(value);
            }
            get
            {
                return Duration.ToString();
            }
        }

        public ProcessHistoryDetail() { }

        public ProcessHistoryDetail(ProcessHistoryDetail source)
        {
            this.Start = source.Start;
            this.End = source.End;
            this.Duration = source.Duration;
        }
    }
}
