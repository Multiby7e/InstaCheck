using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.IO;
using System.Threading;
using InstaCheck.Checker;

namespace InstaCheck //Created by Multibyte --- Hackforums.net
{
    public partial class frmMain : Form
    {
        public static int nThreads = 25;
        public static bool Working = false;
        public static string CheckerType = null;

        public static Thread[] MainThread = new Thread[1];
        public static Dictionary<int, int> ThreadStart = new Dictionary<int, int>();
        public static Dictionary<int, int> ThreadEnd = new Dictionary<int, int>();

        public static List<string> Usernames = new List<string>();
        public static List<string> WorkingUsernames = new List<string>();

        public frmMain()
        {
            InitializeComponent();
            MessageBox.Show("InstaCheck - Coded by Multibyte (Hackforums.net)");
            CheckForIllegalCrossThreadCalls = false;
            listUsernames.Sorting = SortOrder.Ascending;
        }
        static int EachCount = 0;
        private void btnBot_Click(object sender, EventArgs e)
        {
            if (!Working)
            {
                int Count = Usernames.Count;
                EachCount = Count / nThreads;
                int CurCount = 1;
                for (int i = 1; i < nThreads + 1; i++)
                {
                    ThreadStart[i - 1] = CurCount;
                    ThreadEnd[i - 1] = EachCount * i;
                    CurCount = EachCount * i;
                }
                
                MainThread = new Thread[nThreads];
                StartThreads(nThreads);
                btnBot.Text = "Stop";
                lblStatus.Text = "Checker started.";
                Working = true;
            }
            else
            {
                StopThreads();
                btnBot.Text = "Start";
                lblStatus.Text = "Waiting...";
                Working = false;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofd = new OpenFileDialog {Filter = "Text files|*.txt"};
            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                var Lines = File.ReadAllLines(Ofd.FileName);
                foreach (var Line in Lines)
                {
                    Usernames.Add(Line);
                }
            }
            nThreads = Usernames.Count / 2;
            lblStatus.Text = "Loaded " + Usernames.Count.ToString() + " usernames.";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listUsernames.Items.Clear();
        }

        public void StartThreads(int nThreads = 1)
        {
            if (chk_twi.Checked)
            {
                CheckerType = "Twitter";

            }else if (chk_inst.Checked)
            {
                CheckerType = "Instagram";
            }

            for (var i = 0; i < nThreads; i++)
            {
                MainThread[i] = new Thread(() => MainMethod(i, listUsernames, CheckerType))
                {
                    Name = String.Format("Working Thread: {0}", i),
                    IsBackground = true
                };
                MainThread[i].Start();
            }
        }

        public static void StopThreads()
        {
            foreach (var Thread in MainThread)
            {
                Thread.Abort();
            }
        }

        public static string GetHTML(string Url)
        {
            HttpWebRequest myRequest = (HttpWebRequest) WebRequest.Create(Url);
            WebHeaderCollection getHeaders = myRequest.Headers;
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string HTML = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();
            return HTML;
        }

        public static void MainMethod(int ThreadIndex, ListView MyList, string CheckType)
        {
            switch (CheckType)
            {
                case "Twitter":
                    for (var i = ThreadStart[ThreadIndex - 1]; i < ThreadEnd[ThreadIndex - 1]; i++)
                    {
                        var isExisting = Twitter.Exists(Usernames[i]);
                        if (!isExisting)
                            AddAvailable(Usernames[i], MyList);
                    }
                    break;
                case "Instagram":
                    for (var i = ThreadStart[ThreadIndex - 1]; i < ThreadEnd[ThreadIndex - 1]; i++)
                    {
                        var isExisting = Instagram.Exists(Usernames[i]);
                        if (!isExisting)
                            AddAvailable(Usernames[i], MyList);
                    }
                    break;
            }
        }

        public static void AddAvailable(string Username, ListView MyList)
        {
            string[] Row = { Username, "Available" };
            var Item = new ListViewItem(Row);
            if (WorkingUsernames.Contains(Username)) return;
            WorkingUsernames.Add(Username);
            MyList.Items.Add(Item);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var MyStream = new StreamWriter(Application.StartupPath + "/Usernames.txt"))
            {
                foreach (ListViewItem Item in listUsernames.Items)
                {
                    MyStream.WriteLine(Item.Text);
                }
            }
        }
    }
}