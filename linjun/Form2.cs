using DSkin.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace linjun
{
    public partial class Form2 : DSkinForm
    {
        //委托
        
        public delegate void SetMainFormTopMostHandle(bool topmost);//注册一个委托用来控制logo的变化
        public event SetMainFormTopMostHandle SetMainFormTopMost;
        public delegate void NetCallbackHandle(int nCmd, string buffer, int nlen, IntPtr user);
        private event NetCallbackHandle Netcallback;
        public delegate void MultiCallbackHandle(long lChannel, int nCmd, string buffer, int nlen, int nMark, IntPtr user);
        private event MultiCallbackHandle MultiCallback;[DllImport("w2net.dll")]
        internal static extern int CreateUDPService(MultiCallbackHandle MultiCallback, NetCallbackHandle UDPCallback, IntPtr user);//1 

        private delegate void MeetingUIHandler(Control Con,string ImgUrl);//开启会议中控制投屏等状态的变化
        private event MeetingUIHandler MeetingUI;

        //会议结束回调函数
        //public delegate void lpGetSvrInfoHandle(int code);
        //public event lpGetSvrInfoHandle lpGetSvrInfo;
        public delegate void lpGetClientInfo(int p_iRet);
        public event lpGetClientInfo lpGetClientInfoD;
        //SDK接口
        [DllImport("w2net.dll")]internal static extern void DestroyUDPService(int lservice);
        [DllImport("w2net.dll")]internal static extern int StartSession(int lservice, string url, int nPort);
        //2 [DllImport("w2net.dll")]internal static extern int StartMulticast(int lservice, string url, int nPort);
        [DllImport("w2net.dll")] internal static extern int SendSession(int lservice, int nCmd, string buffer, int nlen);
        [DllImport("w2net.dll")] internal static extern int SendMulticast(int lservice, byte[] buffer, int nlen);
        [DllImport("w2net.dll")] internal static extern int SendServer(int lservice, uint lChannel, ref string buffer, int nlen);
        [DllImport("w2net.dll")] internal static extern int StartSessionCapture(int lservice, int codec_type, int width, int height, int bitrate, int framerate);
        [DllImport("w2net.dll")] internal static extern void StopSessionCapture(int lservice); 
        [DllImport("ClientSdk.dll")]
        internal static extern int ClientExitMeet(string p_pszDispatchIp, ushort p_siDispatchPort, string p_pszp2pIp, ushort p_uip2pPort, string p_pszClientId, string p_pszMeetId, byte[] p_pszResult, int p_iSize);
        [DllImport("ClientSdk.dll")]
        internal static extern int ScreenCreateMeet(string p_pszDispatchIp, ushort p_siDispatchPort, string p_pszp2pIp, ushort p_uip2pPort, string p_pszMeetId, string p_pszPasswd, Byte[] p_pszResult, int p_iSize);
        [DllImport("ClientSdk.dll")]
         internal static extern  void setClientCallBack(lpGetClientInfo p_funcRecvSvrInfo);
        //全局变量
      
        Rectangle rect;//屏幕分辨率
        int lservice = 0;//udp服务id
        int SSeen = 1;
        bool screenFlag = false;//判断当前是否在投屏中
        public Form2()
        {
            InitializeComponent();
            lpGetClientInfoD += new lpGetClientInfo(lpGetSvrInfoCallback);
          setClientCallBack(lpGetClientInfoD);
            
        }
        bool ExitFLag = true;


        private void enterClose_Paint(object sender, EventArgs e)//退出会议

        {
            Byte[] result = new byte[512];
            ExitFLag = false;
                ClientExitMeet(GlobalData.DispatchIp, GlobalData.DispatchPort, GlobalData.P2PIP, GlobalData.P2PPort, GlobalData.clientid, GlobalData.MeetID, result, 1024);
           // ClientExitMeet(GlobalData.DispatchIp, GlobalData.DispatchPort, GlobalData.P2PIP, GlobalData.P2PPort, "C2019050916384231701073", "10223", result, 1024);
            string KeyStr1 = Encoding.Default.GetString(result).TrimEnd('\0');
            ResultData JsonStr = JsonConvert.DeserializeObject<ResultData>(KeyStr1);
            if (JsonStr.ErrCode != "0")
            {
                MessageBox.Show(JsonStr.ErrMsg);
            }
            else
            {
               // SendSession(lservice, 0x10004, "", 0);
                StopSessionCapture(lservice);
                DestroyUDPService(lservice);
                screenFlag = false;
                screen.BackgroundImage = linjun.Properties.Resources.meet_client_screen_default;
                ExitFLag = true;
                SetMainFormTopMost(true);//调用委托改变logo的图片
                GlobalData.connectStatus = false;
                closeTips.Hide();
                this.Hide();
            }
        }
        private void lpGetSvrInfoCallback(int code)//会议室断开回调函数
        {
            //MessageBox.Show(code.ToString());
            if ((code == 2) && ExitFLag)//退出会议
            {

                try
                {
                    StopSessionCapture( lservice);
                    DestroyUDPService( lservice);
                    screenFlag = false;
                    screen.BackgroundImage = linjun.Properties.Resources.meet_client_screen_default;
                    ccc += new ddd(a);
                    Invoke(ccc);
                }
                catch
                {
                  //  MessageBox.Show("1");
                }
            }
        }
        public delegate void ddd();
        public event ddd ccc;
        private  void a()
        {
            try
            {
                SetMainFormTopMost(true);//调用委托改变logo的图片
                GlobalData.connectStatus = false;
                closeTips.Hide();
                this.Hide();
            }
            catch
            {

            }
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            rect = new Rectangle();//获取桌面分辨率确定窗口位置
            rect = Screen.GetWorkingArea(this);
            int LeftScreen = rect.Width-458;
            this.Location = new Point(LeftScreen, 200);
            screen.BackgroundImage = linjun.Properties.Resources.meet_client_screen_default;
            MeetingUI += new MeetingUIHandler(MeetingUIEvent);
        }

        /// <summary>
        /// //开启会议中控制投屏等状态的变化
        /// </summary>
        /// <param name="Con">需要改变ui的控件</param>
        /// <param name="ImgUrl">更换的图片地址</param>
        private void MeetingUIEvent(Control Con, string ImgUrl)
        {
            Con.BackgroundImage = (Image)linjun.Properties.Resources.ResourceManager.GetObject(ImgUrl);
        }
        private void closeBtn_Click(object sender, EventArgs e)//退出会议
        {
            closeTips.Show();
        }
        
        private void dSkinLabel3_Click(object sender, EventArgs e)
        {
            SetMainFormTopMost(true);
            GlobalData.connectStatus = false;
            closeTips.Hide();
            this.Hide();
        }
       /// <summary>
       /// 点击开始结束投屏
       /// </summary>
       private void ProjectionScreen()
        {
            if (screenFlag)
            {
                screenFlag = false;
                SendSession(lservice, 0x10004, "", 0);
                StopSessionCapture(lservice);
                DestroyUDPService(lservice);
                Invoke(MeetingUI, screen, "meet_client_screen_default");
                //screen.BackgroundImage = linjun.Properties.Resources.meet_client_screen_default;
            }
            else
            {
                screenFlag = true;
                Invoke(MeetingUI, screen, "meet_client_screen_selected");
                //screen.BackgroundImage = linjun.Properties.Resources.meet_client_screen_selected;
                Netcallback += new NetCallbackHandle(NetCallbackHand);
                MultiCallback += new MultiCallbackHandle(MultiEventCallback);
                IntPtr IL = new IntPtr();
                lservice = CreateUDPService(MultiCallback, Netcallback, IL);
                // StartMulticast(lservice, "235.6.7.8", 15678);
                //Thread.Sleep(500);
                Byte[] a = new byte[512];
                //    SendMulticast(lservice,a,512);
                //string address = "192.168.12.70";
                string address = "172.16.1.51";
                int port = 18765;
                SSeen = StartSession(lservice, address, port);
                SendSession(lservice, 0x10003, "", 0);
                //StartSessionCapture(lservice, 1, 1920, 1080, 1024, 8);
                StartSessionCapture(lservice, 1, 1920, 1080, 1024, 8);
            }
        }
        private void screen_Click(object sender, EventArgs e)
        {
            ProjectionScreen();
        }
       
    
        public class ResultData
        {
            public string ip { get; set; }
            public string ErrCode { get; set; }
            public string pwd { get; set; }
            public string result { get; set; }
            public string ErrMsg { get; set; }
            public string meetid { get; set; }
            public string verifycode { get; set; }
        }
        private void dSkinButton2_Click(object sender, EventArgs e)
        {

        }

        private void enterClos_Paint(object sender, PaintEventArgs e)
        {

        }
        private void NetCallbackHand(int nCmd, string buffer, int nlen, IntPtr user) {//服务器回调
            MessageBox.Show("2");
        }
        private void MultiEventCallback(long lChannel, int nCmd, string buffer, int nlen, int nMark, IntPtr user) {//主播回调
            MessageBox.Show("2");
        }





        //UI操作
        private void dSkinPictureBox5_Click(object sender, EventArgs e)
        {
            closeTips.Hide();
        }

        private void dSkinLabel4_Click(object sender, EventArgs e)
        {
            closeTips.Hide();
        }
        private void close_Paint(object sender, EventArgs e)
        {
            closeTips.Hide();
        }
        private void enterClose_MouseDown(object sender, MouseEventArgs e)//按下
        {
            enterClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(55)))), ((int)(((byte)(242)))));
            enterClose.ButtonBorderColor = enterClose.BaseColor;
        }
        private void enterClose_MouseEnter(object sender, EventArgs e)//houver
        {
            enterClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(108)))), ((int)(((byte)(252)))));
            enterClose.ButtonBorderColor = enterClose.BaseColor;
        }

        private void enterClose_MouseLeave(object sender, EventArgs e)//离开
        {
            enterClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(79)))), ((int)(((byte)(254)))));
            enterClose.ButtonBorderColor = enterClose.BaseColor;
        }

        private void close_MouseDown(object sender, MouseEventArgs e)
        {
            close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            close.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            close.ButtonBorderColor = close.BaseColor;
        }

        private void close_MouseEnter(object sender, EventArgs e)
        {
            close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            close.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            close.ButtonBorderColor = close.BaseColor;
        }

        private void close_MouseLeave(object sender, EventArgs e)
        {
            close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            close.BaseColor = System.Drawing.Color.Transparent;
            close.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
        }
    }
}
