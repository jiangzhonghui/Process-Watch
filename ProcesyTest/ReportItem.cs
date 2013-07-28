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

        [XmlAttribute("Name")]
        public string name;
        [XmlElement("Detail")]
        public List<ProcessHistoryDetail> History;
    }
}
