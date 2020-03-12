using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml.Linq;

namespace Helpfooter
{
    public partial class FormMain : Form
    {
        public FormMain(bool autostart)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.autostart = autostart;
        }

        bool autostart;

        private void FormMain_Load(object sender, EventArgs e)
        {
            string[] controlfiles= System.Configuration.ConfigurationSettings.AppSettings.GetValues("controlfile");
            if (controlfiles!=null&&controlfiles.Length > 0)
            {
                lblRootFile.Text = controlfiles[0];
            }
            if (autostart == true)
            {
                togglestart();
            }
        }

        private void BtnUploadPatch_Click(object sender, EventArgs e)
        {

            String patch = getFileFromDialog(new OpenFileDialog(), "选择批处理控制文件");
            if (patch != "")
            {
                Configuration config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config1.AppSettings.Settings.Remove("controlfile");
                config1.AppSettings.Settings.Add("controlfile", patch);
                config1.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                lblRootFile.Text = patch;
            }
        }

        string InitialDirectory = "C:\\";
        private string getFileFromDialog(FileDialog fileDialog, string title)
        {
            fileDialog.InitialDirectory = InitialDirectory;//初始化路径
            fileDialog.Filter = "xml files (*.xml)|*.xml;";//过滤选项设置，文本文件，所有文件。
            fileDialog.FilterIndex = 1;//当前使用第二个过滤字符串
            fileDialog.RestoreDirectory = true;//对话框关闭时恢复原目录
            fileDialog.Title = title;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                for (int i = 1; i <= fileDialog.FileName.Length; i++)
                {
                    if (fileDialog.FileName.Substring(fileDialog.FileName.Length - i, 1).Equals(@"\"))
                    {
                        //更改默认路径为最近打开路径
                        InitialDirectory = fileDialog.FileName.Substring(0, fileDialog.FileName.Length - i + 1);
                        return fileDialog.FileName;
                    }
                }

                return "";
            }
            else
            {
                return "";
            }
        }

        bool startbatch=false;
        void togglestart()
        {
            if (startbatch == false)
            {
                startbatchprocess();
            }
            else
            {
                stopbatchprocess();

            }
        }

        List<Batcher> listBatcher = new List<Batcher>();

        public void recyleBatcher()
        {
            foreach (var item in listBatcher)
            {
                item.Dispose();
            }
            listBatcher.Clear();
            this.pnlBatcher.Controls.Clear();
        }

        public void loadBatcher()
        {
            var doc = XDocument.Load(lblRootFile.Text);
            IEnumerable<XElement> node=doc.Descendants("projects");
            XElement projects=node.FirstOrDefault();
            IEnumerable<XElement> projectlist =projects.Descendants("project");
            foreach (XElement project in projectlist)
            {
                string env=project.Attribute("env").Value;
                string name = project.Attribute("name").Value;
                string pproject = project.Attribute("project").Value;
                string api= project.Attribute("api").Value;
                IEnumerable<XElement> node2 = project.Descendants("batchlist");
                XElement batchlistnode = node2.FirstOrDefault();
                IEnumerable<XElement> batchlist = batchlistnode.Descendants("batch");
                foreach (XElement batchnode in batchlist)
                {
                    string batchname = batchnode.Descendants("name").FirstOrDefault().Value;
                    string url = batchnode.Descendants("url").FirstOrDefault().Value;
                    int interval =Convert.ToInt32( batchnode.Descendants("interval").FirstOrDefault().Value);
                    if (env == "dev")
                    {
                        url = api + "/" + name + "/" + pproject + "/api/" + url;
                    }
                    else
                    {
                        url = api + "/api/" + url;
                    }
                    BatchController btctrl = new BatchController();
                    
                    Batcher bter = new Batcher(batchname, url, interval,"", btctrl);
                    bter.start();
                    listBatcher.Add(bter);
                    pnlBatcher.Controls.Add(btctrl);
                }
            }
        }


        void startbatchprocess()
        {
            string patch = lblRootFile.Text;
            if (patch == "")
            {
                MessageBox.Show("请选择批处理文件");
                return;
            }
            if (File.Exists(patch)==false)
            {
                MessageBox.Show("找不到批处理文件，请重新选择");
                return;
            }

            recyleBatcher();
            loadBatcher();




            btnStart.Text = "停止";
            startbatch = true;
        }
        void stopbatchprocess()
        {
            recyleBatcher();
            btnStart.Text = "开始";
            startbatch = false;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            togglestart();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopbatchprocess();
        }
    }
}
