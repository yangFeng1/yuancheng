
using DSkin.Forms;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace linjun
{
    public partial class Form2 : DSkinForm
    {
        //委托
        
        public delegate void SetMainFormTopMostHandle(bool topmost);//注册一个委托用来控制logo的变化
        public event SetMainFormTopMostHandle SetMainFormTopMost;

        private delegate void MeetingUIHandler(Control Con,string ImgUrl,bool flag);//开启会议中控制投屏等状态的变化
        private event MeetingUIHandler MeetingUI;

        //会议结束回调函数
        //public delegate void lpGetSvrInfoHandle(int code);
        //public event lpGetSvrInfoHandle lpGetSvrInfo;
        public delegate void lpGetClientInfo(int p_iRet);
        public event lpGetClientInfo lpGetClientInfoD;
        
        [DllImport("pss_client_sdk.dll")]//客户端开启投屏
        internal static extern bool StartPushVideo(string ScreenIp);
        [DllImport("pss_client_sdk.dll")]//结束投屏
        internal static extern  void StopPushVideo();
        [DllImport("pss_client_sdk.dll")]//退出会议
        internal static extern int ClientExitMeet(string p_pszMeetId, string p_pszClientId);
        //全局变量

        Rectangle rect;//屏幕分辨率
        int lservice = 0;//udp服务id
        int SSeen = 1;
        bool screenFlag = false;//判断当前是否在投屏中
        public Form2()
        {
            InitializeComponent();
            // setClientCallBack(lpGetClientInfoD);
            dSkinPictureBox1.BackgroundImage = linjun.Properties.Resources.meet_client_mute_default;
            dSkinPictureBox2.BackgroundImage = linjun.Properties.Resources.meet_client_video_default;
            dSkinPictureBox3.BackgroundImage = linjun.Properties.Resources.meet_client_desk_default;
            this.ShowInTaskbar = false;
        }
        bool ExitFLag = true;

         
        private void enterClose_Paint(object sender, EventArgs e)//退出会议

        {
            ExitFLag = false;
            int res = ClientExitMeet(GlobalData.MeetID, GlobalData.clientid);
            if (res == -2)
            {
                MessageBox.Show("参数错误");
            }
            //else if ((res == 0) || (res == -1))
            //{
            //    MessageBox.Show("调度服务器连接失败");
            //}
            GlobalData.connectStatus = false;
        }
        /// <summary>
        /// 客户端退出会议处理
        /// </summary>
        /// <param name="JsonStr">结果</param>
        private delegate void ClientExitMeetUI();
        public void ClientExitMeetResult(string p_pszData)
        {
            //"{\n\t\"Cmd\":\t\"ScreenCancelMeet\",\n\t\"Data\":\t{\n\t\t\"Result\":\t\"true\",\n\t\t\"MeetId\":\t\"10202\"\n\t}\n}"
            // "{\n\t\"Cmd\":\t\"ClientExitMeet\",\n\t\"Data\":\t{\n\t\t\"Result\":\t\"true\",\n\t\t\"ErrorCode\":\t0,\n\t\t\"MeetId\":\t\"10202\"\n\t}\n}"
            ResultData JsonStr = JsonConvert.DeserializeObject<ResultData>(p_pszData);
            if (JsonStr.Data.result != "true")
            {
                MessageBox.Show(JsonStr.ErrMsg);
            }
            else
            {
        
                if (!PushVideoFlag)//结束会议室如 正在投屏  结束投屏
                {
                    Thread thread = new Thread(new ThreadStart(PushVideo));//创建线程
                    thread.Start();
                }
                screenFlag = false;
                screen.BackgroundImage = linjun.Properties.Resources.meet_client_screen_default;
                ExitFLag = true;
                SetMainFormTopMost(true);//调用委托改变logo的图片
                ClientExitMeetUI Display = () =>
                {
                    closeTips.Hide();
                    GlobalData.Form2.Hide();
                    //this.BackgroundImage = null;
                };
                Invoke(Display);
                GlobalData.connectStatus = false;
                
            }
        }
      
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
        /// <param name="flag">开启或者关闭</param>
        private void MeetingUIEvent(Control Con, string ImgUrl,bool flag)
        {
            Con.BackgroundImage = (Image)linjun.Properties.Resources.ResourceManager.GetObject(ImgUrl);
            if (flag)//true为开启功能
            {
                SetMainFormTopMost(true);//调用委托改变logo的图片
                this.Hide();
            }
        }
        private void closeBtn_Click(object sender, EventArgs e)//退出会议提示信息
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
        bool PushVideoFlag = true;//当前是否在投屏
        private void PushVideo()//开启或结束投屏
        {
            if (PushVideoFlag)
            {
                
                    if (StartPushVideo(GlobalData.ScreenIp))//投屏成功返回true
                    {
                        PushVideoFlag = false;
                        Invoke(MeetingUI, screen, "meet_client_screen_selected", true);
                    }
                    else
                    {
                        screenFlag = false;
                        MessageBox.Show("投屏失败");
                    }
               
            }
            else
            {
                StopPushVideo();
                PushVideoFlag = true;
                Invoke(MeetingUI, screen, "meet_client_screen_default", false);
            }
        }
        /// <summary>
        /// 供其他类调用 改变投屏按钮图片
        /// </summary>
        public void InvokeMeetingUI(bool flag)
        {
            if (flag)
            {
                PushVideoFlag = true;
                Invoke(MeetingUI, screen, "meet_client_screen_default", true);
            }
            else
            {
                PushVideoFlag = true;
                Invoke(MeetingUI, screen, "meet_client_screen_default", false);
            }
           
        }
       /// <summary>
       /// 点击开始结束投屏
       /// </summary>
        private void ProjectionScreen()
        {
            if (screenFlag)//结束投屏
            {
                screenFlag = false;
               
                Thread thread = new Thread(new ThreadStart(PushVideo));//创建线程
                thread.Start();
              //  StopPushVideo();
          
            }
            else//开始投屏
            {
                screenFlag = true;
              //  StartPushVideo();
                Thread thread = new Thread(new ThreadStart(PushVideo));//创建线程
                thread.Start();
                
            }
        }
        private void screen_Click(object sender, EventArgs e)
        {
            ProjectionScreen();
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
        private void dSkinButton2_Click(object sender, EventArgs e)
        {

        }

        private void enterClos_Paint(object sender, PaintEventArgs e)
        {

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
