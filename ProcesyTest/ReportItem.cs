using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProcesyTest
{
    [Serializable]
    public class ReportItem
    {
        public ReportItem()
        { }

        public ReportItem(string name, List<ProcessHistoryDetail> history)
        {
            this.name = name;
            this.History = history;
        }

        public ReportItem(List<ProcessHistoryDetail> history)
            : this(String.Empty, history) { }

        [XmlAttribute("Name")]
        public string name;
        [XmlElement("Detail")]
        public List<ProcessHistoryDetail> History;

        [XmlIgnore]
        public TimeSpan TotalTime
        {
            get
            {
                TimeSpan retValue = new TimeSpan();
                foreach (ProcessHistoryDetail detail in History)
                {
                    retValue += detail.Duration;
                }
                return retValue;
            }
        }

        [XmlAttribute("TotalTime")]
        public String TotalTimeXml
        {
            get
            {
                return TotalTime.ToString();
            }
        }

        [XmlIgnore]
        public TimeSpan AverageTime
        {
            get
            {
                if (History.Count > 0)
                    return new TimeSpan(TotalTime.Ticks / History.Count);
                else return new TimeSpan();
            }
        }

        [XmlIgnore]
        public String AverageTimeXml
        {
            get
            {
                return AverageTime.ToString();
            }
        }

    }
}
