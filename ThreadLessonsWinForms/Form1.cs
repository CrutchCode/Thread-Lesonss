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
        DownloadFile downloadFile1;
        DownloadFile downloadFile2;
        public Form1()
        {
            InitializeComponent();
        }
        //void ProgresBarChange(int progress)
        //{
        //    Action action = () => progressBar1.Value = progress;
        //    Invoke(action);
        //}
        //void ProgresBarChange1(int progress)
        //{
        //    Action action = () => progressBar2.Value = progress;
        //    Invoke(action);
        //}
        //void ProgresBarChange2(int progress)
        //{ 
        //    Action action = () => progressBar3.Value = progress;
        //    Invoke(action);
        //}
        //void DW()
        //{
        //    downloadFile = new DownloadFile();
        //    downloadFile.ProgressBar += ProgresBarChange;
        //    //downloadFile.ProgressBar1 += ProgresBarChange1;
        //    //downloadFile.ProgressBar2 += ProgresBarChange2;

        //    downloadFile.Download();
        //    //    downloadFile.Download1();
        //    //    downloadFile.Download2();
        //downloadFile = new DownloadFile();
        //downloadFile.ProgressBar += ProgresBarChange;
        //    downloadFile.ProgressBar1 += ProgresBarChange1;
        //    downloadFile.ProgressBar2 += ProgresBarChange2;

        //    button.Enabled = false;
        //    Thread thread = new Thread(downloadFile.Download);
        //thread.Start();
        //    Thread thread1 = new Thread(downloadFile.Download1);
        //thread1.Start();
        //    Thread thread2 = new Thread(downloadFile.Download2);
        //thread2.Start();
        //    //button1.Enabled = true;
        //}

        async void LoadStreams()
        {
            downloadFile = new DownloadFile(FirstUrl.Text, Path.GetFileName(FirstUrl.Text));
            downloadFile1 = new DownloadFile(SecondUrl.Text, Path.GetFileName(SecondUrl.Text));
            downloadFile2 = new DownloadFile(ThirdUrl.Text, Path.GetFileName(ThirdUrl.Text));

            downloadFile.client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
            downloadFile1.client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback1);
            downloadFile2.client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback2);

            await Task.Factory.StartNew(downloadFile.Download);
            await Task.Factory.StartNew(downloadFile1.Download);
            await Task.Factory.StartNew(downloadFile2.Download);

            

        }
        void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            Action action = () => progressBar1.Value = e.ProgressPercentage;
            Invoke(action);
        }
        void DownloadProgressCallback1(object sender, DownloadProgressChangedEventArgs e)
        {
            Action action = () => progressBar2.Value = e.ProgressPercentage;
            Invoke(action);
        }
        void DownloadProgressCallback2(object sender, DownloadProgressChangedEventArgs e)
        {
            Action action = () => progressBar3.Value = e.ProgressPercentage;
            Invoke(action);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button.Enabled = false;
            LoadStreams();

        }
    }
}
