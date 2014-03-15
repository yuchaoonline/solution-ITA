namespace ITAMngApp.CmMng.ServForm
{
    partial class CommServForm
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
            this.bt_StopServ = new System.Windows.Forms.Button();
            this.bt_StartServ = new System.Windows.Forms.Button();
            this.lb_statusinfo = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.RTB_Output = new System.Windows.Forms.RichTextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_StopServ
            // 
            this.bt_StopServ.Image = global::ITAMngApp.Properties.Resources.ts_stop;
            this.bt_StopServ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_StopServ.Location = new System.Drawing.Point(114, 8);
            this.bt_StopServ.Name = "bt_StopServ";
            this.bt_StopServ.Size = new System.Drawing.Size(78, 25);
            this.bt_StopServ.TabIndex = 0;
            this.bt_StopServ.Text = "关闭服务";
            this.bt_StopServ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_StopServ.UseVisualStyleBackColor = true;
            this.bt_StopServ.Click += new System.EventHandler(this.bt_StopServ_Click);
            // 
            // bt_StartServ
            // 
            this.bt_StartServ.Image = global::ITAMngApp.Properties.Resources.ts_start;
            this.bt_StartServ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_StartServ.Location = new System.Drawing.Point(6, 8);
            this.bt_StartServ.Name = "bt_StartServ";
            this.bt_StartServ.Size = new System.Drawing.Size(76, 25);
            this.bt_StartServ.TabIndex = 0;
            this.bt_StartServ.Text = "开启服务";
            this.bt_StartServ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bt_StartServ.UseVisualStyleBackColor = true;
            this.bt_StartServ.Click += new System.EventHandler(this.bt_StartServ_Click);
            // 
            // lb_statusinfo
            // 
            this.lb_statusinfo.AutoSize = true;
            this.lb_statusinfo.Location = new System.Drawing.Point(229, 15);
            this.lb_statusinfo.Name = "lb_statusinfo";
            this.lb_statusinfo.Size = new System.Drawing.Size(53, 12);
            this.lb_statusinfo.TabIndex = 1;
            this.lb_statusinfo.Text = "当前状态";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bt_StartServ);
            this.splitContainer1.Panel1.Controls.Add(this.lb_statusinfo);
            this.splitContainer1.Panel1.Controls.Add(this.bt_StopServ);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.RTB_Output);
            this.splitContainer1.Size = new System.Drawing.Size(821, 181);
            this.splitContainer1.SplitterDistance = 39;
            this.splitContainer1.TabIndex = 2;
            // 
            // RTB_Output
            // 
            this.RTB_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB_Output.Enabled = false;
            this.RTB_Output.Location = new System.Drawing.Point(0, 0);
            this.RTB_Output.Name = "RTB_Output";
            this.RTB_Output.Size = new System.Drawing.Size(821, 138);
            this.RTB_Output.TabIndex = 0;
            this.RTB_Output.Text = "";
            // 
            // CommServForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 181);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "CommServForm";
            this.Text = "通讯服务信息";
            this.Load += new System.EventHandler(this.CommServForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_StartServ;
        private System.Windows.Forms.Button bt_StopServ;
        private System.Windows.Forms.Label lb_statusinfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox RTB_Output;
    }
}