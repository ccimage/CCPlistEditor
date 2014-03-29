using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCPlistEditor
{
    public class Constant
    {
        public enum NodeTypeDefine
        {
            unknown = 0,
            dict,
            array,
            text,
            number,
            boolean,
            datetime,
            nodetypecount,
        }
        public static readonly string datetimeformat = "yyyy-MM-ddTHH:mm:ssZ";
    }
}
