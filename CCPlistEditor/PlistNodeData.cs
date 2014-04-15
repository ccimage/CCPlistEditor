using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCPlistEditor
{
    public class PlistNodeData
    {
        public Constant.NodeTypeDefine nodeType { get; set; }
        public string key { get; set; }
        public string value_string { get; set; }
        public double value_number { get; set; }
        public bool value_bool { get; set; }
        public DateTime value_date { get; set; }
        public string uniquekey { get; set; }
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
        public void SetNewValue(object oldvalue)
        {
            try
            {
                switch (nodeType)
                {
                    case Constant.NodeTypeDefine.boolean:
                        value_bool = Convert.ToBoolean(oldvalue);
                        break;
                    case Constant.NodeTypeDefine.datetime:
                        value_date = Convert.ToDateTime(oldvalue);
                        break;
                    case Constant.NodeTypeDefine.number:
                        value_number = Convert.ToDouble(oldvalue);
                        break;
                    case Constant.NodeTypeDefine.text:
                        value_string = oldvalue.ToString();
                        break;
                }
            }
            catch
            {
                ResetDefaultValue();
            }
        }
        public object GetOldValue()
        {
            object oldval = "";
            switch (nodeType)
            {
                case Constant.NodeTypeDefine.boolean:
                    oldval = value_bool;
                    break;
                case Constant.NodeTypeDefine.datetime:
                    oldval = value_date;
                    break;
                case Constant.NodeTypeDefine.number:
                    oldval = value_number;
                    break;
                case Constant.NodeTypeDefine.text:
                    oldval = value_string;
                    break;
            }
            return oldval;
        }

        public PlistNodeData DeepCopy()
        {
            PlistNodeData newData = new PlistNodeData();
            newData.key = this.key;
            newData.nodeType = this.nodeType;
            newData.value_bool = this.value_bool;
            newData.value_date = this.value_date;
            newData.value_number = this.value_number;
            newData.value_string = this.value_string;
            return newData;
        }
    }
}
