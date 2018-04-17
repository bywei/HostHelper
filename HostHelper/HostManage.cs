using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Microsoft.Win32;

namespace HostHelper
{
    public partial class HostManage : Form
    {
        public HostManage()
        {
            InitializeComponent();
        }
        /**程序退出标识
         * */
        private static Boolean exit = false;
        private Hashtable  groupDir ;
        private ArrayList settingInfoList ;
        private ToolStripMenuItem toolStripMenuItemDiy;
        private ToolStripMenuItem toolStripMenuItemDiyChild;
        private void Form1_Load(object sender, EventArgs e)
        {
            if(!IsAutoRun("HostHelper")){
                SetAutoRun("HostHelper", System.Environment.CurrentDirectory + "\\HostHelper.exe");
            }
            //this.Left = (int)((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2);
            //this.Top = (int)((Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);  

            if (setToolStripItem())
            {
                this.Visible = false;
                this.Opacity = 0;
            }
            else {
                MessageBox.Show("配置文件有错，请检查～！","温馨提示");
                this.Visible = true;
                this.Opacity = 100;
                readHostHelper();
            }

          
        }

        #region 设置host 菜单
        private bool setToolStripItem(){

            bool result=true;
            try
            {
                groupDir = getHostSettingInfo();

                foreach (DictionaryEntry group in groupDir)
                {
                    //检查菜单中是否存在
                    if (!hasToolStripMenuItem(group.Key.ToString()))
                    {
                        //设置组名
                        toolStripMenuItemDiy = new System.Windows.Forms.ToolStripMenuItem();
                        toolStripMenuItemDiy.Name = "ToolStripMenuItemHost";
                        toolStripMenuItemDiy.Size = new System.Drawing.Size(118, 22);
                        toolStripMenuItemDiy.Text = group.Key.ToString();
                        toolStripMenuItemDiy.Tag = group.Key.ToString();
                        toolStripMenuItemDiy.MergeIndex = 2;
                        toolStripMenuItemDiy.Click += new System.EventHandler(this.ToolStripMenuItemSetGroupHost_Click);
                        //添加到组
                        foreach (String settingInfo in (ArrayList)group.Value)
                        {
                            toolStripMenuItemDiyChild = new System.Windows.Forms.ToolStripMenuItem();
                            toolStripMenuItemDiyChild.Name = "ToolStripMenuItemHost";
                            toolStripMenuItemDiyChild.Size = new System.Drawing.Size(118, 22);
                            toolStripMenuItemDiyChild.Text = settingInfo.Split(' ')[1];
                            toolStripMenuItemDiyChild.Tag = settingInfo.Split(' ')[0];
                            toolStripMenuItemDiyChild.MergeIndex = 2;
                            toolStripMenuItemDiyChild.Click += new System.EventHandler(this.ToolStripMenuItemSetChildHost_Click);
                            toolStripMenuItemDiy.DropDownItems.Insert(toolStripMenuItemDiy.DropDownItems.Count, toolStripMenuItemDiyChild);
                        }
                        this.contextMenuStripHost.Items.Insert(contextMenuStripHost.Items.Count - 3, toolStripMenuItemDiy);
                    }
                }
            }catch(Exception ex){
                result = false;
            }
            return result;
        }
        #endregion

        private bool hasToolStripMenuItem(String key) {
            bool result = false;
            foreach (ToolStripMenuItem item in this.contextMenuStripHost.Items)
            {
               if(item.Text.Equals(key)){
                   result = true;
                   break;
               }
           }
            return result;
        }

        private bool hasToolStripDownMenuItem(String key)
        {
            bool result = false;
            foreach (ToolStripMenuItem item in this.contextMenuStripHost.Items)
            {
                if (item.Text.Equals(key))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        #region 程序退出
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            exit = true;
            Application.Exit();
        }
        #endregion
        #region 关于我们
        private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("程序员百味制作  交流网站：http://www.bywei.cn", "关于我们", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        #endregion

        #region Host管理
        private void ToolStripMenuItemManage_Click(object sender, EventArgs e)
        {
            readHostHelper();
        }
        #endregion

        #region 读取HostHelper.inc
        private void readHostHelper() {
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            if (!this.Visible)
            {
                this.Visible = true;
            }
            if (this.Opacity == 0)
            {
                this.Opacity = 100;
            }
            if (File.Exists("HostHelper.inc"))
            {
                this.richTextBoxHost.Text = "";
                FileStream hostSettingInfoStream = new FileStream("HostHelper.inc", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(hostSettingInfoStream);
                String readLine = "";
                while ((readLine = reader.ReadLine()) != null && !"".Equals(readLine))
                {
                    this.richTextBoxHost.Text += readLine.Trim() + "\n";
                }
                reader.Close();
                hostSettingInfoStream.Close();
            }
            else {
                MessageBox.Show("缺少配置文件 HostHelper.inc ","温馨提示");
            }
        }
        #endregion

        #region 保存host
        private void btnSave_Click(object sender, EventArgs e)
        {
            FileStream hostSettingInfoWriteStream = new FileStream("HostHelper.inc", FileMode.Truncate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(hostSettingInfoWriteStream);
            foreach (String settingInfo in this.richTextBoxHost.Text.Split('\n'))
            {
                if (!"".Equals(settingInfo))
                {
                    writer.WriteLine(settingInfo);
                }
            }
            writer.Flush();
            writer.Close();
            hostSettingInfoWriteStream.Close();
            this.Visible = false;

            setToolStripItem();
        }
        #endregion

        #region 获取配置信息
        private Hashtable getHostSettingInfo() {
            groupDir = new Hashtable();
            settingInfoList = new ArrayList();
            FileStream hostSettingInfoStream = new FileStream("HostHelper.inc", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(hostSettingInfoStream);
            int indexOfOne=0;
            int indexOfTwo = 0;
            String groupName="";
            String readLine = "";
            while ((readLine = reader.ReadLine()) != null && !"".Equals(readLine))
            {
                indexOfOne=readLine.IndexOf("#");
                indexOfTwo = readLine.IndexOf("##");
                if(indexOfOne == 0 && indexOfTwo ==-1){
                   groupName=readLine.Substring(1,readLine.Length-1);
                }
                else if (indexOfTwo!=0)
                {
                   settingInfoList.Add(readLine);
                }
                if (indexOfTwo == 0)
                {
                    groupDir.Add(groupName, settingInfoList);
                    settingInfoList = new ArrayList();
                }
            }
            reader.Close();
            hostSettingInfoStream.Close();
            return groupDir;
        }
        #endregion


       private void ToolStripMenuItemSetChildHost_Click(object sender, EventArgs e){
           String hostDomain = ((ToolStripItem)sender).Text;
           String hostIp = ((ToolStripItem)sender).Tag.ToString();
           String filePath=@"C:\WINDOWS\system32\drivers\etc\hosts";
           if(File.Exists(filePath)){
               FileStream hostSettingInfoWriteStream = new FileStream(filePath, FileMode.Truncate, FileAccess.Write);
               StreamWriter writer = new StreamWriter(hostSettingInfoWriteStream);
               writer.WriteLine(hostIp+" "+hostDomain);
               writer.Flush();
               writer.Close();
               hostSettingInfoWriteStream.Close();
           }else{
             MessageBox.Show("hosts文件不存在","温馨提示");
           }
           this.contextMenuStripHost.Hide();
        }

       private void ToolStripMenuItemSetGroupHost_Click(object sender, EventArgs e)
       {
            String hostGroup=((ToolStripItem)sender).Text;
            String filePath=@"C:\WINDOWS\system32\drivers\etc\hosts";
            if (File.Exists(filePath))
            {
                FileStream hostSettingInfoWriteStream = new FileStream(filePath, FileMode.Truncate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(hostSettingInfoWriteStream);
                foreach (String settingInfo in (ArrayList)groupDir[hostGroup])
                {
                    writer.WriteLine(settingInfo.Split(' ')[0] + " " + settingInfo.Split(' ')[1]);
                }
                writer.Flush();
                writer.Close();
                hostSettingInfoWriteStream.Close();
            }else
            {
                MessageBox.Show("hosts文件不存在", "温馨提示");
            }
            this.contextMenuStripHost.Hide();
       }

        private void HostManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exit)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        #region 开机启动
        public static bool SetAutoRun(string keyName, string filePath)
    {
        try
        {
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey runKey = hkml.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            runKey.SetValue(keyName, filePath);
            runKey.Close();
        }
        catch
        {
            return false;
        }
        return true;
    }
    /// <summary>
    /// 判断是否已经设置为开机启动
    /// </summary>
    /// <param name="keyName">注册表key</param>
    /// 楼雨：2010-12-1 16:43
    public bool IsAutoRun(string keyName)
    {
        try
        {
            bool _exit = false;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey runKey = hkml.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
 
            string[] subkeyNames;
            subkeyNames = runKey.GetValueNames();
            foreach (string kName in subkeyNames)
            {
                if (kName == keyName)
                {
                    _exit = true;
                    return _exit;
                }
            }
            return _exit;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    }


}
