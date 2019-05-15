using DSkin.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        [DllImport("ClientSdk.dll")]//客户端注册
        internal static extern int ClientRegister(string p_pszDispatchIp, ushort p_siDispatchPort, Byte[] p_pszResult, int p_iSize);
        [DllImport("P2PClientSdk")]
        internal static extern int P2PRegister(string p_pszServ, ushort p_uiPort, string p_pszMyid);
        public delegate void pRecvDataCallback(string p_pszData, int p_iSize);
        public event pRecvDataCallback DataCallback;
        [DllImport("ClientSdk.dll")]//接口回调函数
        internal static extern void setDataCallback(pRecvDataCallback pRecvDataCallback);
        //全局变量
        Byte[] ClientRegisterData = new byte[512];//注册接口返回数据
        bool windowFLag;//是否有打开窗口

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
            public string cmd { get; set; }
        }
        public logo()
        {
            InitializeComponent();
            logoIcon.Tag = this;
            GlobalData.BindMove(logoIcon);//给form1绑定窗口拖动
            GlobalData.Form2.SetMainFormTopMost += new Form2.SetMainFormTopMostHandle(Form2_SetMainFormTopMost);
            GlobalData.Form1.SetMainFormTopMost += new Form1.SetMainFormTopMostHandle(Form2_SetMainFormTopMost);
            DataCallback += new pRecvDataCallback(GetData);
            setDataCallback(DataCallback);
            IsRegister();
        }
        /// <summary>
        /// 接口返回数据的回调函数
        /// </summary>
        /// <param name="p_pszData">返回的数据</param>
        /// <param name="p_iSize">数据的大小</param>
        private void GetData(string p_pszData, int p_iSize)
        {
            ResultData JsonStr = JsonConvert.DeserializeObject<ResultData>(p_pszData);
            switch (JsonStr.cmd)
            {
                case "ClientRegister"://注册信息
                    ClientRegisterResult(p_pszData);
                    break;

            }
        }
        /// <summary>
        /// 处理注册结果
        /// </summary>
        /// <param name="JsonStr">处理结果</param>
        private void ClientRegisterResult(string p_pszData)
        {
            ResultData JsonStr = JsonConvert.DeserializeObject<ResultData>(p_pszData);
            if (JsonStr.ErrCode == "0")
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "RegisterConfig.txt", p_pszData);
            }
            else
            {
                MessageBox.Show("注册失败");
            }
        }
        private void IsRegister()//判断是否注册  没有注册调用注册接口
        {
            if (!VerifyRegister()) ClientRegister(GlobalData.DispatchIp, GlobalData.DispatchPort, ClientRegisterData, 512);
        }
        
       
        private bool VerifyRegister()//检测是否有配置文件判断是否注册
        {
            try
            {
                string config = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "RegisterConfig.txt");
                ResultData JsonStr = JsonConvert.DeserializeObject<ResultData>(config);
                GlobalData.clientid = JsonStr.clientid;
                //   GlobalData.Pwd = JsonStr.pwd;
                return true;
            }
            catch
            {
                return false;
            }
        }
       

        private void Form2_SetMainFormTopMost(bool topmost) 
        {
            windowFLag = false;
            logoIcon.BackgroundImage = linjun.Properties.Resources.meet_logo_translucent;
        }

        private void dSkinPictureBox1_Click(object sender, EventArgs e)//点击图标打开界面
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
     
    }
}
