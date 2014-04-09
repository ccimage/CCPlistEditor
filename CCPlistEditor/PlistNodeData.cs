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
                        value_number = Convert.ToDecimal(oldvalue);
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
            switch (nodeType)
            {
                case Constant.NodeTypeDefine.boolean:
                    return value_bool;
                    break;
                case Constant.NodeTypeDefine.datetime:
                    return value_date;
                    break;
                case Constant.NodeTypeDefine.number:
                    return value_number;
                    break;
                case Constant.NodeTypeDefine.text:
                    return value_string;
                    break;
            }
            return "";
        }
    }
}
