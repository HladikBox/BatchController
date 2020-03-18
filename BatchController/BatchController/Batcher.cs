using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helpfooter
{
    class Batcher:IDisposable
    {
        string name = "";
        string url = "";
        int interval = 0;
        string expertresult = "";
        BatchController ctrl = null;

        public Batcher(string name, string url, int interval, string expertresult, BatchController ctrl)
        {
            this.name = name;
            this.url = url;
            this.interval = interval;
            this.expertresult = expertresult;
            this.ctrl = ctrl;
            this.ctrl.lblName.Text = name;
            this.ctrl.lblUrl.Text = url;
            this.ctrl.lblInterval.Text = "运行间隔:" + interval + "秒";
        }
        Thread thread;

        public void start()
        {
            flag = true;
            thread = new Thread(new ThreadStart(run));
            thread.Start();
        }

        public void stop()
        {
            this.flag = false;
            thread.Abort();
        }

        bool flag = false;

        private void run()
        {
            Thread.Sleep((new Random()).Next(1,30)*1000);
            while (flag)
            {
                int reminder = interval;
                DateTime runtime = DateTime.Now.AddSeconds(reminder);
                this.ctrl.pgbP.Maximum = interval;
                this.ctrl.pgbP.Minimum = 0;
                this.ctrl.lblNextTime.Text = "下次运行时间：" + runtime.ToString("yyyy-MM-dd HH:mm:ss"); ;
                while (reminder > 0)
                {
                    Thread.Sleep(1000);
                    reminder--;
                    this.ctrl.pgbP.Value = interval - reminder;
                    if (reminder == 0)
                    {
                        try
                        {

                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                            request.Method = "GET";
                            request.Accept = "text/html, application/xhtml+xml, */*";
                            request.ContentType = "application/json";

                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                            {
                                string ret = reader.ReadToEnd();
                                this.ctrl.txtResult.Text = ret;
                            }
                        }
                        catch(Exception ex) {

                            this.ctrl.txtResult.Text = ex.ToString();
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            this.stop();
        }
    }
}
