using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.JsonModel
{
    public class MenuModel
    {
        public class button
        {
            public string type { get; set; }
            public string name { get; set; }
            public string key { get; set; }
            public sub_button sb { get; set; }
        }

        public class sub_button
        {
            public string type { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }
    }
}
