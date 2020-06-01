using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace LessonsDownload
{
    public class DownloadFile
    {
        public event Action<int> ProgressBar;
        public event Action<int> ProgressBar1;
        public event Action<int> ProgressBar2;
        public void Download()
        {
            for (int i = 0; i <= 100; i++)
            {
                ProgressBar(i);
                Thread.Sleep(10);
            }
            string path = "https://toloka.to/photos/121204110646141807_f0_0.png";
            string filename = "121204110646141807_f0_0.png";
            WebClient client = new WebClient();
            client.DownloadFile(path, filename);
        }
        public void Download1()
        {
            for (int i = 0; i < 100; i++)
            {
                ProgressBar1(i);
                Thread.Sleep(10);
            }
            string path = "https://toloka.to/photos/180527042253642957_f0_0.jpg";
            string filename = "180527042253642957_f0_0.jpg";
            WebClient client = new WebClient();
            client.DownloadFile(path, filename);
        }
        public void Download2()
        {
            for (int i = 0; i < 100; i++)
            {
                ProgressBar2(i);
                Thread.Sleep(10);
            }
            string path = "https://simpsonsua.tv/photos/adventure-time/2.jpg";
            string filename = "2.jpg";
            WebClient client = new WebClient();
            client.DownloadFile(path, filename);
        }
    }
}
