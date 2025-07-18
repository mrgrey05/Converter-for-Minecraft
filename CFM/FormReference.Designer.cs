namespace CFM
{
    partial class FormReference
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelVersion2 = new System.Windows.Forms.Label();
            this.labelMail = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.linkLabelMail = new System.Windows.Forms.LinkLabel();
            this.gInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gInfo
            // 
            this.gInfo.Controls.Add(this.tableLayoutPanel1);
            this.gInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gInfo.Location = new System.Drawing.Point(0, 0);
            this.gInfo.Name = "gInfo";
            this.gInfo.Padding = new System.Windows.Forms.Padding(5);
            this.gInfo.Size = new System.Drawing.Size(384, 111);
            this.gInfo.TabIndex = 0;
            this.gInfo.TabStop = false;
            this.gInfo.Text = "О нас";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.91978F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.08022F));
            this.tableLayoutPanel1.Controls.Add(this.labelVersion2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelMail, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelVersion, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.linkLabelMail, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(374, 88);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelVersion2
            // 
            this.labelVersion2.AutoSize = true;
            this.labelVersion2.Location = new System.Drawing.Point(170, 44);
            this.labelVersion2.Name = "labelVersion2";
            this.labelVersion2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.labelVersion2.Size = new System.Drawing.Size(22, 23);
            this.labelVersion2.TabIndex = 3;
            this.labelVersion2.Text = "v0.";
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelMail.Location = new System.Drawing.Point(3, 21);
            this.labelMail.Name = "labelMail";
            this.labelMail.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.labelMail.Size = new System.Drawing.Size(161, 23);
            this.labelMail.TabIndex = 0;
            this.labelMail.Text = "Почта для связи:";
            this.labelMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelVersion.Location = new System.Drawing.Point(3, 44);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.labelVersion.Size = new System.Drawing.Size(161, 23);
            this.labelVersion.TabIndex = 2;
            this.labelVersion.Text = "Версия приложения:";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // linkLabelMail
            // 
            this.linkLabelMail.AutoSize = true;
            this.linkLabelMail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.linkLabelMail.Location = new System.Drawing.Point(170, 21);
            this.linkLabelMail.Name = "linkLabelMail";
            this.linkLabelMail.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.linkLabelMail.Size = new System.Drawing.Size(201, 23);
            this.linkLabelMail.TabIndex = 1;
            this.linkLabelMail.TabStop = true;
            this.linkLabelMail.Text = "bondarev.sa.stud@gmail.com";
            this.linkLabelMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMail_LinkClicked);
            // 
            // FormReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 111);
            this.Controls.Add(this.gInfo);
            this.MaximumSize = new System.Drawing.Size(800, 400);
            this.MinimumSize = new System.Drawing.Size(400, 150);
            this.Name = "FormReference";
            this.Load += new System.EventHandler(this.FormReference_Load);
            this.gInfo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gInfo;
        private System.Windows.Forms.Label labelVersion2;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.LinkLabel linkLabelMail;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}