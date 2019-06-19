namespace linjun
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dSkinPanel1 = new DSkin.Controls.DSkinPanel();
            this.dSkinPictureBox2 = new DSkin.Controls.DSkinPictureBox();
            this.dSkinPictureBox1 = new DSkin.Controls.DSkinPictureBox();
            this.dSkinLabel1 = new DSkin.Controls.DSkinLabel();
            this.dSkinPanel2 = new DSkin.Controls.DSkinPanel();
            this.dSkinPanel5 = new DSkin.Controls.DSkinPanel();
            this.veriftCodeText = new DSkin.Controls.DSkinTextBox();
            this.dSkinLabel5 = new DSkin.Controls.DSkinLabel();
            this.dSkinPanel4 = new DSkin.Controls.DSkinPanel();
            this.MeetIDText = new DSkin.Controls.DSkinTextBox();
            this.dSkinLabel3 = new DSkin.Controls.DSkinLabel();
            this.dSkinPanel3 = new DSkin.Controls.DSkinPanel();
            this.dSkinLabel2 = new DSkin.Controls.DSkinLabel();
            this.LocalMeeting = new DSkin.Controls.DSkinPanel();
            this.dSkinPanel8 = new DSkin.Controls.DSkinPanel();
            this.dSkinLabel8 = new DSkin.Controls.DSkinLabel();
            this.dSkinLabel7 = new DSkin.Controls.DSkinLabel();
            this.dSkinPanel7 = new DSkin.Controls.DSkinPanel();
            this.dSkinLabel6 = new DSkin.Controls.DSkinLabel();
            this.Connect = new DSkin.Controls.DSkinButton();
            this.dSkinPanel1.SuspendLayout();
            this.dSkinPanel2.SuspendLayout();
            this.dSkinPanel5.SuspendLayout();
            this.dSkinPanel4.SuspendLayout();
            this.dSkinPanel3.SuspendLayout();
            this.LocalMeeting.SuspendLayout();
            this.dSkinPanel8.SuspendLayout();
            this.dSkinPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSkinPanel1
            // 
            this.dSkinPanel1.BackColor = System.Drawing.Color.White;
            this.dSkinPanel1.BackgroundImage = global::linjun.Properties.Resources.meet_client_bg;
            this.dSkinPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dSkinPanel1.Controls.Add(this.dSkinPictureBox2);
            this.dSkinPanel1.Controls.Add(this.dSkinPictureBox1);
            this.dSkinPanel1.Controls.Add(this.dSkinLabel1);
            this.dSkinPanel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinPanel1.Location = new System.Drawing.Point(0, 0);
            this.dSkinPanel1.Name = "dSkinPanel1";
            this.dSkinPanel1.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinPanel1.RightBottom")));
            this.dSkinPanel1.Size = new System.Drawing.Size(296, 163);
            this.dSkinPanel1.TabIndex = 0;
            this.dSkinPanel1.Text = "dSkinPanel1";
            this.dSkinPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.dSkinPanel1_Paint);
            // 
            // dSkinPictureBox2
            // 
            this.dSkinPictureBox2.Image = global::linjun.Properties.Resources.meet_client_close_default;
            this.dSkinPictureBox2.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(global::linjun.Properties.Resources.meet_client_close_default))};
            this.dSkinPictureBox2.Location = new System.Drawing.Point(264, 8);
            this.dSkinPictureBox2.Name = "dSkinPictureBox2";
            this.dSkinPictureBox2.Size = new System.Drawing.Size(24, 24);
            this.dSkinPictureBox2.TabIndex = 2;
            this.dSkinPictureBox2.Text = "dSkinPictureBox2";
            this.dSkinPictureBox2.Click += new System.EventHandler(this.dSkinPictureBox2_Click);
            // 
            // dSkinPictureBox1
            // 
            this.dSkinPictureBox1.Image = global::linjun.Properties.Resources.meet_client_logo;
            this.dSkinPictureBox1.Images = new System.Drawing.Image[] {
        ((System.Drawing.Image)(global::linjun.Properties.Resources.meet_client_logo))};
            this.dSkinPictureBox1.Location = new System.Drawing.Point(16, 21);
            this.dSkinPictureBox1.Name = "dSkinPictureBox1";
            this.dSkinPictureBox1.Size = new System.Drawing.Size(18, 21);
            this.dSkinPictureBox1.TabIndex = 1;
            this.dSkinPictureBox1.Text = "dSkinPictureBox1";
            // 
            // dSkinLabel1
            // 
            this.dSkinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel1.ForeColor = System.Drawing.Color.White;
            this.dSkinLabel1.Location = new System.Drawing.Point(41, 24);
            this.dSkinLabel1.Name = "dSkinLabel1";
            this.dSkinLabel1.Size = new System.Drawing.Size(54, 18);
            this.dSkinLabel1.TabIndex = 0;
            this.dSkinLabel1.Text = "零距畅通\r\n";
            this.dSkinLabel1.Click += new System.EventHandler(this.dSkinLabel1_Click);
            // 
            // dSkinPanel2
            // 
            this.dSkinPanel2.BackColor = System.Drawing.Color.White;
            this.dSkinPanel2.Controls.Add(this.Connect);
            this.dSkinPanel2.Controls.Add(this.dSkinPanel5);
            this.dSkinPanel2.Controls.Add(this.dSkinPanel4);
            this.dSkinPanel2.Controls.Add(this.dSkinPanel3);
            this.dSkinPanel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinPanel2.Location = new System.Drawing.Point(16, 60);
            this.dSkinPanel2.Name = "dSkinPanel2";
            this.dSkinPanel2.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinPanel2.RightBottom")));
            this.dSkinPanel2.Size = new System.Drawing.Size(264, 132);
            this.dSkinPanel2.TabIndex = 1;
            this.dSkinPanel2.Text = "dSkinPanel2";
            // 
            // dSkinPanel5
            // 
            this.dSkinPanel5.BackColor = System.Drawing.Color.Transparent;
            this.dSkinPanel5.Borders.AllColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
            this.dSkinPanel5.Borders.AllWidth = 0;
            this.dSkinPanel5.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
            this.dSkinPanel5.Borders.BottomWidth = 0;
            this.dSkinPanel5.Borders.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
            this.dSkinPanel5.Borders.LeftWidth = 0;
            this.dSkinPanel5.Borders.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
            this.dSkinPanel5.Borders.RightWidth = 0;
            this.dSkinPanel5.Borders.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
            this.dSkinPanel5.Borders.TopWidth = 0;
            this.dSkinPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dSkinPanel5.Controls.Add(this.veriftCodeText);
            this.dSkinPanel5.Controls.Add(this.dSkinLabel5);
            this.dSkinPanel5.DuiBackgroundRender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
            this.dSkinPanel5.DuiBackgroundRender.Radius = 2;
            this.dSkinPanel5.DuiBackgroundRender.RenderBorders = true;
            this.dSkinPanel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinPanel5.Location = new System.Drawing.Point(16, 86);
            this.dSkinPanel5.Name = "dSkinPanel5";
            this.dSkinPanel5.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinPanel5.RightBottom")));
            this.dSkinPanel5.Size = new System.Drawing.Size(160, 28);
            this.dSkinPanel5.TabIndex = 2;
            this.dSkinPanel5.Text = "dSkinPanel5";
            this.dSkinPanel5.MouseEnter += new System.EventHandler(this.dSkinPanel5_MouseEnter);
            this.dSkinPanel5.MouseLeave += new System.EventHandler(this.dSkinPanel5_MouseLeave);
            // 
            // veriftCodeText
            // 
            this.veriftCodeText.BitmapCache = false;
            this.veriftCodeText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.veriftCodeText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.veriftCodeText.Location = new System.Drawing.Point(55, 6);
            this.veriftCodeText.Name = "veriftCodeText";
            this.veriftCodeText.Size = new System.Drawing.Size(100, 16);
            this.veriftCodeText.TabIndex = 1;
            this.veriftCodeText.TransparencyKey = System.Drawing.Color.Empty;
            this.veriftCodeText.WaterFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.veriftCodeText.WaterText = "";
            this.veriftCodeText.WaterTextOffset = new System.Drawing.Point(0, 0);
            this.veriftCodeText.Enter += new System.EventHandler(this.dSkinTextBox2_Enter);
            this.veriftCodeText.Leave += new System.EventHandler(this.dSkinTextBox2_Leave);
            // 
            // dSkinLabel5
            // 
            this.dSkinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.dSkinLabel5.Location = new System.Drawing.Point(8, 8);
            this.dSkinLabel5.Name = "dSkinLabel5";
            this.dSkinLabel5.Size = new System.Drawing.Size(54, 18);
            this.dSkinLabel5.TabIndex = 0;
            this.dSkinLabel5.Text = "验证码：";
            // 
            // dSkinPanel4
            // 
            this.dSkinPanel4.BackColor = System.Drawing.Color.Transparent;
            this.dSkinPanel4.Borders.AllColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
            this.dSkinPanel4.Borders.AllWidth = 0;
            this.dSkinPanel4.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
            this.dSkinPanel4.Borders.BottomWidth = 0;
            this.dSkinPanel4.Borders.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
            this.dSkinPanel4.Borders.LeftWidth = 0;
            this.dSkinPanel4.Borders.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
            this.dSkinPanel4.Borders.RightWidth = 0;
            this.dSkinPanel4.Borders.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
            this.dSkinPanel4.Borders.TopWidth = 0;
            this.dSkinPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dSkinPanel4.Controls.Add(this.MeetIDText);
            this.dSkinPanel4.Controls.Add(this.dSkinLabel3);
            this.dSkinPanel4.DuiBackgroundRender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(242)))));
            this.dSkinPanel4.DuiBackgroundRender.Radius = 2;
            this.dSkinPanel4.DuiBackgroundRender.RenderBorders = true;
            this.dSkinPanel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinPanel4.Location = new System.Drawing.Point(16, 50);
            this.dSkinPanel4.Name = "dSkinPanel4";
            this.dSkinPanel4.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinPanel4.RightBottom")));
            this.dSkinPanel4.Size = new System.Drawing.Size(160, 28);
            this.dSkinPanel4.TabIndex = 1;
            this.dSkinPanel4.Text = "dSkinPanel4";
            this.dSkinPanel4.MouseLeave += new System.EventHandler(this.dSkinPanel4_MouseLeave);
            // 
            // MeetIDText
            // 
            this.MeetIDText.BitmapCache = false;
            this.MeetIDText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MeetIDText.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MeetIDText.Location = new System.Drawing.Point(55, 6);
            this.MeetIDText.Name = "MeetIDText";
            this.MeetIDText.Size = new System.Drawing.Size(100, 16);
            this.MeetIDText.TabIndex = 1;
            this.MeetIDText.Tag = "";
            this.MeetIDText.TransparencyKey = System.Drawing.Color.Empty;
            this.MeetIDText.WaterFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MeetIDText.WaterText = "";
            this.MeetIDText.WaterTextOffset = new System.Drawing.Point(0, 0);
            this.MeetIDText.Enter += new System.EventHandler(this.dSkinTextBox1_Enter);
            this.MeetIDText.Leave += new System.EventHandler(this.dSkinTextBox1_Leave);
            this.MeetIDText.MouseEnter += new System.EventHandler(this.dSkinTextBox1_MouseEnter);
            // 
            // dSkinLabel3
            // 
            this.dSkinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.dSkinLabel3.Location = new System.Drawing.Point(8, 8);
            this.dSkinLabel3.Name = "dSkinLabel3";
            this.dSkinLabel3.Size = new System.Drawing.Size(54, 18);
            this.dSkinLabel3.TabIndex = 0;
            this.dSkinLabel3.Text = "会议号：";
            // 
            // dSkinPanel3
            // 
            this.dSkinPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.dSkinPanel3.Controls.Add(this.dSkinLabel2);
            this.dSkinPanel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinPanel3.Location = new System.Drawing.Point(16, 16);
            this.dSkinPanel3.Name = "dSkinPanel3";
            this.dSkinPanel3.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinPanel3.RightBottom")));
            this.dSkinPanel3.Size = new System.Drawing.Size(232, 28);
            this.dSkinPanel3.TabIndex = 0;
            this.dSkinPanel3.Text = "dSkinPanel3";
            // 
            // dSkinLabel2
            // 
            this.dSkinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.dSkinLabel2.Location = new System.Drawing.Point(3, 7);
            this.dSkinLabel2.Name = "dSkinLabel2";
            this.dSkinLabel2.Size = new System.Drawing.Size(79, 18);
            this.dSkinLabel2.TabIndex = 0;
            this.dSkinLabel2.Text = "显示设备名称";
            // 
            // LocalMeeting
            // 
            this.LocalMeeting.BackColor = System.Drawing.Color.White;
            this.LocalMeeting.Controls.Add(this.dSkinPanel8);
            this.LocalMeeting.Controls.Add(this.dSkinPanel7);
            this.LocalMeeting.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LocalMeeting.Location = new System.Drawing.Point(16, 209);
            this.LocalMeeting.Name = "LocalMeeting";
            this.LocalMeeting.RightBottom = ((System.Drawing.Image)(resources.GetObject("LocalMeeting.RightBottom")));
            this.LocalMeeting.Size = new System.Drawing.Size(264, 155);
            this.LocalMeeting.TabIndex = 2;
            this.LocalMeeting.Text = "dSkinPanel7";
            // 
            // dSkinPanel8
            // 
            this.dSkinPanel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(235)))), ((int)(((byte)(254)))));
            this.dSkinPanel8.Controls.Add(this.dSkinLabel8);
            this.dSkinPanel8.Controls.Add(this.dSkinLabel7);
            this.dSkinPanel8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinPanel8.Location = new System.Drawing.Point(16, 62);
            this.dSkinPanel8.Name = "dSkinPanel8";
            this.dSkinPanel8.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinPanel8.RightBottom")));
            this.dSkinPanel8.Size = new System.Drawing.Size(232, 48);
            this.dSkinPanel8.TabIndex = 1;
            this.dSkinPanel8.Text = "dSkinPanel8";
            this.dSkinPanel8.Paint += new System.Windows.Forms.PaintEventHandler(this.dSkinPanel8_Paint);
            // 
            // dSkinLabel8
            // 
            this.dSkinLabel8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dSkinLabel8.Location = new System.Drawing.Point(8, 24);
            this.dSkinLabel8.Name = "dSkinLabel8";
            this.dSkinLabel8.Size = new System.Drawing.Size(142, 18);
            this.dSkinLabel8.TabIndex = 1;
            this.dSkinLabel8.Text = "1651561165156156156";
            // 
            // dSkinLabel7
            // 
            this.dSkinLabel7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.dSkinLabel7.Location = new System.Drawing.Point(8, 4);
            this.dSkinLabel7.Name = "dSkinLabel7";
            this.dSkinLabel7.Size = new System.Drawing.Size(55, 18);
            this.dSkinLabel7.TabIndex = 0;
            this.dSkinLabel7.Text = "1651561";
            // 
            // dSkinPanel7
            // 
            this.dSkinPanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(235)))), ((int)(((byte)(254)))));
            this.dSkinPanel7.Controls.Add(this.dSkinLabel6);
            this.dSkinPanel7.DuiBackgroundRender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(235)))), ((int)(((byte)(254)))));
            this.dSkinPanel7.DuiBackgroundRender.Radius = 25;
            this.dSkinPanel7.DuiBackgroundRender.RenderBorders = true;
            this.dSkinPanel7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinPanel7.Location = new System.Drawing.Point(-10, 18);
            this.dSkinPanel7.Name = "dSkinPanel7";
            this.dSkinPanel7.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinPanel7.RightBottom")));
            this.dSkinPanel7.Size = new System.Drawing.Size(98, 28);
            this.dSkinPanel7.TabIndex = 0;
            this.dSkinPanel7.Text = "dSkinPanel7";
            // 
            // dSkinLabel6
            // 
            this.dSkinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dSkinLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.dSkinLabel6.Location = new System.Drawing.Point(18, 7);
            this.dSkinLabel6.Name = "dSkinLabel6";
            this.dSkinLabel6.Size = new System.Drawing.Size(66, 18);
            this.dSkinLabel6.TabIndex = 0;
            this.dSkinLabel6.Text = "本地会议室";
            // 
            // Connect
            // 
            this.Connect.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(79)))), ((int)(((byte)(254)))));
            this.Connect.ButtonBorderWidth = 1;
            this.Connect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Connect.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.Connect.ForeColor = System.Drawing.Color.White;
            this.Connect.HoverColor = System.Drawing.Color.Empty;
            this.Connect.HoverImage = null;
            this.Connect.Location = new System.Drawing.Point(183, 51);
            this.Connect.Name = "Connect";
            this.Connect.NormalImage = null;
            this.Connect.PressColor = System.Drawing.Color.Empty;
            this.Connect.PressedImage = null;
            this.Connect.Radius = 10;
            this.Connect.ShowButtonBorder = true;
            this.Connect.Size = new System.Drawing.Size(64, 64);
            this.Connect.TabIndex = 3;
            this.Connect.Text = "连接";
            this.Connect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Connect.TextPadding = 0;
            this.Connect.Click += new System.EventHandler(this.dSkinPanel6_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.CaptionBackColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(133)))), ((int)(((byte)(219)))))};
            this.ClientSize = new System.Drawing.Size(296, 395);
            this.Controls.Add(this.LocalMeeting);
            this.Controls.Add(this.dSkinPanel2);
            this.Controls.Add(this.dSkinPanel1);
            this.DoubleClickMaximized = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(296, 395);
            this.Name = "Form1";
            this.Radius = 4;
            this.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ShadowWidth = 10;
            this.ShowShadow = true;
            this.ShowSystemButtons = false;
            this.Text = "";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.dSkinPanel1.ResumeLayout(false);
            this.dSkinPanel1.PerformLayout();
            this.dSkinPanel2.ResumeLayout(false);
            this.dSkinPanel5.ResumeLayout(false);
            this.dSkinPanel5.PerformLayout();
            this.dSkinPanel4.ResumeLayout(false);
            this.dSkinPanel4.PerformLayout();
            this.dSkinPanel3.ResumeLayout(false);
            this.dSkinPanel3.PerformLayout();
            this.LocalMeeting.ResumeLayout(false);
            this.dSkinPanel8.ResumeLayout(false);
            this.dSkinPanel8.PerformLayout();
            this.dSkinPanel7.ResumeLayout(false);
            this.dSkinPanel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinPanel dSkinPanel1;
        private DSkin.Controls.DSkinLabel dSkinLabel1;
        private DSkin.Controls.DSkinPanel dSkinPanel2;
        private DSkin.Controls.DSkinPanel dSkinPanel3;
        private DSkin.Controls.DSkinLabel dSkinLabel2;
        private DSkin.Controls.DSkinPanel dSkinPanel4;
        private DSkin.Controls.DSkinLabel dSkinLabel3;
        private DSkin.Controls.DSkinPanel dSkinPanel5;
        private DSkin.Controls.DSkinLabel dSkinLabel5;
        private DSkin.Controls.DSkinPanel LocalMeeting;
        private DSkin.Controls.DSkinPanel dSkinPanel8;
        private DSkin.Controls.DSkinLabel dSkinLabel8;
        private DSkin.Controls.DSkinLabel dSkinLabel7;
        private DSkin.Controls.DSkinPanel dSkinPanel7;
        private DSkin.Controls.DSkinLabel dSkinLabel6;
        private DSkin.Controls.DSkinPictureBox dSkinPictureBox1;
        private DSkin.Controls.DSkinPictureBox dSkinPictureBox2;
        public DSkin.Controls.DSkinTextBox MeetIDText;
        public DSkin.Controls.DSkinTextBox veriftCodeText;
        public DSkin.Controls.DSkinButton Connect;
    }
}

