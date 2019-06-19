
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
using System.Drawing.Text;
using System.Linq;
using DSkin.Forms;

namespace linjun
{
    public partial class Form1 : DSkinForm
    {
        //委托
        public delegate void SetMainFormTopMostHandle(bool topmost);// 改变logo的图片
        public event SetMainFormTopMostHandle SetMainFormTopMost;
        //SDK接口
        [DllImport("pss_client_sdk.dll")]//参加会议
        internal static extern int ClientAttendMeet(string p_pszClientId, string p_pszp2pIp, ushort p_uip2pPort, string p_pszMeetId, string p_pszVerifyCode);
        //全局变量
        public Form1()

        {
            InitializeComponent();
            MeetIDText.Tag = dSkinPanel4;
            inititalUI();
        }
        /// <summary>
        /// 会议连接成功跳转form2
        /// </summary>
        private void ConnectDeg()
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
        }
        private void dSkinPanel6_Paint(object sender, EventArgs e)//连接会议按钮
        {
            ConnectMeet_ConnectFun();
        }
       private void ConnectMeet_ConnectFun()
        {
            if (Connect.Text != "连接中")
            {
                Connect.Text = "连接中";
                Connect.BaseColor = Color.FromArgb(31,200,66);
                int res = ClientAttendMeet(GlobalData.clientid, GlobalData.P2PIP, GlobalData.P2PPort, MeetIDText.Text, veriftCodeText.Text);
                if (res == -2)
                {
                    Connect.Text = "连接";
                    Connect.BaseColor = Color.FromArgb(39, 79, 254);
                    MessageBox.Show("参数错误");
                }
                else
                {
                 //   GlobalData.logo.Connect_Statr(true);
                }
            }
        }
      
        /// <summary>
        /// 初始化UI
        /// </summary>
        private void inititalUI()
        {
            //try
            //{
            //    MeetIDText.Font = GlobalData.ShowFont("SourceHanSansCN-Normal", MeetIDText.Font.Size);
            //}
            //catch
            //{
            //    MessageBox.Show("1");
            //}
            //InstalledFontCollection fc = new InstalledFontCollection();
            //Font a = fc.Families.Where(d => d.Name.Contains("")).FirstOrDefault();
            //  dSkinLabel3.Font = ShowFont("SourceHanSansCN-Normal", dSkinLabel3.Font.Size);
            this.Size = new Size(this.Width,210);
            MeetIDText.KeyUp += new KeyEventHandler(ConnectMeet_Key);
            veriftCodeText.KeyUp += new KeyEventHandler(ConnectMeet_Key);
            this.ShowInTaskbar = false;
            dSkinPanel7.Location = new Point(-10, 18);
        }
        /// <summary>
        /// 按下enter触发连接会议
        /// </summary>
        private void ConnectMeet_Key(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
            {
                ConnectMeet_ConnectFun();
            }
        }
        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Font ShowFont(string name, float size)
        {
            Font font = null;
            System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
            privateFonts.AddFontFile(Application.StartupPath + @"\Font\" + name + ".otf");
            font = new Font(privateFonts.Families[0], size);
            return font;
        }

        private void dSkinLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dSkinPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //委托函数
        private void dSkinPanel8_Paint(object sender, PaintEventArgs e)
        {

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
        private bool TopFlag = false;//判断上面的输入框是否获得焦点
        private bool BFlag = false;//判断下面的输入框是否获得焦点.
        //ui
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
