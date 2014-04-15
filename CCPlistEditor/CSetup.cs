using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CCPlistEditor
{
    public class CSetup
    {
        public string cfguiLanguage = "en-us";
        
        #region XML的序列化和反序列化

        /// <summary>
        /// 序列化为XML字符串
        /// </summary>
        /// <returns></returns>
        public void Serialize(string filename)
        {
            string strConfig = CDefines.Serialize(this, typeof(CSetup));
            File.WriteAllText(filename, strConfig, Encoding.UTF8);
        }

        /// <summary>
        /// 反序列化ＸＭＬ字符串为对象
        /// </summary>
        /// <param name="xmlSource"></param>
        /// <returns></returns>
        public static CSetup Deserialize(string filename)
        {
            object obj = CDefines.Deserialize(filename, typeof(CSetup));
            if (obj == null)
                return new CSetup();
            else
                return (CSetup)obj;
        }

        #endregion
    }
}
