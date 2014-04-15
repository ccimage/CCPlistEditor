using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CCPlistEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region 运行一次后销毁这些代码 >>> 生成多语言描述文件
            /*
            //FormMain
            Form frm = new FormMain();
            CLanguage language = new CLanguage();
            LanguageForm frmLan = new LanguageForm();
            frmLan.Name = frm.Name;
            frmLan.Controls = language.GetAllControls(frm, null);
            frmLan.Toolbars = language.GetToolStripItems(frm, "toolStrip1");
            language.Forms.Add(frmLan);
            LanguageForm frmLan2 = new LanguageForm();
            //FormAbout
            frm = new AboutBox();
            frmLan2.Name = frm.Name;
            frmLan2.Controls = language.GetAllControls(frm, null);
            language.Forms.Add(frmLan2);

            language.Serialize(Application.StartupPath + "\\default_language.xml");
            */
            #endregion
            Application.Run(new FormMain());
        }
    }
}
