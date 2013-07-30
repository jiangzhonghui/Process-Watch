using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ProcesyTest
{
    public static class FakeProcessReport
    {

        public static void CreateFakeHistory(int positions)
        {
            List<ProcessHistoryDetail> fakeHistory = new List<ProcessHistoryDetail>();
            Random rnd = new Random();
            const int maxSec = 43200; //12h


            DateTime da = new DateTime(2005, 07, 08);
            DateTime db = da.AddSeconds(rnd.Next(maxSec));

            for (int i = 0; i < positions; i++)
            {
                ProcessHistoryDetail t = new ProcessHistoryDetail(da, db);
                fakeHistory.Add(new ProcessHistoryDetail(t));

                da = db.AddSeconds(rnd.Next(maxSec));
                db = da.AddSeconds(rnd.Next(maxSec));
            }

            XmlSerializer fakeSerializer = new XmlSerializer(typeof(List<ProcessHistoryDetail>));

            using (StreamWriter write = new StreamWriter(Path.GetRandomFileName() + ".xml"))
            {
                try
                {
                    fakeSerializer.Serialize(write, fakeHistory);
                }
                catch(IOException)
                {

                }
            }
        }



    }
}
