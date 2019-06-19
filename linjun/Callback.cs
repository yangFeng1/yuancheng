using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace linjun
{
    class Callback
    {
        public delegate void UIChange();//连接会议成功隐藏form1 显示form2
        public static event UIChange ConnectDegHandle;
        public delegate void UIChange_ConnectText();//改变连接按钮文字
        public static event UIChange_ConnectText ConnectText;
        public static bool coonectState = false;//连接状态
        public static bool firstCoonect = true;//第一次连接成功时

        public static void GetData(string p_pszData, int p_iSize,IntPtr user)
        {
            ResultData JsonStr;
            try
            {

                JsonStr = JsonConvert.DeserializeObject<ResultData>(p_pszData);
            }
            catch
            {
                return;
            }
            switch (JsonStr.Cmd)
            {
                case "ClientRegister"://注册信息
                    ClientRegisterResult(p_pszData);
                    break;
                case "ConnectionState"://连接状态
                                       //  ConnectionState(JsonStr);
                    break;
                case "ClientAttendMeet"://连接会议室
                    ClientAttendMeet(p_pszData);
                    break;
                case "ClientExitMeet"://退出会议
                    GlobalData.Form2.ClientExitMeetResult(p_pszData);
                    break;
                case "ScreenCancelMeet"://屏幕端主动取消会议
                    GlobalData.Form2.ClientExitMeetResult(p_pszData);
                    break;
                case "PushVideo"://投屏返回
                                 // "{\n\t\"Cmd\":\t\"PushVideo\",\n\t\"Data\":\t{\n\t\t\"Cmd\":\t65552,\n\t\t\"Channel\":\t5105188,\n\t\t\"buffer\":\t\"\",\n\t\t\"len\":\t0\n\t}\n}"
                    PushVideo_Result(p_pszData);
                    break;
            }
        }
        /// <summary>
        /// 投屏返回
        /// </summary>
        /// <param name="data">连接状态返回</param>
        private static void PushVideo_Result(string p_pszData)
        {
            ResultData JsonStr = JsonConvert.DeserializeObject<ResultData>(p_pszData);
            
            switch (int.Parse(JsonStr.Data.Cmd))
            {
                case 0x10010:
                   GlobalData.Form2.InvokeMeetingUI(false);
                    MessageBox.Show("推流失败");
                    break;
                case 0x10011:
                    GlobalData.Form2.InvokeMeetingUI(false);
                    MessageBox.Show("已有投屏端在投屏");
                    break;
                default:
                    GlobalData.Form2.InvokeMeetingUI(false);
                    MessageBox.Show("投屏失败");
                    break;
            }
        }
        /// <summary>
        /// 连接状态处理
        /// </summary>
        /// <param name="">连接状态返回</param>
        private static void ConnectionState(ResultData data)
        {
            //if (firstCoonect && !(data.data == "Successful connection"))//第一次连接成功
            //{
            //    firstCoonect = false;
            //    GlobalData.logo.IsRegister();
            //}
        }
 
        /// <summary>
        /// 会议连接成功跳转form2
        /// </summary>
        private static void ConnectDeg()
        {
            GlobalData.MeetID = GlobalData.Form1.MeetIDText.Text;
            GlobalData.Form2.Show();
            GlobalData.Form1.Hide();
            GlobalData.connectStatus = true;
        }
        /// <summary>
        /// 处理连接会议室结果
        /// </summary>
        /// <param name="JsonStr">处理结果</param>
        private static void ClientAttendMeet(string p_pszData)
        {
            //"{\n\t\"Cmd\":\t\"ClientAttendMeet\",\n\t\"Data\":\t{\n\t\t\"Result\":\t\"true\",\n\t\t\"ErrorCode\":\t0,\n\t\t\"MeetId\":\t\"10202\",\n\t\t\"ScreenIp\":\t\"192.168.253.1|172.16.1.44|192.168.211.1|192.168.28.1|\"\n\t}\n}"
            ResultData JsonStr = JsonConvert.DeserializeObject<ResultData>(p_pszData);

            if (JsonStr.Data.result == "true")
            {
                ConnectDegHandle += new UIChange(ConnectDeg);
                GlobalData.Form1.Invoke(ConnectDegHandle);
                GlobalData.ScreenIp = JsonStr.Data.ScreenIp;
            }
            else
            {
                MessageBox.Show(JsonStr.ErrMsg);
            }
        }
        /// <summary>
        /// 改变连接按钮文字
        /// </summary>
        private static void UIFun_ConnectText()
        {
            GlobalData.Form1.Connect.Text = "连接";
        }
        /// <summary>
        /// 处理注册结果
        /// </summary>
        /// <param name="JsonStr">处理结果</param>
        private static void ClientRegisterResult(string p_pszData)
        {
            //MessageBox.Show(p_pszData);
            //"{\n\t\"Cmd\":\t\"ClientRegister\",\n\t\"Data\":\t{\n\t\t\"Result\":\t\"true\",\n\t\t\"ClientId\":\t\"C2019053016154970002324\"\n\t}\n}"
            ResultData JsonStr = JsonConvert.DeserializeObject<ResultData>(p_pszData);
            if (JsonStr.Data.result == "true")
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "RegisterConfig.txt", p_pszData);
            }
            else
            {
                MessageBox.Show("注册失败");
                System.Environment.Exit(0);
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
            public string PushVideo { get; set; }
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
            public string Channel { get; set; }
            public string Cmd { get; set; }

            public string city { get; set; }
            
            public string province { get; set; }
            public string ScreenIp { get; set; }
        }
    }
}
