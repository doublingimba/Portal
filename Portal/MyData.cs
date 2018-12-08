using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Portal
{
    class MyData
    {
        public List<MyTab> tabList { get; set; }

        public MyData()
        {
            tabList = new List<MyTab>();
        }

        //读取文件
        public static MyData ReadFromFile(string filePath)
        {
            string exePath = Environment.CurrentDirectory;
            string fullPath = exePath + "/" + filePath;

            //如果文件不存在，就创建一个默认的
            if (!File.Exists(fullPath))
            {
                MyData myData2 = new MyData();

                MyTab myTab = new MyTab();
                myData2.tabList.Add(myTab);
                myTab.name = "网站";
                MyBtn myBtn = new MyBtn();
                myTab.btnList.Add(myBtn);
                myBtn.name = "GitHub";
                myBtn.path = "https://github.com";

                myTab = new MyTab();
                myData2.tabList.Add(myTab);
                myTab.name = "文件夹";
                myBtn = new MyBtn();
                myTab.btnList.Add(myBtn);
                myBtn.name = "程序目录";
                myBtn.path = ".\\";

                myTab = new MyTab();
                myData2.tabList.Add(myTab);
                myTab.name = "程序";
                myBtn = new MyBtn();
                myTab.btnList.Add(myBtn);
                myBtn.name = "命令行";
                myBtn.path = "CMD";

                myData2.WriteToFile("datas.xml");
            }
            
            MyData myData = new MyData();
            
            XmlDocument xml = new XmlDocument();//初始化一个xml实例
            xml.Load(fullPath);//导入指定xml文件
            XmlNode root = xml.SelectSingleNode("/Root");//指定一个节点
            XmlNodeList tabList = root.ChildNodes;//所有的tab

            for (int iTab = 0; iTab < tabList.Count; iTab++)
            {
                XmlNode tabNode = tabList[iTab];

                MyTab myTab = new MyTab();
                myData.tabList.Add(myTab);
                myTab.name = tabNode.SelectSingleNode("./Name").InnerText;

                XmlNodeList btnList = tabNode.SelectNodes("./Btns/Btn");
                for (int iBtn = 0; iBtn < btnList.Count; iBtn++)
                {
                    XmlNode btnNode = btnList[iBtn];

                    MyBtn myBtn = new MyBtn();
                    myTab.btnList.Add(myBtn);
                    myBtn.name = btnNode.SelectSingleNode("./Name").InnerText;
                    myBtn.path = btnNode.SelectSingleNode("./Path").InnerText;
                }
            }

            return myData;
        }

        //写入文件
        public void WriteToFile(string filePath)
        {
            string exePath = Environment.CurrentDirectory;
            string fullPath = exePath + "/" + filePath;

            XmlDocument xml = new XmlDocument();
            xml.AppendChild(xml.CreateXmlDeclaration("1.0", "utf-8", null));
            
            XmlElement root = xml.CreateElement("Root");
            xml.AppendChild(root);

            for (int iTab = 0; iTab < tabList.Count; iTab++)
            {
                MyTab myTab = tabList[iTab];

                //加入标签
                XmlElement tab = xml.CreateElement("Tab");
                root.AppendChild(tab);
                
                XmlElement tabName = xml.CreateElement("Name");
                tab.AppendChild(tabName);
                tabName.InnerText = myTab.name;//标签名称

                XmlElement tabBtns = xml.CreateElement("Btns");
                tab.AppendChild(tabBtns);

                for (int iBtn = 0; iBtn < myTab.btnList.Count; iBtn++)
                {
                    MyBtn myBtn = myTab.btnList[iBtn];
                    //加入按钮
                    XmlElement btn = xml.CreateElement("Btn");
                    tabBtns.AppendChild(btn);

                    XmlElement btnName = xml.CreateElement("Name");
                    btn.AppendChild(btnName);
                    btnName.InnerText = myBtn.name;//按钮名称

                    XmlElement btnPath = xml.CreateElement("Path");
                    btn.AppendChild(btnPath);
                    btnPath.InnerText = myBtn.path;//按钮路径
                }
            }
            xml.Save(fullPath);
        }


    }

    class MyTab
    {
        public string name { get; set; }
        public List<MyBtn> btnList { get; set; }

        public MyTab()
        {
            btnList = new List<MyBtn>();
        }
    }

    class MyBtn
    {
        public string name { get; set; }
        public string path { get; set; }
    }


}
