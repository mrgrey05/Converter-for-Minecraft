namespace CFM
{
    partial class About
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
            this.gInfo = new System.Windows.Forms.GroupBox();
            this.labelVersion2 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.linkLabelMail = new System.Windows.Forms.LinkLabel();
            this.labelMail = new System.Windows.Forms.Label();
            this.gInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gInfo
            // 
            this.gInfo.Controls.Add(this.labelVersion2);
            this.gInfo.Controls.Add(this.labelVersion);
            this.gInfo.Controls.Add(this.linkLabelMail);
            this.gInfo.Controls.Add(this.labelMail);
            this.gInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gInfo.Location = new System.Drawing.Point(0, 0);
            this.gInfo.Name = "gInfo";
            this.gInfo.Padding = new System.Windows.Forms.Padding(5);
            this.gInfo.Size = new System.Drawing.Size(384, 111);
            this.gInfo.TabIndex = 0;
            this.gInfo.TabStop = false;
            this.gInfo.Text = "О нас";
            // 
            // labelVersion2
            // 
            this.labelVersion2.AutoSize = true;
            this.labelVersion2.Location = new System.Drawing.Point(154, 66);
            this.labelVersion2.Name = "labelVersion2";
            this.labelVersion2.Size = new System.Drawing.Size(28, 13);
            this.labelVersion2.TabIndex = 3;
            this.labelVersion2.Text = "v0.3";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(35, 66);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(112, 13);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "Версия приложения:";
            // 
            // linkLabelMail
            // 
            this.linkLabelMail.AutoSize = true;
            this.linkLabelMail.Location = new System.Drawing.Point(153, 44);
            this.linkLabelMail.Name = "linkLabelMail";
            this.linkLabelMail.Size = new System.Drawing.Size(147, 13);
            this.linkLabelMail.TabIndex = 1;
            this.linkLabelMail.TabStop = true;
            this.linkLabelMail.Text = "bondarev.sa.stud@gmail.com";
            this.linkLabelMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMail_LinkClicked);
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Location = new System.Drawing.Point(53, 44);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(94, 13);
            this.labelMail.TabIndex = 0;
            this.labelMail.Text = "Почта для связи:";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 111);
            this.Controls.Add(this.gInfo);
            this.MaximumSize = new System.Drawing.Size(400, 150);
            this.MinimumSize = new System.Drawing.Size(400, 150);
            this.Name = "About";
            this.Text = "About";
            this.gInfo.ResumeLayout(false);
            this.gInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gInfo;
        private System.Windows.Forms.Label labelVersion2;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.LinkLabel linkLabelMail;
        private System.Windows.Forms.Label labelMail;
    }
}