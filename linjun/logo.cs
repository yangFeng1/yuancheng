
using DSkin.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static linjun.Form2;

namespace linjun
{
   
    public partial class logo : DSkinForm
    {

        //SDK接口
        public delegate void pRecvDataCallback(string p_pszData, int p_iSize,IntPtr user);
        public event pRecvDataCallback DataCallback;
        [DllImport("pss_client_sdk.dll")]//接口回调函数
        internal static extern void SDK_Init(pRecvDataCallback pRecvDataCallback, string Str, string url, int nPort);
        [DllImport("pss_client_sdk.dll")]//注册
        internal static extern int ClientRegister(string p_pszUuid);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        //全局变量
        bool windowFLag;//是否有打开窗口

    
        public logo()
        {
            InitializeComponent();
            init();
        }
        /// <summary>
        /// 窗口刚打开时初始化ui
        /// </summary>
        private void init()
        {
            //run
            IsRegister();
            //绑定委托
            DataCallback += new pRecvDataCallback(Callback.GetData);//接口返回数据回调
            //绑定事件
            GlobalData.Form2.SetMainFormTopMost += new Form2.SetMainFormTopMostHandle(Form2_SetMainFormTopMost);
            GlobalData.Form1.SetMainFormTopMost += new Form1.SetMainFormTopMostHandle(Form2_SetMainFormTopMost);
            //初始化SDK
            SDK_Init(DataCallback, null, GlobalData.DispatchIp, GlobalData.DispatchPort);
            //ui初始化
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetBounds(this);//获取屏幕信息
            GlobalData.Width = ScreenArea.Width; //屏幕宽度 
            GlobalData.Height = ScreenArea.Height; //屏幕高度
            GlobalData.logo = this;
            logoIcon.Tag = this;
            //GlobalData.BindMove(logoIcon);//给form1绑定窗口拖动
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Location = new Point(GlobalData.Width - 28, 100);
            SetWindowPos(this.Handle, 0, 0, 0, 0, 0, 1 | 2);//将logo置于窗口最顶层
        }
        /// <summary>
        /// 判断是否注册  没有注册调用注册接口
        /// </summary>
        public void IsRegister()
        {
            if (!VerifyRegister()) {
                string uuid = GetSysIDMethod();//获取电脑的uuid
              int res =  ClientRegister(uuid);
                if (res <= 0)//大于0表示成功
                {
                    //MessageBox.Show("注册失败");
                }
            }
        }

        /// <summary>
        /// 检测是否注册
        /// </summary>
        /// <returns></returns>  
        private bool VerifyRegister()
        {
            try
            {
                string config = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "RegisterConfig.txt");
                ResultData JsonStr = JsonConvert.DeserializeObject<ResultData>(config);
                GlobalData.clientid = JsonStr.Data.clientid;
                //   GlobalData.Pwd = JsonStr.pwd;
                return true;
            }
            catch
            {
               // MessageBox.Show("EEE");
                return false;
            }
        }
       
        /// <summary>
        /// 退出会议时隐藏窗口
        /// </summary>
        /// <param name="topmost"></param>
        private void Form2_SetMainFormTopMost(bool topmost) 
        {
            MessageBox.Show("sss");
            windowFLag = false;
            logoIcon.BackgroundImage = linjun.Properties.Resources.meet_logo_translucent;
        }
        /// <summary>
        /// 点击图标打开界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dSkinPictureBox1_Click(object sender, EventArgs e)
        {
            bool flag = GlobalData.connectStatus;
            if (windowFLag)
            {
                if (flag)
                {
                   GlobalData.Form2.Hide();
                }
                else
                {
                    GlobalData.Form1.Hide();
                }
                windowFLag = false;
                logoIcon.BackgroundImage = linjun.Properties.Resources.meet_logo_translucent;
            }
            else
            {
                if (flag)
                {
                    GlobalData.Form2.Show();

                }
                else
                {
                    GlobalData.Form1.Show();
                }
                windowFLag = true;
                logoIcon.BackgroundImage = linjun.Properties.Resources.meet_logo_opacity;
            }
        }

        private void logo_Load(object sender, EventArgs e)
        {
            
        }
        
        

        private void notifyIcon1_MouaseDoubleClick(object sender, EventArgs e)
        {
          //  if(e.Button == MouseButtons.Right)
           // {
            //    MessageBox.Show("点解");
           // }
        }

        private void notifyIconListOut_Click(object sender, EventArgs e)//右下角任务栏退出程序
        {
            this.notifyIcon1.Dispose();
            Environment.Exit(0);
        }
        private string GetSysIDMethod()
        {
            try
            {
                string sysId = "";
                Process da = new Process();
                da.StartInfo.FileName = "cmd.exe";
                da.StartInfo.Arguments = "/k cscript %WINDIR%\\SYSTEM32\\SLMGR.VBS /DTI";
                da.StartInfo.UseShellExecute = false;       //是否使用操作系统shell启动
                da.StartInfo.RedirectStandardInput = true;  //接受来自调用程序的输入信息
                da.StartInfo.RedirectStandardOutput = true; //由调用程序获取输出信息
                da.StartInfo.RedirectStandardError = true;  //重定向标准错误输出
                da.StartInfo.CreateNoWindow = true;         //不显示程序窗口
                da.Start();                                 //启动程序
                da.StandardInput.WriteLine("exit");
                string strRst = da.StandardOutput.ReadToEnd();
                string[] readLine = strRst.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string id = readLine[2].Split(':')[1].Trim();
                sysId = id;
                return sysId;
            }
            catch (Exception ex)
            {
                //string getSysIdError = Application.StartupPath + "\\SysteamLog\\GetSysIdError.log";
                //CheckVideoPath check = new CheckVideoPath(getSysIdError);
                //check.Write(ex.Message);
                return "unknow";
            }
        }
        public class ResultData//数据处理格式
        {
            public string pwd { get; set; }
            public string result { get; set; }
            public string ErrCode { get; set; }
            public string ErrMsg { get; set; }
            public string clientid { get; set; }
            public string ip { get; set; }
            public string meetid { get; set; }
            public string verifycode { get; set; }
            public string Cmd { get; set; }
            public Data Data { get; set; }
        }
        public class Data
        {
            public string pwd { get; set; }
            public string result { get; set; }
            public string ErrCode { get; set; }
            public string ErrMsg { get; set; }
            public string clientid { get; set; }
            public string ip { get; set; }
            public string MeetId { get; set; }
            public string verifycode { get; set; }
            public string city { get; set; }
            public string province { get; set; }
        }
    }
}
