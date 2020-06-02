using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using LessonsDownload;
using System.Net;

namespace ThreadLessonsWinForms
{
    public partial class Form1 : Form
    {
        DownloadFile downloadFile;
        //DownloadFile downloadFile1;
        //DownloadFile downloadFile2;
        static int counter = 0;
        public Form1()
        {
            InitializeComponent();
        }
        int GetAmountLines()
        {
            string text = InPutText.Text;
            int _nuberLines = 1;
            char _endline = '\n';
            for (int i = 0; i < InPutText.TextLength; i++)
            {
                if (InPutText.Text[i] == _endline)
                {
                    _nuberLines++;
                }
            }
            return _nuberLines;
        }
        string GetUrl(int count)
        {
            char endLine = '\n';
            string line = "";
            for (; count < InPutText.TextLength; count++)
            {
                if (InPutText.Text[count] == endLine)
                {
                    counter++;
                    break;
                }
                else
                {
                    line += InPutText.Text[count];
                    counter++;
                }
            }
            return line;
        }

        async void LoadStreams()
        {
            int _lines = GetAmountLines();
            for (int i = 0; i < _lines; i++)
            {
                string _pathUrl = GetUrl(counter);
                downloadFile = new DownloadFile(_pathUrl, Path.GetFileName(_pathUrl));
                downloadFile.client.DownloadProgressChanged += DownloadProgressCallback;                
                await Task.Factory.StartNew(downloadFile.Download);
            }
        }
        void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            Action action = () => progressBar1.Value = e.ProgressPercentage;
            Invoke(action);
        }
        //void DownloadProgressCallback1(object sender, DownloadProgressChangedEventArgs e)
        //{
        //    Action action = () => progressBar2.Value = e.ProgressPercentage;
        //    Invoke(action);
        //}
        //void DownloadProgressCallback2(object sender, DownloadProgressChangedEventArgs e)
        //{
        //    Action action = () => progressBar3.Value = e.ProgressPercentage;
        //    Invoke(action);
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            button.Enabled = false;
            LoadStreams();

        }
    }
}
