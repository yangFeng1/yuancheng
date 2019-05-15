using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace linjun
{
    class GlobalData
    {



        //  Form1 = new Form1();
        //   Form2 = new Form2()
        public static bool connectStatus;//判断当前是否连接
        public static Form1 Form1 = new Form1();//
        public static Form2 Form2 = new Form2();//
        public static string clientid = "";
        //public static string P2PIP = "47.92.205.121";//p2p服务器ip
        public static string P2PIP = "172.16.1.45";//p2p服务器ip
        public static ushort P2PPort = 8002;//p2p服务器端口 
        public static string DispatchIp = "172.16.1.41";//调度服务器ip
        public static ushort DispatchPort = 10002;//调度服务器端口
        public static string MeetID = "";//参加会议的id
       



        public static void BindMove(Control panel)
        {
            panel.MouseMove += new System.Windows.Forms.MouseEventHandler(logoIcon_MouseMove);
            panel.MouseUp += new System.Windows.Forms.MouseEventHandler(logoIcon_MouseUp);
            panel.MouseDown += new System.Windows.Forms.MouseEventHandler(logoIcon_MouseDown);
        }
      

        static bool beginMove = false;//初始化鼠标位置
        static int currentXPosition;
        static int currentYPosition;
        private static void logoIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = Control.MousePosition.X;//鼠标的x坐标为当前窗体左上角x坐标
                currentYPosition = Control.MousePosition.Y;//鼠标的y坐标为当前窗体左上角y坐标
            }
        }

        private static void logoIcon_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                Button btn = sender as Button;
                Panel panel = sender as Panel;
                DSkin.Controls.DSkinPictureBox DSkinPictureBox = sender as DSkin.Controls.DSkinPictureBox;
                Control control = new Button();
                if (btn != null)
                {
                    control =(Control)((Button)sender).Tag;
                }
                else if(panel != null)
                { 
                    control =(Control)((Panel)sender).Tag;
                } else if(DSkinPictureBox != null)
                {
                    control =(Control)((DSkin.Controls.DSkinPictureBox)sender).Tag;
                }
                if(control != null)
                {
                    control.Left += Control.MousePosition.X - currentXPosition;//根据鼠标x坐标确定窗体的左边坐标x
                    control.Top += Control.MousePosition.Y - currentYPosition;//根据鼠标的y坐标窗体的顶部，即Y坐标
                  
                    currentXPosition = Control.MousePosition.X;
                    currentYPosition = Control.MousePosition.Y;
                }
                 
                
            }
        }

        private static void logoIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //设置初始状态
                currentYPosition = 0;
                beginMove = false;
            }
        }
    }
}
