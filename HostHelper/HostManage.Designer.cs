namespace HostHelper
{
    partial class HostManage
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostManage));
            this.notifyIconHost = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripHost = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemManage = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.richTextBoxHost = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripHost.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconHost
            // 
            this.notifyIconHost.ContextMenuStrip = this.contextMenuStripHost;
            this.notifyIconHost.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconHost.Icon")));
            this.notifyIconHost.Text = "Host助手";
            this.notifyIconHost.Visible = true;
            // 
            // contextMenuStripHost
            // 
            this.contextMenuStripHost.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.contextMenuStripHost.BackgroundImage = global::HostHelper.Properties.Resources.bg;
            this.contextMenuStripHost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.contextMenuStripHost.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemManage,
            this.ToolStripMenuItemAbout,
            this.ToolStripMenuItemExit});
            this.contextMenuStripHost.Name = "contextMenuStripHost";
            this.contextMenuStripHost.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStripHost.Size = new System.Drawing.Size(153, 92);
            // 
            // ToolStripMenuItemManage
            // 
            this.ToolStripMenuItemManage.MergeIndex = 2;
            this.ToolStripMenuItemManage.Name = "ToolStripMenuItemManage";
            this.ToolStripMenuItemManage.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemManage.Text = "HOST管理";
            this.ToolStripMenuItemManage.Click += new System.EventHandler(this.ToolStripMenuItemManage_Click);
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.MergeIndex = 1;
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemAbout.Text = "关于";
            this.ToolStripMenuItemAbout.Click += new System.EventHandler(this.ToolStripMenuItemAbout_Click);
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.MergeIndex = 0;
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemExit.Text = "退出";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(95, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.Location = new System.Drawing.Point(191, 370);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 4;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // richTextBoxHost
            // 
            this.richTextBoxHost.Location = new System.Drawing.Point(-1, 0);
            this.richTextBoxHost.Name = "richTextBoxHost";
            this.richTextBoxHost.Size = new System.Drawing.Size(387, 355);
            this.richTextBoxHost.TabIndex = 5;
            this.richTextBoxHost.Text = "";
            // 
            // HostManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 405);
            this.Controls.Add(this.richTextBoxHost);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HostManage";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Host助手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HostManage_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStripHost.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconHost;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripHost;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemManage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.RichTextBox richTextBoxHost;
    }
}

