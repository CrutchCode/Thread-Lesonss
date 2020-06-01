using System;
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
        public Form1()
        {
            InitializeComponent();
        }
        void ProgresBarChange(int progress)
        {
            Action action = () => progressBar1.Value = progress;
            Invoke(action);
        }
        void ProgresBarChange1(int progress)
        {
            Action action = () => progressBar2.Value = progress;
            Invoke(action);
        }
        void ProgresBarChange2(int progress)
        { 
            Action action = () => progressBar3.Value = progress;
            Invoke(action);
        }
        //void DW()
        //{
        //    downloadFile = new DownloadFile();
        //    downloadFile.ProgressBar += ProgresBarChange;
        //    //downloadFile.ProgressBar1 += ProgresBarChange1;
        //    //downloadFile.ProgressBar2 += ProgresBarChange2;

        //    downloadFile.Download();
        //    //    downloadFile.Download1();
        //    //    downloadFile.Download2();
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            downloadFile = new DownloadFile();
            downloadFile.ProgressBar += ProgresBarChange;
            downloadFile.ProgressBar1 += ProgresBarChange1;
            downloadFile.ProgressBar2 += ProgresBarChange2;

            button1.Enabled = false;
            Thread thread = new Thread(downloadFile.Download);
            thread.Start();
            Thread thread1 = new Thread(downloadFile.Download1);
            thread1.Start();
            Thread thread2 = new Thread(downloadFile.Download2);
            thread2.Start();
            //button1.Enabled = true;
        }
    }
}
