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
    //observedProcess - referencja na proces, ktory obserwujemy
    //gdy proces zostanie zakonczony (event):
    //sprawdzamy czy istnieja inne procesy o tej samej nazwie:
    //jesli tak:
    //  pierwsza pobrana referencje przypisujemy do observedProcess - kontynuujemy
    //jesli nie:
    //  aktualne czasy dodajemy do historii i zapisujemy

    [Serializable]
    public class ProcessToWatch
    {
        public enum ProcessStatus { off, on, turnedOff };

        [XmlIgnore]
        Process observedProcess;

        [XmlIgnore]
        ProcessHistoryDetail actualTimeDetail;

        [XmlIgnore]
        public List<ProcessHistoryDetail> processHistory;

        [XmlIgnore]
        ProcessStatus status;

        [XmlIgnore]
        public ProcessStatus Status
        {
            private set
            {
                status = value;
            }
            get
            {
                return status;
            }
        }

  
        [XmlIgnore]
        bool firstCheck;
        //pierwszy raz proces posiada okreslony stan (po wykryciu true zmieniamy na false)
        [XmlIgnore]
        public bool FirstCheck
        {
            set
            {
                firstCheck = value;
            }
            get
            {
                bool toReturn = false;
                if (firstCheck == true)
                {
                    firstCheck = false;
                    toReturn = true;;
                }

                return toReturn;
            }
        }

        [XmlIgnore]
        public DateTime StartTime
        {
            private set
            {
                actualTimeDetail.Start = value;
            }
            get
            {
                return actualTimeDetail.Start;
            }
        }

        [XmlIgnore]
        public DateTime EndTime
        {
            private set
            {
                actualTimeDetail.End = value;
            }
            get
            {
                return actualTimeDetail.End;
            }
        }

        [XmlIgnore]
        public TimeSpan Duration
        {
            private set
            {
                actualTimeDetail.Duration = value;
            }
            get
            {
                return DateTime.Now - StartTime;
            }
        }

        [XmlIgnore]
        bool watch;

        [XmlIgnore]
        public bool Watch
        {
            get { return watch; }
            set { watch = value; }
        }

        public string WatchXml
        {
            set
            {
                watch = bool.Parse(value);
            }
            get
            {
                return watch.ToString();
            }
        }

        [XmlIgnore]
        string processName;

        public string ProcessName
        {
            set
            {
                processName = value;
                //jesli zmieniamy nazwe procesu to musimy wczytac mu jego historie
                //umieszczone tutaj, poniewaz konstruktor bezargumentowy (XML serialize)
                //nie zna jeszcze nazwy procesu i dopiero po przypisaniu nazwy mozna wczytac historie
                LoadHistoryFromFile();
            }
            get
            {
                return processName;
            }
        }

        [XmlIgnore]
        XmlSerializer historySerializer;

        [XmlIgnore]
        private static readonly string folder;

        [XmlIgnore]
        private const string extension = ".xml";


        public ProcessToWatch() 
        {
            this.historySerializer = new XmlSerializer(typeof(List<ProcessHistoryDetail>));
            this.actualTimeDetail = new ProcessHistoryDetail();
            Status = ProcessStatus.off;
            FirstCheck = true;
            watch = true;
        }

        static ProcessToWatch()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string programName = Path.GetFileNameWithoutExtension(System.AppDomain.CurrentDomain.FriendlyName);
            folder = Path.Combine(path, programName, "history");
        }

        public ProcessToWatch(string processName) : this()
        {
            this.ProcessName = processName;
        }

        public override string ToString()
        {
            return ProcessName;
        }

        private void ProcessToWatch_Exited(object sender, System.EventArgs e)
        {
            //sprawdzamy czy byl to jedyny proces o tej nazwie
            Process[] processes = Process.GetProcessesByName(ProcessName);
            if (!(processes.Length > 0))
            {
                SaveHistoryToFile();
                FirstCheck = true;
                Status = ProcessStatus.turnedOff;
            }
            else
            {
                SetProcessToObserve(processes.First());
            }
        }

        void LoadHistoryFromFile()
        {
            //zaladowanie istniejacej historii
            //sprawdzamy istnienie pliku
            
            string filename = processName + extension;

            try
            {
                using (StreamReader read = new StreamReader(Path.Combine(folder, filename)))
                {
                    //wczytujemy do kolekcji
                    processHistory = (List<ProcessHistoryDetail>)historySerializer.Deserialize(read);
                }
            }
            catch (FileNotFoundException)
            {
                //plik nie istnieje
                //tworzymy nowa kolekcje
                processHistory = new List<ProcessHistoryDetail>();
            }
            catch (DirectoryNotFoundException)
            {
                NLog.LogManager.GetCurrentClassLogger().Warn(String.Format("Folder {0} does not exist", folder));
                Directory.CreateDirectory(folder);
                NLog.LogManager.GetCurrentClassLogger().Info(String.Format("Create folder {0}", folder));
                processHistory = new List<ProcessHistoryDetail>();
            }
        }

        //dodaje ostatni czas do historii i zapisuje wszystko do pliku
        public void SaveHistoryToFile()
        {
            if (status == ProcessStatus.on)
            {
                EndTime = DateTime.Now;
                actualTimeDetail.Duration = actualTimeDetail.End - actualTimeDetail.Start;
                processHistory.Add(new ProcessHistoryDetail(actualTimeDetail));
            }

            try
            {
                using (StreamWriter write = new StreamWriter(Path.Combine(folder, processName + extension)))
                {
                    historySerializer.Serialize(write, processHistory);
                }
            }
            catch(IOException e)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(e.Message);
            }

        }

        void SetProcessToObserve(Process process)
        {
            try
            {
                observedProcess = process;
                observedProcess.EnableRaisingEvents = true;
                observedProcess.Exited += ProcessToWatch_Exited;
            }
            catch(System.ComponentModel.Win32Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(String.Format("{0}: {1}", processName, e.Message));
                MessageBox.Show(e.Message + "\nRun as Administrator", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw;
            }
        }

        public bool Scan()
        {
            bool detected = false;
            Process[] processes = Process.GetProcessesByName(ProcessName);

            //jesli proces nie jest aktywny i istnieja procesy o takiej nazwie
            if (!(Status == ProcessStatus.on) && processes.Length > 0)
            {
                StartTime = DateTime.Now;
                Status = ProcessStatus.on;
                FirstCheck = true;
                detected = true;
                SetProcessToObserve(processes.First()); //[0]?
            }

            return detected;
        }

    }

}
