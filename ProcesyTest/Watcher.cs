using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace ProcesyTest
{

    public class Watcher
    {
        delegate void UpdateListView(ProcessToWatch process);

        UpdateListView myDelegateUpdateListView;

        delegate void ListViewUse(string name);

        ListViewUse myDelegateAddNewProcess;

        public Dictionary<string, ListViewItem> listViewProcesses
        {
            private set;
            get;
        }

        Dictionary<string, ProcessToWatch> processes;
        
        public List<ProcessToWatch> Processes
        {
            private set {  }
            get
            {
                return processes.Values.ToList();
            }
        }

        ListView listView;

        public ListView ListView
        {
            set
            {
                listView = value;
            }
            get
            {
                return listView;
            }
        }

        private static readonly string listFilename;// = "list.xml";

        public Watcher()
        {
            this.listViewProcesses = new Dictionary<string, ListViewItem>();
            this.processes = new Dictionary<string, ProcessToWatch>();
            this.myDelegateUpdateListView = new UpdateListView(UpdateListViewMethod);
            this.myDelegateAddNewProcess = new ListViewUse(AddNewProcessMethod);
        }

        static Watcher()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string programName = Path.GetFileNameWithoutExtension(System.AppDomain.CurrentDomain.FriendlyName);
            //folder = Path.Combine(path, programName); 
            listFilename = Path.Combine(path, programName, "list.xml");
        }

        public ProcessToWatch GetProcessByName(string name)
        {
                return processes[name];
        }
              
        void AddNewProcessMethod(string name)
        {
            processes.Add(name, new ProcessToWatch(name));
            AddToListView(name);
            NLog.LogManager.GetCurrentClassLogger().Info("Add process: {0}", name);
        }

        void AddToListView(string name)
        {
            listViewProcesses.Add(name, new ListViewItem(name));

            //czztery puste miejsca na kolumny
            for (int i = 0; i < 4; i++)
                listViewProcesses[name].SubItems.Add("");

            ListView.Items.Add(listViewProcesses[name]);
        }

        public void LoadProcessName(string name)
        {
            //jesli jeszcze nie dodano takiego procesu lub nazwa jest niepoprawna
            if (!processes.ContainsKey(name) && !string.IsNullOrWhiteSpace(name))
            {
                ListView.Invoke(myDelegateAddNewProcess, name);
            }
        }

        public void DeleteProcessName(string name)
        {
            processes.Remove(name);
            ListView.Items.Remove(listViewProcesses[name]);
            listViewProcesses.Remove(name);
            NLog.LogManager.GetCurrentClassLogger().Info("Remove process: {0}", name);
        }

        public void LoadProcessName(string[] names)
        {
            foreach (string name in names)
            {
                LoadProcessName(name);
            }
        }

        //...

        public void Update()
        {
            foreach (ProcessToWatch process in Processes)
            {
                try
                {
                    process.Scan();
                    if(ListView.InvokeRequired)
                        ListView.Invoke(myDelegateUpdateListView, process);
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    if(ListView.InvokeRequired)
                        ListView.Invoke(new ListViewUse(DeleteProcessName), process.ProcessName);
                }     
            }
        }

        void UpdateListViewMethod(ProcessToWatch process)
        {
            /*
             * [0] name
             * [1] status
             * [2] start time
             * [3] duration
             * [4] end time
             * 
             * sprawdzanie firstCheck - aby uniknac ciaglego przypisywania tych samych wartosci do stringow
             *   
             * */
            
            ListViewItem lv;// = listViewProcesses[process.ProcessName];
            if (listViewProcesses.TryGetValue(process.ProcessName, out lv) == false)
            {
                //proba uzyskania juz usunietego elementu
                return;
            }

            //on
            if (process.Status == ProcessToWatch.ProcessStatus.on)
            {
                if (process.FirstCheck == true)
                {
                    //process.firstCheck = false;
                    string startTime = DateTimeFormatter.FormatShort(process.StartTime);
                    lv.SubItems[1].Text = "on";
                    lv.SubItems[2].Text = startTime;
                    lv.SubItems[0].ForeColor = System.Drawing.Color.DarkGreen;
                }

                string duration = TimeSpanFormatter.Format(process.Duration);
                if (lv.SubItems[3].Text != duration)
                    lv.SubItems[3].Text = duration;

            }
            //off / turned off
            else
            {
                if (process.FirstCheck == true)
                {
                    //process.firstCheck = false;
                    lv.SubItems[1].Text = "off";
                    lv.SubItems[0].ForeColor = System.Drawing.Color.Red;

                    //turned off
                    if (process.Status == ProcessToWatch.ProcessStatus.turnedOff)
                    {
                        lv.SubItems[4].Text = DateTimeFormatter.FormatShort(process.EndTime); //process.endTime.ToShortTimeString();
                    }
                }
            }

            //switch (process.Status)
            //{
            //    case ProcessToWatch.ProcessStatus.off:
            //        if (process.FirstCheck == true)
            //        {
            //            process.FirstCheck = false;

            //            lv.SubItems[1].Text = "off";
            //            lv.SubItems[0].ForeColor = System.Drawing.Color.Red;
            //        }
            //        break;
            //    case ProcessToWatch.ProcessStatus.on:
            //        if (process.FirstCheck == true)
            //        {
            //            process.FirstCheck = false;
            //            string startTime = DateTimeFormatter.FormatShort(process.StartTime);
            //            lv.SubItems[1].Text = "on";
            //            lv.SubItems[2].Text = startTime;
            //            lv.SubItems[0].ForeColor = System.Drawing.Color.DarkGreen;
            //        }

            //        string duration = TimeSpanFormatter.Format(process.Duration);
            //        if (lv.SubItems[3].Text != duration)
            //            lv.SubItems[3].Text = duration;

            //        break;
            //    case ProcessToWatch.ProcessStatus.turnedOff:
            //        if (process.FirstCheck == true)
            //        {
            //            process.FirstCheck = false;
            //            lv.SubItems[1].Text = "off";
            //            lv.SubItems[0].ForeColor = System.Drawing.Color.Red;
            //            lv.SubItems[4].Text = DateTimeFormatter.FormatShort(process.EndTime); //process.endTime.ToShortTimeString();
            //        }
            //        break;

            //}

        }

        public void SaveProcessesHistory()
        {
            foreach (var process in processes)
            {
                process.Value.SaveHistoryToFile();
            }
        }

        public void LoadEveryProcessInSystem()
        {
            Process[] pp = Process.GetProcesses();
            foreach (Process pr in pp)
            {
                this.LoadProcessName(pr.ProcessName);
            }
        }

         //* Zapis listy procesow do pliku:
         //* Klasa ProcessToWatch posiada dwa atrybuty ktore sa serializowane:
         //* 1. nazwa procesu, 2. czy proces ma byc aktualnie sprawdzany przez program
         //* W klasie, pozostale atrybuty sa ignorowane przez serializer
       

        public void SaveSetttings()
        {
            try
            {
                using (StreamWriter write = new StreamWriter(listFilename))
                {
                    
                    XmlSerializer xml = new XmlSerializer(typeof(List<ProcessToWatch>));
                    xml.Serialize(write, processes.Values.ToList());
                }
            }
            catch(IOException e)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(e.Message);
            }
        }

        public void LoadSettings()
        {
            try
            {
                using (StreamReader read = new StreamReader(listFilename))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<ProcessToWatch>));
                    List<ProcessToWatch> tempList = (List<ProcessToWatch>)xml.Deserialize(read);
                    
                    foreach(ProcessToWatch process in tempList)
                    {   
                        processes.Add(process.ProcessName, process);
                        AddToListView(process.ProcessName);
                    }
                }
            }
            catch(IOException e)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(e.Message);
            }

        }

    }
}
