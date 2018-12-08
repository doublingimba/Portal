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

        
        //初始化
        private void MyInit()
        {

            //标题显示程序启动时间
            this.Text += "              开启时间：" + DateTime.Now.ToString();

            //根据数据生成界面
            MyData myData = MyData.ReadFromFile("datas.xml");
            for (int iTab = 0; iTab < myData.tabList.Count; iTab++)
            {
                MyTab myTab = myData.tabList[iTab];

                // tabPage1
                TabPage page = new TabPage();
                tabControl1.Controls.Add(page);
                page.Location = new System.Drawing.Point(4, 22);
                page.Name = "tabPage" + iTab;
                page.Size = new System.Drawing.Size(425, 194);
                page.TabIndex = iTab;
                page.Text = myTab.name;
                page.UseVisualStyleBackColor = true;

                // flowLayoutPanel1
                FlowLayoutPanel flowLayout = new FlowLayoutPanel();
                page.Controls.Add(flowLayout);
                flowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                flowLayout.Location = new System.Drawing.Point(3, 3);
                flowLayout.Name = "flowLayoutPanel" + iTab;
                flowLayout.Size = new System.Drawing.Size(419, 188);
                flowLayout.TabIndex = iTab;
                flowLayout.AutoScroll = true;

                //Button
                for (int iBtn = 0; iBtn < myTab.btnList.Count; iBtn++)
                {
                    MyBtn myBtn = myTab.btnList[iBtn];

                    Button btn = new Button();
                    btn.Location = new System.Drawing.Point(3, 3);
                    btn.Name = myBtn.name;
                    btn.Size = new System.Drawing.Size(73, 44);
                    btn.TabIndex = iBtn;
                    btn.Text = myBtn.name;
                    btn.UseVisualStyleBackColor = true;
                    btn.Click += (object sender2, EventArgs e2) =>
                    {
                        System.Diagnostics.Process.Start(myBtn.path);
                    };

                    flowLayout.Controls.Add(btn);
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //界面定位到右下角
            this.Location = new Point(
            Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width,
            Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height);
            //初始化界面
            MyInit();
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

        //通知栏单击显示窗口和任务栏
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }
             
        
    }
}
