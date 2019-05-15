using DSkin.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace linjun
{
    public partial class Form1 : DSkinForm
    {
        //委托
        public delegate void SetMainFormTopMostHandle(bool topmost);// 改变logo的图片
        public event SetMainFormTopMostHandle SetMainFormTopMost;

        //连接会议成功跳转form2
        public delegate void UIChange();// 改变UI的委托
        public event UIChange ConnectDegHandle;//连接会议

        //SDK接口
        [DllImport("ClientSdk.dll")]
        // private static extern IntPtr GetScreenInfo(string p_pszDispatchIp, short p_siDispatchPort, long p_llmeetid, ref IntPtr p_szResult, int p_iSize);
        private static extern int GetScreenInfo(string p_pszDispatchIp, short p_siDispatchPort, long p_llmeetid, byte[] p_szResult, int p_iSize);
        [DllImport("ClientSdk.dll")]
        internal static extern  int ClientAttendMeet(string p_pszDispatchIp, ushort p_siDispatchPort, string p_pszClientId, string p_pszp2pIp, ushort p_uip2pPort, string p_pszMeetId, string p_pszVerifyCode, byte[] p_pszResult, int p_iSize);
        public delegate void pRecvDataCallback(string p_pszData, int p_iSize);
        public event pRecvDataCallback DataCallback;
        [DllImport("ClientSdk.dll")]//接口回调函数
        internal static extern void setDataCallback(pRecvDataCallback pRecvDataCallback);

        //全局变量
        Byte[] result = new byte[512];//测试数据
        public Form1()
        {
            InitializeComponent();  
            MeetIDText.Tag = dSkinPanel4;
            ConnectDegHandle += new UIChange(ConnectDeg);
            //回调函数处理
            DataCallback += new pRecvDataCallback(GetData);
            setDataCallback(DataCallback);
            // dSkinPanel1.Click += GlobalData.SupportedProtocolEvent;
        }
        private void GetData(string p_pszData, int p_iSize)
        {
            ResultData JsonStr = JsonConvert.DeserializeObject<ResultData>(p_pszData);
            try
            {
                switch (JsonStr.cmd)
                {
                    case "ClientAttendMeet":
                        ConnectMeet(JsonStr);
                        break;
                }
            }
            catch
            {

            }
        }

        private void ConnectDeg()//会议连接成功跳转form2
        {
            GlobalData.MeetID = MeetIDText.Text;
            GlobalData.Form2.Show();
            this.Hide();
            GlobalData.connectStatus = true;
        }


        private void Form1_Shown(object sender, EventArgs e)//窗体第一次出现时
        {
            dSkinPanel1.Tag = GlobalData.Form1;  
            GlobalData.BindMove(dSkinPanel1);//给form1绑定窗口拖动
            dSkinPanel7.Location = new Point(-10,18);
        }
        private void dSkinPanel6_Paint(object sender, EventArgs e)//连接会议按钮
        {
            ClientAttendMeet(GlobalData.DispatchIp, GlobalData.DispatchPort, GlobalData.clientid, GlobalData.P2PIP, GlobalData.P2PPort, MeetIDText.Text, veriftCodeText.Text, result, 1024);
           
        }
        private void ConnectMeet(ResultData JsonStr)//连接会议
        {
            if (JsonStr.ErrCode != "0")
            {
                MessageBox.Show(JsonStr.ErrMsg);
            }
            else
            {
                Invoke(ConnectDegHandle);
                //GlobalData.MeetID = MeetIDText.Text;
                //GlobalData.Form2.Show();
                //this.Hide();
                //GlobalData.connectStatus = true;
            }
            

            //string IP = "172.16.1.5";
            //short Port = 10002;
            //int MeetingID = 25;
            //ResultData JsonStr = null;
            //指示窗体的图标。这在窗体的系统菜单框中显示，以及当窗体最小化时显示。[] szReaderVersion = new Byte[512];
            //GetScreenInfo(IP, Port, MeetingID, szReaderVersion, 1024);
            //string KeyStr1 = Encoding.Default.GetString(szReaderVersion);
            //string result = KeyStr1.TrimEnd('\0');//截取返回值后面的/0
            //JsonStr = JsonConvert.DeserializeObject<ResultData>(result);
            //IP = JsonStr.ip;
            //int Code = int.Parse(JsonStr.ErrCode);
            //if (Code == 0)
            //{

            //}
            //else
            //{
            //    MessageBox.Show("账号或密码不对");
            //}
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
            public string cmd { get; set; }
        }



        private void dSkinLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dSkinPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dSkinPanel8_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool TopFlag = false;//判断上面的输入框是否获得焦点
        private bool BFlag = false;//判断下面的输入框是否获得焦点
        private void dSkinTextBox1_Enter(object sender, EventArgs e)//获取焦点(上)
        {
            TopFlag = true;
            dSkinPanel4.DuiBackgroundRender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(123)))), ((int)(((byte)(246)))));
        }
        
        private void dSkinTextBox1_MouseEnter(object sender, EventArgs e)//hover
        {
            if (!TopFlag)
            {
                dSkinPanel4.DuiBackgroundRender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            }
        }

        private void dSkinPanel4_MouseLeave(object sender, EventArgs e)//失去hover
        {
            if (!TopFlag) { 
                dSkinPanel4.DuiBackgroundRender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
        }
        }

        private void dSkinTextBox1_Leave(object sender, EventArgs e)//失去焦点
        {
            TopFlag = false;
            dSkinPanel4.DuiBackgroundRender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
        }
        
                    

        //下面
        private void dSkinTextBox2_Enter(object sender, EventArgs e)//获取焦点
        {
            BFlag = true;
            dSkinPanel5.DuiBackgroundRender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(123)))), ((int)(((byte)(246)))));
        }
        

        private void dSkinTextBox2_Leave(object sender, EventArgs e)//失去焦点
        {
            BFlag = false;
            dSkinPanel5.DuiBackgroundRender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
        }

        private void dSkinPanel5_MouseEnter(object sender, EventArgs e)//hover
        {
            if (!BFlag)
            {
                dSkinPanel5.DuiBackgroundRender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            }
        }

        private void dSkinPanel5_MouseLeave(object sender, EventArgs e)//离开hover
        {

            if (!BFlag)
            {
                dSkinPanel5.DuiBackgroundRender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
            }
        }
      
        private void dSkinPictureBox2_Click(object sender, EventArgs e)
        {
            SetMainFormTopMost(true);//调用委托改变logo的图片
            GlobalData.connectStatus = false;
            this.Hide();
        }
    }
}
