using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        #region SystemSetting

        //界面定位到右下角
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(
            Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width,
            Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height);
        }

        //最小化隐藏窗口和任务栏
        protected override void OnDeactivate(EventArgs e)
        {

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
            base.OnDeactivate(e);
        }

        //通知栏双击显示窗口和任务栏
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        #endregion

        #region Function
        private void Baidu_Search_Click(object sender, EventArgs e)
        {
            string path = "https://www.baidu.com/";
            System.Diagnostics.Process.Start(path);
        }


        private void Baidu_FanYi_Click(object sender, EventArgs e)
        {
            string path = "https://fanyi.baidu.com/";
            System.Diagnostics.Process.Start(path);
        }

        private void Baidu_Pan_Click(object sender, EventArgs e)
        {
            string path = "https://pan.baidu.com/";
            System.Diagnostics.Process.Start(path);
        }

        private void Baidu_Image_Click(object sender, EventArgs e)
        {
            string path = "http://image.baidu.com/";
            System.Diagnostics.Process.Start(path);
        }

        private void MS_Bing_Click(object sender, EventArgs e)
        {
            string path = "https://cn.bing.com/";
            System.Diagnostics.Process.Start(path);
        }

        private void MS_GitHub_Click(object sender, EventArgs e)
        {
            string path = "https://github.com/";
            System.Diagnostics.Process.Start(path);
        }

        private void MS_WinFormDoc_Click(object sender, EventArgs e)
        {
            string path = "https://docs.microsoft.com/en-us/dotnet/framework/winforms/index";
            System.Diagnostics.Process.Start(path);
        }

        private void MS_Doc_Click(object sender, EventArgs e)
        {
            string path = "https://docs.microsoft.com/zh-cn/?view=vs-2017";
            System.Diagnostics.Process.Start(path);
        }

        private void UE4_Doc_Click(object sender, EventArgs e)
        {
            string path = "http://api.unrealengine.com/CHN/index.html";
            System.Diagnostics.Process.Start(path);
        }

        private void UE4_AnswerHub_Click(object sender, EventArgs e)
        {
            string path = "https://answers.unrealengine.com/index.html";
            System.Diagnostics.Process.Start(path);
        }

        private void UE4_API_Click(object sender, EventArgs e)
        {
            string path = "http://api.unrealengine.com/INT/API/index.html";
            System.Diagnostics.Process.Start(path);
        }

        private void UE4_Forums_Click(object sender, EventArgs e)
        {
            string path = "https://forums.unrealengine.com/";
            System.Diagnostics.Process.Start(path);
        }

        private void UE4_Video_Click(object sender, EventArgs e)
        {
            string path = "http://space.bilibili.com/138827797";
            System.Diagnostics.Process.Start(path);
        }

        private void Steam_Click(object sender, EventArgs e)
        {
            string path = "https://store.steampowered.com/";
            System.Diagnostics.Process.Start(path);
        }

        private void SteamDB_Click(object sender, EventArgs e)
        {
            string path = "https://steamdb.info/";
            System.Diagnostics.Process.Start(path);
        }

        private void CPP_Click(object sender, EventArgs e)
        {
            string path = "http://www.cplusplus.com/reference/";
            System.Diagnostics.Process.Start(path);
        }

        private void Bilibili_Click(object sender, EventArgs e)
        {
            string path = "https://www.bilibili.com/";
            System.Diagnostics.Process.Start(path);
        }

        private void Cmd_Click(object sender, EventArgs e)
        {
            string path = "cmd.exe";
            System.Diagnostics.Process.Start(path);
        }

        private void Explorer_Click(object sender, EventArgs e)
        {
            string path = "explorer";
            System.Diagnostics.Process.Start(path);
        }

        private void Taskmgr_Click(object sender, EventArgs e)
        {
            string path = "taskmgr";
            System.Diagnostics.Process.Start(path);
        }

        private void SnippingTool_Click(object sender, EventArgs e)
        {
            //todo 系统找不到文件
            string path = "snippingtool";
            System.Diagnostics.Process.Start(path);
        }

        private void Mspaint_Click(object sender, EventArgs e)
        {
            string path = "mspaint";
            System.Diagnostics.Process.Start(path);
        }

        private void Calc_Click(object sender, EventArgs e)
        {
            string path = "calc";
            System.Diagnostics.Process.Start(path);
        }

        #endregion

        private void v1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
