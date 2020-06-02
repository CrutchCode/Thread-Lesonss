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
        public WebClient client = new WebClient();
        DataFile dataFile = new DataFile();
        public DownloadFile(string _path, string _filename)
        {
            dataFile.Filename = _filename;
            dataFile.Path = _path;
        }

        public void Download()
        {
            using (client)
            {
                client.DownloadFileTaskAsync(dataFile.Path, dataFile.Filename);
            }
        }
    }
    public class DataFile
    {
        public string Path { get; set; }
        public string Filename { get; set; }
    }
}
