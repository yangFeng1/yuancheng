namespace linjun
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.screen = new DSkin.Controls.DSkinPictureBox();
            this.dSkinPictureBox1 = new DSkin.Controls.DSkinPictureBox();
            this.dSkinPictureBox2 = new DSkin.Controls.DSkinPictureBox();
            this.dSkinPictureBox3 = new DSkin.Controls.DSkinPictureBox();
            this.closeBtn = new DSkin.Controls.DSkinPictureBox();
            this.closeTips = new DSkin.Controls.DSkinPanel();
            this.close = new DSkin.Controls.DSkinButton();
            this.enterClose = new DSkin.Controls.DSkinButton();
            this.dSkinLabel2 = new DSkin.Controls.DSkinLabel();
            this.dSkinPanel2 = new DSkin.Controls.DSkinPanel();
            this.dSkinPictureBox5 = new DSkin.Controls.DSkinPictureBox();
            this.dSkinLabel1 = new DSkin.Controls.DSkinLabel();
            this.closeTips.SuspendLayout();
            this.dSkinPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // screen
            // 
            this.screen.BackgroundImage = global::linjun.Properties.Resources.meet_client_screen_selected;
            this.screen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.screen.Image = null;
            this.screen.Images = null;
            this.screen.Location = new System.Drawing.Point(370, 40);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(62, 62);
            this.screen.TabIndex = 0;
            this.screen.Text = "dSkinPictureBox1";
            this.screen.Click += new System.EventHandler(this.screen_Click);
            // 
            // dSkinPictureBox1
            // 
            this.dSkinPictureBox1.BackgroundImage = global::linjun.Properties.Resources.meet_client_mute_selected;
            this.dSkinPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dSkinPictureBox1.Image = null;
            this.dSkinPictureBox1.Images = null;
            this.dSkinPictureBox1.Location = new System.Drawing.Point(370, 134);
            this.dSkinPictureBox1.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.dSkinPictureBox1.Name = "dSkinPictureBox1";
            this.dSkinPictureBox1.Size = new System.Drawing.Size(62, 62);
            this.dSkinPictureBox1.TabIndex = 1;
            this.dSkinPictureBox1.Text = "dSkinPictureBox1";
            // 
            // dSkinPictureBox2
            // 
            this.dSkinPictureBox2.BackgroundImage = global::linjun.Properties.Resources.meet_client_video_selected;
            this.dSkinPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dSkinPictureBox2.Image = null;
            this.dSkinPictureBox2.Images = null;
            this.dSkinPictureBox2.Location = new System.Drawing.Point(370, 228);
            this.dSkinPictureBox2.Name = "dSkinPictureBox2";
            this.dSkinPictureBox2.Size = new System.Drawing.Size(62, 62);
            this.dSkinPictureBox2.TabIndex = 2;
            this.dSkinPictureBox2.Text = "dSkinPictureBox1";
            // 
            // dSkinPictureBox3
            // 
            this.dSkinPictureBox3.BackgroundImage = global::linjun.Properties.Resources.meet_client_desk_selected;
            this.dSkinPictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dSkinPictureBox3.Image = null;
            this.dSkinPictureBox3.Images = null;
            this.dSkinPictureBox3.Location = new System.Drawing.Point(370, 322);
            this.dSkinPictureBox3.Name = "dSkinPictureBox3";
            this.dSkinPictureBox3.Size = new System.Drawing.Size(62, 62);
            this.dSkinPictureBox3.TabIndex = 3;
            this.dSkinPictureBox3.Text = "  ";
            // 
            // closeBtn
            // 
            this.closeBtn.BackgroundImage = global::linjun.Properties.Resources.meet_client_exit_selected;
            this.closeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeBtn.Image = null;
            this.closeBtn.Images = null;
            this.closeBtn.Location = new System.Drawing.Point(370, 450);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(62, 62);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Text = "dSkinPictureBox1";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // closeTips
            // 
            this.closeTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.closeTips.Controls.Add(this.close);
            this.closeTips.Controls.Add(this.enterClose);
            this.closeTips.Controls.Add(this.dSkinLabel2);
            this.closeTips.Controls.Add(this.dSkinPanel2);
            this.closeTips.Location = new System.Drawing.Point(43, 349);
            this.closeTips.Name = "closeTips";
            this.closeTips.RightBottom = ((System.Drawing.Image)(resources.GetObject("closeTips.RightBottom")));
            this.closeTips.Size = new System.Drawing.Size(260, 140);
            this.closeTips.TabIndex = 5;
            this.closeTips.Text = "dSkinPanel1";
            this.closeTips.Visible = false;
            // 
            // close
            // 
            this.close.AdaptImage = true;
            this.close.BaseColor = System.Drawing.Color.Transparent;
            this.close.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.close.ButtonBorderWidth = 1;
            this.close.ButtonStyle = DSkin.DirectUI.ButtonStyles.Style1;
            this.close.DialogResult = System.Windows.Forms.DialogResult.None;
            this.close.EffectColor = System.Drawing.Color.Transparent;
            this.close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.close.HoverColor = System.Drawing.Color.Empty;
            this.close.HoverImage = null;
            this.close.IsPureColor = true;
            this.close.Location = new System.Drawing.Point(191, 103);
            this.close.Name = "close";
            this.close.NormalImage = null;
            this.close.PressColor = System.Drawing.Color.Empty;
            this.close.PressedImage = null;
            this.close.Radius = 2;
            this.close.ShowButtonBorder = true;
            this.close.Size = new System.Drawing.Size(48, 24);
            this.close.TabIndex = 4;
            this.close.Text = "取消";
            this.close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.close.TextPadding = 0;
            this.close.Click += new System.EventHandler(this.close_Paint);
            this.close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.close_MouseDown);
            this.close.MouseEnter += new System.EventHandler(this.close_MouseEnter);
            this.close.MouseLeave += new System.EventHandler(this.close_MouseLeave);
            // 
            // enterClose
            // 
            this.enterClose.AdaptImage = true;
            this.enterClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(79)))), ((int)(((byte)(254)))));
            this.enterClose.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(79)))), ((int)(((byte)(254)))));
            this.enterClose.ButtonBorderWidth = 1;
            this.enterClose.ButtonStyle = DSkin.DirectUI.ButtonStyles.Style1;
            this.enterClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.enterClose.EffectColor = System.Drawing.Color.Transparent;
            this.enterClose.ForeColor = System.Drawing.Color.White;
            this.enterClose.HoverColor = System.Drawing.Color.Empty;
            this.enterClose.HoverImage = null;
            this.enterClose.IsPureColor = true;
            this.enterClose.Location = new System.Drawing.Point(119, 103);
            this.enterClose.Name = "enterClose";
            this.enterClose.NormalImage = null;
            this.enterClose.PressColor = System.Drawing.Color.Empty;
            this.enterClose.PressedImage = null;
            this.enterClose.Radius = 2;
            this.enterClose.ShowButtonBorder = true;
            this.enterClose.Size = new System.Drawing.Size(48, 24);
            this.enterClose.TabIndex = 1;
            this.enterClose.Text = "确定";
            this.enterClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enterClose.TextPadding = 0;
            this.enterClose.Click += new System.EventHandler(this.enterClose_Paint);
            this.enterClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.enterClose_MouseDown);
            this.enterClose.MouseEnter += new System.EventHandler(this.enterClose_MouseEnter);
            this.enterClose.MouseLeave += new System.EventHandler(this.enterClose_MouseLeave);
            // 
            // dSkinLabel2
            // 
            this.dSkinLabel2.Location = new System.Drawing.Point(8, 48);
            this.dSkinLabel2.Name = "dSkinLabel2";
            this.dSkinLabel2.Size = new System.Drawing.Size(110, 16);
            this.dSkinLabel2.TabIndex = 1;
            this.dSkinLabel2.Text = "确定退出当前会议?";
            // 
            // dSkinPanel2
            // 
            this.dSkinPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(123)))), ((int)(((byte)(246)))));
            this.dSkinPanel2.Controls.Add(this.dSkinPictureBox5);
            this.dSkinPanel2.Controls.Add(this.dSkinLabel1);
            this.dSkinPanel2.Location = new System.Drawing.Point(0, 0);
            this.dSkinPanel2.Name = "dSkinPanel2";
            this.dSkinPanel2.RightBottom = ((System.Drawing.Image)(resources.GetObject("dSkinPanel2.RightBottom")));
            this.dSkinPanel2.Size = new System.Drawing.Size(260, 32);
            this.dSkinPanel2.TabIndex = 0;
            this.dSkinPanel2.Text = "dSkinPanel2";
            // 
            // dSkinPictureBox5
            // 
            this.dSkinPictureBox5.BackgroundImage = global::linjun.Properties.Resources.meet_client_close_default;
            this.dSkinPictureBox5.Image = null;
            this.dSkinPictureBox5.Images = null;
            this.dSkinPictureBox5.Location = new System.Drawing.Point(235, 3);
            this.dSkinPictureBox5.Name = "dSkinPictureBox5";
            this.dSkinPictureBox5.Size = new System.Drawing.Size(22, 24);
            this.dSkinPictureBox5.TabIndex = 1;
            this.dSkinPictureBox5.Text = "dSkinPictureBox5";
            this.dSkinPictureBox5.Click += new System.EventHandler(this.dSkinPictureBox5_Click);
            // 
            // dSkinLabel1
            // 
            this.dSkinLabel1.ForeColor = System.Drawing.Color.White;
            this.dSkinLabel1.Location = new System.Drawing.Point(8, 8);
            this.dSkinLabel1.Name = "dSkinLabel1";
            this.dSkinLabel1.Size = new System.Drawing.Size(29, 16);
            this.dSkinLabel1.TabIndex = 0;
            this.dSkinLabel1.Text = "提示";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(458, 566);
            this.ControlBox = false;
            this.Controls.Add(this.closeTips);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.dSkinPictureBox3);
            this.Controls.Add(this.dSkinPictureBox2);
            this.Controls.Add(this.dSkinPictureBox1);
            this.Controls.Add(this.screen);
            this.Name = "Form2";
            this.Text = " n";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.closeTips.ResumeLayout(false);
            this.closeTips.PerformLayout();
            this.dSkinPanel2.ResumeLayout(false);
            this.dSkinPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinPictureBox screen;
        private DSkin.Controls.DSkinPictureBox dSkinPictureBox1;
        private DSkin.Controls.DSkinPictureBox dSkinPictureBox2;
        private DSkin.Controls.DSkinPictureBox dSkinPictureBox3;
        private DSkin.Controls.DSkinPictureBox closeBtn;
        private DSkin.Controls.DSkinPanel closeTips;
        private DSkin.Controls.DSkinLabel dSkinLabel2;
        private DSkin.Controls.DSkinPanel dSkinPanel2;
        private DSkin.Controls.DSkinPictureBox dSkinPictureBox5;
        private DSkin.Controls.DSkinLabel dSkinLabel1;
        private DSkin.Controls.DSkinButton enterClose;
        private DSkin.Controls.DSkinButton close;
    }
}