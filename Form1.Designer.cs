namespace XtoDpad
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pad1RadioButton = new System.Windows.Forms.RadioButton();
            this.pad2RadioButton = new System.Windows.Forms.RadioButton();
            this.pad3RadioButton = new System.Windows.Forms.RadioButton();
            this.pad4RadioButton = new System.Windows.Forms.RadioButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.閉じるToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pad1RadioButton
            // 
            this.pad1RadioButton.AutoSize = true;
            this.pad1RadioButton.Checked = true;
            this.pad1RadioButton.Location = new System.Drawing.Point(13, 13);
            this.pad1RadioButton.Name = "pad1RadioButton";
            this.pad1RadioButton.Size = new System.Drawing.Size(47, 16);
            this.pad1RadioButton.TabIndex = 0;
            this.pad1RadioButton.TabStop = true;
            this.pad1RadioButton.Text = "pad1";
            this.pad1RadioButton.UseVisualStyleBackColor = true;
            // 
            // pad2RadioButton
            // 
            this.pad2RadioButton.AutoSize = true;
            this.pad2RadioButton.Location = new System.Drawing.Point(66, 13);
            this.pad2RadioButton.Name = "pad2RadioButton";
            this.pad2RadioButton.Size = new System.Drawing.Size(47, 16);
            this.pad2RadioButton.TabIndex = 1;
            this.pad2RadioButton.Text = "pad2";
            this.pad2RadioButton.UseVisualStyleBackColor = true;
            // 
            // pad3RadioButton
            // 
            this.pad3RadioButton.AutoSize = true;
            this.pad3RadioButton.Location = new System.Drawing.Point(120, 13);
            this.pad3RadioButton.Name = "pad3RadioButton";
            this.pad3RadioButton.Size = new System.Drawing.Size(47, 16);
            this.pad3RadioButton.TabIndex = 2;
            this.pad3RadioButton.Text = "pad3";
            this.pad3RadioButton.UseVisualStyleBackColor = true;
            // 
            // pad4RadioButton
            // 
            this.pad4RadioButton.AutoSize = true;
            this.pad4RadioButton.Location = new System.Drawing.Point(174, 13);
            this.pad4RadioButton.Name = "pad4RadioButton";
            this.pad4RadioButton.Size = new System.Drawing.Size(47, 16);
            this.pad4RadioButton.TabIndex = 3;
            this.pad4RadioButton.Text = "pad4";
            this.pad4RadioButton.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipTitle = "XtoDpad";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "XtoDpad";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.閉じるToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 26);
            // 
            // 閉じるToolStripMenuItem
            // 
            this.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem";
            this.閉じるToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.閉じるToolStripMenuItem.Text = "閉じる";
            this.閉じるToolStripMenuItem.Click += new System.EventHandler(this.閉じるToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 42);
            this.Controls.Add(this.pad4RadioButton);
            this.Controls.Add(this.pad3RadioButton);
            this.Controls.Add(this.pad2RadioButton);
            this.Controls.Add(this.pad1RadioButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "XtoDpad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.TextChanged += new System.EventHandler(this.Form1_TextChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton pad1RadioButton;
        private System.Windows.Forms.RadioButton pad2RadioButton;
        private System.Windows.Forms.RadioButton pad3RadioButton;
        private System.Windows.Forms.RadioButton pad4RadioButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 閉じるToolStripMenuItem;
    }
}

