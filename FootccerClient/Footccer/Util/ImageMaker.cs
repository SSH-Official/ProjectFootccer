using FootccerClient.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootccerClient.Footccer.Util
{
    public class ImageMaker
    {
        public Dictionary<string, Image> ImageCache { get; set; } = new Dictionary<string, Image>();
        public Queue<string> URLQueue { get; set; } = new Queue<string>();
        public int Threshold { get; set; }

        public ImageMaker(int threshold = 50)
        {
            this.Threshold = threshold;
        }

        public Image GetImageFromURL(string url)
        {
            if (url.Substring(0, 4).ToLower() != "http")
            {
                return FindResource(url);
            }
            using (WebClient client = new WebClient())
            {
                if (ImageCache.ContainsKey(url)) { return ImageCache[url]; }

                byte[] imgArray;
                imgArray = client.DownloadData(url);
                using (MemoryStream memstr = new MemoryStream(imgArray))
                {
                    Image img = Image.FromStream(memstr);
                    EnqueueCache(url, img);
                    return img;
                }
            }
        }

        private Image FindResource(string objectName)
        {
            Image img = (Image)Properties.Resources.ResourceManager.GetObject(objectName);
            
            if (img == null) throw new Exception($"{objectName}이 발견되지 않습니다.");

            return img;
        }

        private void EnqueueCache(string url, Image img)
        {
            URLQueue.Enqueue(url);
            ImageCache[url] = img;
            if (URLQueue.Count > Threshold)
            {
                string urlToDelete = URLQueue.Dequeue();
                ImageCache[urlToDelete].Dispose();
                ImageCache.Remove(urlToDelete);
                System.GC.Collect();
            }
        }
    }
}
