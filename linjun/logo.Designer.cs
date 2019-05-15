namespace linjun
{
    partial class logo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(logo));
            this.logoIcon = new DSkin.Controls.DSkinPictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyIconListOut = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconList.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoIcon
            // 
            this.logoIcon.BackgroundImage = global::linjun.Properties.Resources.meet_logo_translucent;
            this.logoIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoIcon.Borders.AllWidth = 0;
            this.logoIcon.Borders.BottomWidth = 0;
            this.logoIcon.Borders.LeftWidth = 0;
            this.logoIcon.Borders.RightWidth = 0;
            this.logoIcon.Borders.TopWidth = 0;
            this.logoIcon.Image = null;
            this.logoIcon.Images = null;
            this.logoIcon.Location = new System.Drawing.Point(61, 27);
            this.logoIcon.Name = "logoIcon";
            this.logoIcon.Size = new System.Drawing.Size(68, 71);
            this.logoIcon.TabIndex = 0;
            this.logoIcon.Text = "dSkinPictureBox1";
            this.logoIcon.Click += new System.EventHandler(this.dSkinPictureBox1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notifyIconList;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_MouaseDoubleClick);
            // 
            // notifyIconList
            // 
            this.notifyIconList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyIconListOut});
            this.notifyIconList.Name = "notifyIconList";
            this.notifyIconList.Size = new System.Drawing.Size(181, 48);
            // 
            // notifyIconListOut
            // 
            this.notifyIconListOut.Name = "notifyIconListOut";
            this.notifyIconListOut.Size = new System.Drawing.Size(180, 22);
            this.notifyIconListOut.Text = "退出";
            this.notifyIconListOut.Click += new System.EventHandler(this.notifyIconListOut_Click);
            // 
            // logo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(200, 141);
            this.ControlBox = false;
            this.Controls.Add(this.logoIcon);
            this.Name = "logo";
            this.Text = "";
            this.Load += new System.EventHandler(this.logo_Load);
            this.notifyIconList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DSkin.Controls.DSkinPictureBox logoIcon;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip notifyIconList;
        private System.Windows.Forms.ToolStripMenuItem notifyIconListOut;
    }
}