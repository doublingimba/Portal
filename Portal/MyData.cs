using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal
{
    class MyData
    {
        public string tag { get; set; }
        public List<BtnData> datas { get; set; }
    }

    class BtnData
    {
        public string name { get; set; }
        public string path { get; set; }
    }


}
