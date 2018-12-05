using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

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
            this.Text += "       开启时间：" + DateTime.Now.ToString();

            //加载文件到内存
            string configPath = System.Windows.Forms.Application.StartupPath + "/datas.json";
            if (!File.Exists(configPath))
            {
                // 创建默认文件
                FileStream fs = new FileStream(configPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.WriteLine("[");
                sw.WriteLine("  {");
                sw.WriteLine("    \"tag\" : \"网站\",");
                sw.WriteLine("    \"datas\" : [");
                sw.WriteLine("      {");
                sw.WriteLine("        \"name\" : \"GitHub\",");
                sw.WriteLine("        \"path\" : \"https://github.com\"");
                sw.WriteLine("      }");
                sw.WriteLine("    ]");
                sw.WriteLine("  },");
                sw.WriteLine("  {");
                sw.WriteLine("    \"tag\" : \"文件夹\",");
                sw.WriteLine("    \"datas\" : [");
                sw.WriteLine("      {");
                sw.WriteLine("        \"name\" : \"C盘\",");
                sw.WriteLine("        \"path\" : \"C:/\"");
                sw.WriteLine("      }");
                sw.WriteLine("    ]");
                sw.WriteLine("  },");
                sw.WriteLine("  {");
                sw.WriteLine("    \"tag\" : \"程序\",");
                sw.WriteLine("    \"datas\" : [");
                sw.WriteLine("      {");
                sw.WriteLine("        \"name\" : \"命令行\",");
                sw.WriteLine("        \"path\" : \"CMD\"");
                sw.WriteLine("      }");
                sw.WriteLine("    ]");
                sw.WriteLine("  }");
                sw.WriteLine("]");
                sw.Close();
                fs.Close();
            }
            
            StreamReader sr = new StreamReader(configPath, Encoding.UTF8);
            String line;
            string jsonString = "";//保存读取到的json字符串
            while ((line = sr.ReadLine()) != null)
            {
                jsonString = jsonString + line.ToString();
            }
            sr.Close();

            Console.WriteLine(jsonString);


            //解析数据
            List<MyData> itemList = JsonConvert.DeserializeObject<List<MyData>>(jsonString);//所有数据

            //根据数据生成界面
            for (int i = 0; i < itemList.Count; i++)
            {
                MyData myData = itemList[i];

                // tabPage1
                TabPage page = new TabPage();
                tabControl1.Controls.Add(page);
                page.Location = new System.Drawing.Point(4, 22);
                page.Name = "tabPage" + i;
                page.Size = new System.Drawing.Size(425, 194);
                page.TabIndex = i;
                page.Text = myData.tag;
                page.UseVisualStyleBackColor = true;

                // flowLayoutPanel1
                FlowLayoutPanel flowLayout = new FlowLayoutPanel();
                page.Controls.Add(flowLayout);
                flowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                flowLayout.Location = new System.Drawing.Point(3, 3);
                flowLayout.Name = "flowLayoutPanel" + i;
                flowLayout.Size = new System.Drawing.Size(419, 188);
                flowLayout.TabIndex = i;
                flowLayout.AutoScroll = true;

                //Button
                for (int iBtn = 0; iBtn < myData.datas.Count; iBtn++)
                {
                    BtnData btnData = myData.datas[iBtn];

                    Button btn = new Button();
                    btn.Location = new System.Drawing.Point(3, 3);
                    btn.Name = btnData.name;
                    btn.Size = new System.Drawing.Size(73, 44);
                    btn.TabIndex = 0;
                    btn.Text = btnData.name;
                    btn.UseVisualStyleBackColor = true;
                    btn.Click += (object sender2, EventArgs e2) =>
                    {
                        System.Diagnostics.Process.Start(btnData.path);
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

        //通知栏双击显示窗口和任务栏
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }
             
        
    }
}
