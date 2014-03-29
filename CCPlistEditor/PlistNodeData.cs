using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCPlistEditor
{
    class PlistNodeData
    {
        public Constant.NodeTypeDefine nodeType { get; set; }
        public string key { get; set; }
        public string value_string { get; set; }
        public decimal value_number { get; set; }
        public bool value_bool { get; set; }
        public DateTime value_date { get; set; }

        public PlistNodeData()
        {
            ResetDefaultValue();
        }
        public void ResetDefaultValue()
        {
            value_string = null;
            value_number = 0;
            value_bool = false;
            value_date = DateTime.Now;
        }
    }
}
