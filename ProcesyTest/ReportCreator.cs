using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace ProcesyTest
{
    class ReportCreator
    {
        public ReportCreator(List<ProcessToWatch> processes)
        {
            this.processes = processes;
            itemsToReport = new List<ReportItem>();
        }

        private List<ProcessToWatch> processes;
        private List<ReportItem> itemsToReport;

        private void SaveReport()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<ReportItem>));

            string path;// = DateTime.Now.ToString("{0:yyyyMMddhhmm}");
            path = String.Format("report-{0:yyyy-MM-dd-HH-mm-ss}.xml", DateTime.Now);

            if(!String.IsNullOrEmpty(ReportPath))
                path = Path.Combine(ReportPath, path);

            try
            {
                using(StreamWriter write = new StreamWriter(path))
                {
                    xml.Serialize(write, itemsToReport);
                }
            }
            catch(IOException e)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(e.Message);
            }

        }

        //private string CreateFilename()
        //{

        //}

        public string ReportPath;

        public void Create()
        {
            foreach (ProcessToWatch process in processes)
            {
                itemsToReport.Add(new ReportItem(process.ProcessName, process.processHistory));
            }

            SaveReport();
        }

        public void Create(DateTime fromTime, DateTime toTime)
        {
            foreach (ProcessToWatch process in processes)
            {
                List<ProcessHistoryDetail> temp = new List<ProcessHistoryDetail>();
                foreach (ProcessHistoryDetail detail in process.processHistory)
                {
                    if (detail.Start > fromTime && detail.Start <= toTime)
                    {
                        temp.Add(detail);
                    }
                }
                itemsToReport.Add(new ReportItem(process.ProcessName, temp));
            }
            
            SaveReport();
        }
    }
}
